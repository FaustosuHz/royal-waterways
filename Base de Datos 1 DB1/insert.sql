INSERT INTO maquinas_especificas VALUES
('NIV123', 'Niveladora'),
('TRA456', 'Tractor'),
('APL789', 'Aplanadora');

INSERT INTO maquinas (marca, modelo, anioFabricacion, maquinaDescripcion, consumoCombustible_L, tipoId) VALUES
('Caterpillar', 'D6T', 2018, 'Niveladora pesada', 15.5, 'NIV123'),
('John Deere', '8345R', 2020, 'Tractor de alto rendimiento', 12.8, 'TRA456'),
('Komatsu', 'GD655', 2019, 'Niveladora eficiente', 14.2, 'NIV123'),
('Volvo', 'SD160B', 2021, 'Aplanadora moderna', 10.1, 'APL789');

INSERT INTO mecanicos VALUES
('MEC001', '12345678', 'Juan', 'Pérez', '1985-06-15', '098123456'),
('MEC002', '23456789', 'Ana', 'López', '1990-09-21', '098987654'),
('MEC003', '34567890', 'Luis', 'Rodríguez', '1982-12-01', '099111222'),
('MEC004', '45678901', 'Carla', 'Gómez', '1995-03-11', '099333444');

INSERT INTO mecGenerales VALUES ('MEC001');
INSERT INTO mecEspecialista VALUES ('MEC002'), ('MEC003'), ('MEC004');

INSERT INTO especialidades (especialidadDescripcion) VALUES
('Motor'), ('Electrónica'), ('Hidráulica'), ('Transmisión');

INSERT INTO mecEspecialista_Especialidad VALUES
(200, 'MEC002'),
(201, 'MEC002'),
(202, 'MEC003'),
(200, 'MEC004'),
(203, 'MEC004');

INSERT INTO repuestos VALUES
('VALVE', 50, 'Válvula de escape'),
('FILTR', 30, 'Filtro de aceite'),
('TUBHH', 40, 'Tubería hidráulica'),
('BOMBA', 20, 'Bomba de aceite'),
('JUNTA', 25, 'Junta de goma');

INSERT INTO procedenciaRepuestos VALUES
('VALVE', 'Alemania'),
('FILTR', 'EEUU'),
('TUBHH', 'Japón'),
('BOMBA', 'Brasil'),
('JUNTA', 'China');

INSERT INTO repuestoCompatible VALUES
('VALVE', 'FILTR'),
('VALVE', 'BOMBA'),
('TUBHH', 'JUNTA');

INSERT INTO mantenimientos VALUES 
('MEC001', 100, '2025-01-10', '2025-01-15', '08:00', '14:00'),
('MEC001', 101, '2025-04-01', '2025-04-03', '09:00', '13:00'),
('MEC001', 102, '2025-06-25', NULL, '10:00', NULL),  -- NUEVO mantenimiento
('MEC002', 100, '2025-06-01', '2025-06-05', '10:00', '16:00'),
('MEC002', 103, '2025-06-15', NULL, '08:00', NULL),
('MEC003', 102, '2025-05-20', '2025-05-25', '07:00', '12:00'),
('MEC003', 100, '2025-06-20', NULL, '09:00', NULL);

INSERT INTO mantenimientoRepuestos VALUES
('MEC001', 100, 'VALVE', 2),
('MEC001', 100, 'FILTR', 1),
('MEC001', 101, 'TUBHH', 1),
('MEC002', 100, 'VALVE', 1),
('MEC003', 102, 'JUNTA', 3),
('MEC003', 100, 'VALVE', 1);

INSERT INTO registros VALUES
('MEC001', 100, '2025-01-10', 1, 'Cambio de válvula'),
('MEC001', 100, '2025-01-10', 2, 'Revisión general'),
('MEC001', 101, '2025-04-01', 1, 'Limpieza de motor'),
('MEC001', 101, '2025-04-01', 2, 'Cambio de válvula'),
('MEC002', 100, '2025-06-01', 1, 'Ajuste hidráulico'),
('MEC002', 100, '2025-06-01', 2, 'Cambio de válvula'),
('MEC003', 102, '2025-05-20', 1, 'Cambio de válvula'),
('MEC003', 100, '2025-06-20', 1, 'Cambio de válvula');

