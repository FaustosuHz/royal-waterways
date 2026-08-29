USE OUTATIME_INC

--Ejercicio 5

/*necesita un stored procedure que, dado 
un estado (RESERVADO o SUSPENDIDO), detecte los viajes “viejos” y aplique la 
política de la empresa: si la contratación tiene más de 6 meses 


y pertenece a una 
de las 4 oficinas con menos viajes realizados en los últimos 5 meses, se debe 
generar una devolución del 35% del pago. 
El procedimiento debe insertar la devolución, cambiar el estado del viaje a 
CANCELADO, y devolver como salida la cantidad de devoluciones realizadas y un 
mensaje de error si corresponde.*/


CREATE PROCEDURE udp_PoliticaDeEmpresa
    @estado VARCHAR(15)
        AS
        BEGIN

            BEGIN TRY
            DECLARE @cantidadDevoluciones INT

                INSERT INTO devoluciones(codPago,fechaDevolucion,montoDevuelto,motivo)
                            SELECT p.codPago, GETDATE(), p.montoTotal * 0.35, 'devolucion por politica de la empresa'
                            FROM viajes v, pagos p
                            WHERE v.codViaje = p.codViaje and v.estado = @estado and v.fechaHoraContratacion <= DATEADD(MONTH,-6,GETDATE())
                                and v.codOficina IN(SELECT TOP 4 o.codOficina
                                                    FROM viajes v, oficinas o
                                                    WHERE v.codOficina = o.codOficina
                                                    and v.estado = 'REALIZADO'
                                                    and v.fechaHora_salida >= DATEADD(MONTH,-5,GETDATE())
                                                    GROUP BY o.codOficina
                                                    ORDER BY COUNT(v.codViaje) ASC)

               SET @cantidadDevoluciones = (SELECT COUNT(d.codDevolucion)
                                            FROM devoluciones d, pagos p, viajes v
                                            WHERE d.codPago = p.codPago and p.codViaje = v.codViaje
                                            and v.estado = @estado and v.fechaHoraContratacion <= DATEADD(MONTH,-6,GETDATE()))

               UPDATE viajes
               SET estado = 'CANCELADO'
               WHERE estado = @estado and fechaHoraContratacion <= DATEADD(MONTH,-6,GETDATE())
                              and codOficina IN(SELECT TOP 4 o.codOficina
                                                FROM viajes v, oficinas o
                                                WHERE v.codOficina = o.codOficina and v.estado = 'REALIZADO'
                                                      and v.fechaHora_salida >= DATEADD(MONTH,-5,GETDATE())
                                                GROUP BY o.codOficina
                                                ORDER BY COUNT(v.codViaje) ASC)


        SELECT @cantidadDevoluciones AS cantidadDevoluciones

    END TRY

    BEGIN CATCH

        SELECT 'Ocurrio un error al ejecutar el procedimiento' AS mensaje

    END CATCH

END

--Para ejecutar

EXEC udp_PoliticaDeEmpresa 'RESERVADO'

EXEC udp_PoliticaDeEmpresa 'RESERVADO'