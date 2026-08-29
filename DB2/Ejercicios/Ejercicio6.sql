/*

Ejercicio 6 

Para garantizar la equidad entre choferes, la empresa establece que no puede registrarse un nuevo 
viaje si el conductor supera el límite permitido de 15 viajes y 800 años acumulados. 
Se solicita crear una tabla de auditoría que registre los intentos rechazados (fecha, usuario, chofer, 
viaje, fecha de salida, cantidad de viajes y años acumulados), y un trigger que impida la inserción 
cuando no se cumplan las condiciones, dejando constancia para análisis futuro. 
Si el chofer está dentro de los parámetros permitidos, el viaje deberá guardarse normalmente; de lo 
contrario, quedará asentado en la auditoría. */

USE OUTATIME_INC
go

--Se crea la tabla

CREATE TABLE AuditoriaViajesRechazados
(
    idAuditoria INT IDENTITY PRIMARY KEY,
    fechaRegistro DATETIME DEFAULT GETDATE(),
    usuarioSistema VARCHAR(100),
    codChofer INT,
    codViaje INT,
    fechaSalida DATETIME,
    cantidadViajes INT,
    aniosAcumulados INT
)

go
--Se crea el trigger

CREATE TRIGGER TR_ControlChofer
ON viajes
INSTEAD OF INSERT
AS
BEGIN

    INSERT INTO AuditoriaViajesRechazados(fechaRegistro, usuarioSistema, codChofer, codViaje, fechaSalida, cantidadViajes, aniosAcumulados)
                                          SELECT GETDATE(), SYSTEM_USER, i.codChoferAsignado, i.codViaje, i.fechaHora_salida, COUNT(v.codViaje),
                                          SUM(ABS(DATEDIFF(YEAR,v.fechaHora_salida,d.fecha_hora)))
                                          FROM inserted i JOIN viajes v ON v.codChoferAsignado = i.codChoferAsignado
                                                JOIN destinos d ON d.codDestino = v.destino_codDestino
                                          GROUP BY i.codChoferAsignado, i.codViaje, i.fechaHora_salida
                                          HAVING COUNT(v.codViaje) > 15 AND SUM(ABS(DATEDIFF(YEAR,v.fechaHora_salida,d.fecha_hora))) > 800;


    INSERT INTO viajes (codViaje, codCliente, codOficina, fechaHoraContratacion, fechaHora_salida, destino_codDestino, fechaHora_vuelta,
                        costo, estado, codChoferAsignado, patenteVehiculoAsignado)
               SELECT i.codViaje, i.codCliente, i.codOficina, i.fechaHoraContratacion, i.fechaHora_salida,
                      i.destino_codDestino, i.fechaHora_vuelta, i.costo, i.estado, i.codChoferAsignado, i.patenteVehiculoAsignado
               FROM inserted i
               WHERE NOT EXISTS (
                                 SELECT 1
                                 FROM viajes v JOIN destinos d ON d.codDestino = v.destino_codDestino
                                 WHERE v.codChoferAsignado = i.codChoferAsignado
                                 GROUP BY v.codChoferAsignado
                                 HAVING COUNT(v.codViaje) > 15 AND SUM(ABS(DATEDIFF(YEAR,v.fechaHora_salida,d.fecha_hora))) > 800);

END






--para probarlo

Select * from viajes
Select * from AuditoriaViajesRechazados


INSERT INTO viajes VALUES
(95099, 1, 1,
'1800-01-01 08:00:00',
'2000-01-01 08:00:00',
45,
'2200-01-01 08:00:00',
1000,
'REALIZADO',
1,
'AAA111');