/*

Ejercicio 8 

Creá una vista que muestre, por cada destino destacado, cuántos viajes realizados llegaron allí y 
cuántos choferes y vehículos distintos participaron en sus viajes (sin importar el estado). 
Solo deben aparecer los destinos que reciben más viajes que “lo normal”: aquellos cuya cantidad total 
de viajes supere el promedio de viajes RESERVADOS por chofer.
*/


CREATE VIEW VW_DestinosModa
    AS
        SELECT d.codDestino, d.descripcion, COUNT(v.codViaje) AS totalViajes,
        COUNT(DISTINCT v.codChoferAsignado) AS choferesDistintos,
        COUNT(DISTINCT v.patenteVehiculoAsignado) AS vehiculosDistintos
        FROM destinos d JOIN viajes v ON v.destino_codDestino = d.codDestino JOIN clientes c ON c.codCliente = v.codCliente
        WHERE dbo.udf_Categoria(c.codCliente) <> 'EXPLORADOR'
        GROUP BY d.codDestino, d.descripcion
        HAVING COUNT(v.codViaje) > (
                                    SELECT AVG(miTabla.cantReservados)
                                    FROM
                                        (SELECT COUNT(v2.codViaje) AS cantReservados
                                         FROM viajes v2
                                         WHERE v2.estado = 'RESERVADO'
                                         GROUP BY v2.codChoferAsignado) miTabla
                                          )

SELECT *
FROM VW_DestinosModa;