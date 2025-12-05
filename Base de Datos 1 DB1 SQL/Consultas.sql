USE EMPRESA

--DQL

--PRIMERA CONSULTA

SELECT m.maquinaId, m.fechaInicio, maq.maquinaDescripcion, macEsp.maquinaDescripcion, mec.nombre, mec.apellido, mec.ci
FROM mantenimientos m INNER JOIN maquinas maq ON m.maquinaId = maq.maquinaId
INNER JOIN maquinas_especificas macEsp ON macEsp.tipoId = maq.tipoId 
INNER JOIN mecanicos mec ON m.idMecanico = mec.idMecanico
WHERE m.fechaFinalizacion IS NULL


--SEGUNDA CONSULTA

SELECT mec.ci, mec.apellido
FROM mecanicos mec INNER JOIN mantenimientos m ON mec.idMecanico = m.idMecanico
WHERE YEAR(m.fechaInicio) = 2025
GROUP BY mec.ci, mec.apellido
HAVING COUNT(*) > 2;


--TERCERA CONSULTA

SELECT maq.maquinaId, maq.maquinaDescripcion,
COUNT(DISTINCT manRep.repuestoId) AS repuestos_diferentes, 
MAX(m.fechaInicio) AS ultima_fecha_mantenimiento,
AVG(manRep.cantidad) AS promedio_repuestos
FROM maquinas maq INNER JOIN mantenimientos m ON m.maquinaId = maq.maquinaId
INNER JOIN mantenimientoRepuestos manRep ON manRep.maquinaId = m.maquinaId 
GROUP BY maq.maquinaId, maq.maquinaDescripcion


--CUARTA CONSULTA

SELECT rep1.repuestoId AS codigo_repuesto,
rep1.descripcionRepuestos AS descripcion_repuesto,
rep2.repuestoId AS codigo_compatible,
rep2.descripcionRepuestos AS descripcion_compatible
FROM repuestoCompatible repComp
INNER JOIN repuestos rep1 ON repComp.repuestoId1 = rep1.repuestoId
INNER JOIN repuestos rep2 ON repComp.repuestoId2 = rep2.repuestoId


--QUINTA CONSULTA

SELECT maq.maquinaDescripcion, reg.detalle
FROM maquinas maq INNER JOIN mantenimientos m ON m.maquinaId = maq.maquinaId
INNER JOIN registros reg ON reg.maquinaId = m.maquinaId
WHERE reg.detalle LIKE '%Cambio%'
GROUP BY maq.maquinaId, maq.maquinaDescripcion, reg.detalle
HAVING COUNT(*) = (

SELECT MAX(cant)
FROM (SELECT COUNT(*) AS cant
    FROM mantenimientos man2 INNER JOIN registros reg2 ON reg2.maquinaId = man2.maquinaId
    WHERE reg2.detalle LIKE '%Cambio%'
    GROUP BY man2.maquinaId
  ) conteo )


--SEXTA CONSULTA

SELECT DISTINCT maq.maquinaId, maq.maquinaDescripcion, reg.detalle
FROM maquinas maq 
INNER JOIN mantenimientos m ON m.maquinaId = maq.maquinaId
INNER JOIN registros reg ON reg.maquinaId = m.maquinaId
WHERE reg.detalle LIKE '%válvula%'
GROUP BY maq.maquinaId, maq.maquinaDescripcion, reg.detalle


--SEPTIMA CONSULTA

UPDATE mantenimientos
SET fechaFinalizacion = GETDATE(), horaFinalizacion = '14:00'
WHERE fechaFinalizacion IS NULL;