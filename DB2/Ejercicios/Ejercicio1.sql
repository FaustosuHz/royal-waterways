USE OUTATIME_INC

--Ejercicio 1
--crear los índices necesarios para acelerar las relaciones y las búsquedas frecuentes según los criterios vistos en clase.

--choferes

CREATE INDEX IDX_codPais ON choferes(codPais)

CREATE INDEX IDX_oficinaAsignado ON choferes(oficinaAsignado)

--clientes

CREATE INDEX IDX_codPais ON clientes(codPais)

--devoluciones

CREATE INDEX IDX_codPago ON devoluciones(codPago)

--oficinas

CREATE INDEX IDX_codPais ON oficinas(codPais)

--pagos

CREATE INDEX IDX_codViaje ON pagos(codViaje)

--vehiculos

CREATE INDEX IDX_codPais ON vehiculos(codPais)

CREATE INDEX IDX_modelo ON vehiculos(codModelo)

CREATE INDEX IDX_oficinaAsignado ON vehiculos(oficinaAsignado)

--viajes

CREATE INDEX IDX_codCliente ON viajes(codCliente)

CREATE INDEX IDX_codOficina ON viajes(codOficina)

CREATE INDEX IDX_destino_codDestino ON viajes(destino_codDestino)

CREATE INDEX IDX_codChoferAsignado ON viajes(codChoferAsignado)

CREATE INDEX IDX_patenteVehiculoAsignado ON viajes(patenteVehiculoAsignado)
