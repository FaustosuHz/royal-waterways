--Ejercicio  3

/* 
A) CHOFERES QUE MÁS VIAJARON EN EL TIEMPO
- Considerar SOLO viajes REALIZADOS
- Calcular años viajados = diferencia entre fecha de destino y fecha de salida
- Obtener el promedio general de años viajados
- Listar los 3 choferes que SUPEREN ese promedio
*/

Select top 3 c.nombre, c.apellido, SUM(DATEDIFF(YEAR, v.fechaHora_salida, d.fecha_hora)) as AñosViajados
FROM choferes c JOIN viajes v ON c.codChofer = v.codChoferAsignado
JOIN destinos d ON v.destino_codDestino = d.codDestino
WHERE v.estado = 'REALIZADO'
Group by c.nombre, c.apellido
HAVING SUM(DATEDIFF(YEAR, v.fechaHora_salida, d.fecha_hora)) > (SELECT AVG(DATEDIFF(YEAR, v2.fechaHora_salida, d2.fecha_hora))
																FROM destinos d2 JOIN viajes v2 ON v2.destino_codDestino = d2.codDestino
																WHERE v2.estado = 'REALIZADO')
ORDER BY AñosViajados DESC


/* 
B) Se solicita listar la patente y el total de Gigowatts consumidos acumulados 
en todos sus viajes realizados, identificando los cuatro vehículos con mayor 
consumo total. 
Considerar únicamente viajes efectivamente realizados y calcular el 
consumo total en función de la energía requerida por cada modelo en cada 
viaje. 
*/

SELECT TOP 4 vi.patenteVehiculoAsignado, SUM(mv.consumoGWViaje) AS TotalGigawatts
FROM viajes vi JOIN vehiculos ve ON vi.patenteVehiculoAsignado = ve.patente
JOIN modeloVehiculo mv ON ve.codModelo = mv.codModelo
WHERE vi.estado = 'REALIZADO'
GROUP BY vi.patenteVehiculoAsignado
ORDER BY TotalGigawatts DESC


/* 
C) Se solicita identificar cuál es el destino con mayor demanda, considerando únicamente aquellos viajes 
cuyos pagos fueron realizados en efectivo.
*/


SELECT TOP 1 d.descripcion, COUNT(destino_codDestino)
FROM destinos d JOIN viajes v ON d.codDestino = v.destino_codDestino
JOIN pagos p ON p.codViaje = v.codViaje
WHERE p.metodo = 'EFECTIVO'
GROUP BY d.descripcion
ORDER BY COUNT(destino_codDestino) DESC

/* 
D) Para cada cliente (nombre y apellido), se solicita informar: 
cuántos viajes pagó con tarjeta (crédito o débito), y 
cuántos viajes tuvo que no se realizaron por quedar cancelados o suspendidos. 
*/

SELECT c.nombre, c.apellido, COUNT(p.metodo) as cantidadPagoTarjeta, COUNT(v.estado) as cantidadNoRealizados
FROM viajes v JOIN clientes c ON v.codCliente = c.codCliente JOIN pagos p ON p.codViaje = v.codViaje
WHERE p.metodo = 'CREDITO' OR  p.metodo = 'DEBITO' AND v.estado = 'CANCELADO' OR v.estado = 'SUSPENDIDO' 
GROUP BY c.nombre, c.apellido


/* 
F) Se solicita listar cada oficina y el total de dinero ganado (suma de costos de sus viajes), pero solo para 
las oficinas con historial impecable. 
*/

SELECT o.descripcion, SUM(v.costo) as totalViaje
FROM oficinas o JOIN viajes v ON o.codOficina = v.codOficina
WHERE v.estado = 'REALIZADO'
AND NOT EXISTS(SELECT 1
				FROM oficinas o2 JOIN viajes v2 ON o2.codOficina = v2.codOficina
				WHERE v2.estado <> 'REALIZADO'
				AND o2.codOficina = o.codOficina)

GROUP BY o.descripcion


/* 
G) Se solicita listar los choferes que no tengan viajes en estado REALIZADO, siempre que en el país al que 
pertenecen existan oficinas con viajes actualmente en estado RESERVADO. 
La idea es encontrar conductores “sin historial”, pero en zonas donde el trabajo ya está esperando. 
*/


SELECT c.nombre, c.apellido
FROM choferes c
WHERE NOT EXISTS (SELECT 1
                  FROM viajes v
                  JOIN choferes c2 ON v.codChoferAsignado = c2.codChofer
                  WHERE c2.codChofer = c.codChofer
                  AND v.estado = 'REALIZADO')
                  AND EXISTS (SELECT 1
                             FROM oficinas o
                             JOIN viajes v2 ON o.codOficina = v2.codOficina
                             WHERE o.codPais = c.codPais AND v2.estado = 'RESERVADO')


/* 
H) Calcular qué tipo de combustible ofrece mejor rendimiento económico por unidad de 
energía.
*/

SELECT mv.tipoCombustible, (SUM(v.costo)/SUM(mv.consumoGWViaje)) as rendimiento
FROM viajes v JOIN vehiculos ve ON v.patenteVehiculoAsignado = ve.patente
JOIN modeloVehiculo mv ON mv.codModelo = ve.codModelo
WHERE v.estado = 'REALIZADO'
GROUP BY mv.tipoCombustible
ORDER BY rendimiento DESC