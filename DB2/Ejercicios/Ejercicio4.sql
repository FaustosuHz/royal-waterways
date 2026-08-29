USE OUTATIME_INC
go

--Ejercicio  4

/* 
Se solicita crear una función que, dado el código de un cliente, devuelva su categoría: 
• “TENIENTE”:  2 viajes o menos  y menos de 30 años acumulados de distancia temporal. 
• “COMANDANTE”: entre 3 y 5 viajes y entre 31 y 60 años acumulados. 
• “CORONEL”: más de 6 viajes y más de 61 años acumulados. 
• “A REVISAR”: si no encaja en las reglas anteriores. 
Si el cliente no tiene viajes, o solo tiene viajes reservados/cancelados/suspendidos, la función debe 
devolver “EXPLORADOR”
*/

--Primero cree la funcion para calcular la distancia temporal

CREATE FUNCTION udf_DistanciaTemporal(@codCliente INT)
	RETURNS INT
		AS
		BEGIN
			DECLARE @retorno INT

			SELECT @retorno = SUM(ABS(DATEDIFF(YEAR, d.fecha_hora, v.fechaHora_salida)))
			From viajes v,destinos d
			WHERE v.codCliente = @codCliente and v.destino_codDestino = d.codDestino
			and v.estado = 'REALIZADO'
			RETURN ISNULL(@retorno,0)

		END

GO

--Luego la funcion para la categoria utilizando la funcion anterior

CREATE FUNCTION udf_Categoria(@codCliente int)
	RETURNS varchar(15)
		AS
		BEGIN

		DECLARE @retorno varchar(15)
		DECLARE @distanciaTemporal INT
		DECLARE @cantidadDeViajes INT
		
		SET @distanciaTemporal = dbo.udf_DistanciaTemporal(@codCliente)

		SET @cantidadDeViajes = (SELECT COUNT(v.codViaje)
								FROM viajes v
								WHERE v.codCliente = @codCliente and v.estado = 'REALIZADO')

		SELECT @retorno = CASE
			WHEN @cantidadDeViajes = 0 THEN 'EXPLORADOR'
			WHEN @cantidadDeViajes <= 2 and @distanciaTemporal < 30 THEN 'TENIENTE'
			WHEN @cantidadDeViajes between 3 and 5 and @distanciaTemporal between 31 and 60 THEN 'COMANDANTE'
			WHEN @cantidadDeViajes > 6 and @distanciaTemporal > 61 THEN 'CORONEL'
			ELSE 'A REVISAR'
			END

		RETURN @retorno

		END

--Para ejecutarla usar un @codCliente

SELECT dbo.udf_Categoria(1);