/*

Ejercicio 7 

Se solicita crear un trigger que, cada vez que se elimine un pago, 
verifique si corresponde a un viaje en estado CANCELADO y, en ese 
caso, actualice el límite de crédito del cliente devolviéndole el monto 
asociado. 
La idea es que el cliente recupere su capacidad de compra para nuevos viajes.  */

USE OUTATIME_INC
go

CREATE TRIGGER TR_DevolverCreditoCliente
ON pagos
AFTER DELETE
AS
BEGIN

    UPDATE c
    SET c.LimiteCreditoMax = c.LimiteCreditoMax + d.montoTotal
    FROM clientes c JOIN viajes v ON c.codCliente = v.codCliente
        JOIN deleted d ON v.codViaje = d.codViaje
    WHERE v.estado = 'CANCELADO';

END