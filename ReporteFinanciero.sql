Create database ReporteFinanciero

CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY,
    NombreCompleto VARCHAR(100),
    Correo VARCHAR(100),
    Telefono VARCHAR(20),
    Direccion VARCHAR(150),
    Garantia VARCHAR(100),
    Sueldo DECIMAL(10,2)
)


CREATE TABLE Prestamos (
    Id INT PRIMARY KEY IDENTITY,
    ClienteId INT,
    Monto DECIMAL(10,2),
    TiempoMeses INT,
    TasaInteres DECIMAL(5,2),
    InteresGenerado DECIMAL(10,2),
    MontoTotal DECIMAL(10,2),
    SaldoRestante DECIMAL(10,2),
    FechaInicio DATE,
    Estado VARCHAR(50),
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
)


CREATE TABLE Pagos (
    Id INT PRIMARY KEY IDENTITY,
    PrestamoId INT,
    FechaPago DATE,
    MontoAnterior DECIMAL(10,2),
    InteresPagado DECIMAL(10,2),
    MontoAbonado DECIMAL(10,2),
    NuevoSaldo DECIMAL(10,2),
    FOREIGN KEY (PrestamoId) REFERENCES Prestamos(Id)
)


CREATE TABLE Moras (
    Id INT PRIMARY KEY IDENTITY,
    PrestamoId INT,
    Fecha DATE,
    MontoMora DECIMAL(10,2),

    FOREIGN KEY (PrestamoId) REFERENCES Prestamos(Id)
)

--Clientes
INSERT INTO Clientes (NombreCompleto, Correo, Telefono, Direccion, Garantia, Sueldo) VALUES
('Juan Pérez', 'juanperez@gmail.com', '809-555-0001', 'Santo Domingo', '1 año', 25000.00),
('María López', 'marialopez@gmail.com', '809-555-0002', 'Santiago', '6 meses', 32000.50),
('Carlos Sánchez', 'carlos@gmail.com', '809-555-0003', 'La Vega', '1 año', 28000.75),
('Ana Rodríguez', 'ana@gmail.com', '809-555-0004', 'San Cristóbal', '2 años', 45000.00),
('Luis Gómez', 'luis@gmail.com', '809-555-0005', 'Puerto Plata', '1 año', 30000.00),
('Sofía Martínez', 'sofia@gmail.com', '809-555-0006', 'Bávaro', '6 meses', 27000.20),
('Pedro Ramírez', 'pedro@gmail.com', '809-555-0007', 'Higüey', '1 año', 35000.00),
('Lucía Fernández', 'lucia@gmail.com', '809-555-0008', 'San Pedro', '2 años', 40000.00),
('José Díaz', 'jose@gmail.com', '809-555-0009', 'Moca', '1 año', 29000.00),
('Elena Torres', 'elena@gmail.com', '809-555-0010', 'Baní', '6 meses', 26000.00),
('Miguel Herrera', 'miguel@gmail.com', '809-555-0011', 'Azua', '1 año', 31000.00),
('Carmen Vargas', 'carmen@gmail.com', '809-555-0012', 'Barahona', '2 años', 42000.00),
('Daniel Castillo', 'daniel@gmail.com', '809-555-0013', 'La Romana', '1 año', 33000.00),
('Patricia Reyes', 'patricia@gmail.com', '809-555-0014', 'San Juan', '6 meses', 24000.00),
('Jorge Medina', 'jorge@gmail.com', '809-555-0015', 'Monte Plata', '1 año', 28000.00),
('Laura Cruz', 'laura@gmail.com', '809-555-0016', 'Nagua', '2 años', 39000.00),
('Roberto Núñez', 'roberto@gmail.com', '809-555-0017', 'Dajabón', '1 año', 27000.00),
('Paula Santana', 'paula@gmail.com', '809-555-0018', 'Cotui', '6 meses', 25000.00),
('Andrés Peña', 'andres@gmail.com', '809-555-0019', 'Samaná', '1 año', 36000.00),
('Verónica Molina', 'veronica@gmail.com', '809-555-0020', 'Jarabacoa', '2 años', 41000.00);

--Prestamos
INSERT INTO Prestamos (ClienteId, Monto, TiempoMeses, TasaInteres, InteresGenerado, MontoTotal, SaldoRestante, FechaInicio, Estado) VALUES
(1, 10000.00, 12, 10.00, 1000.00, 11000.00, 8000.00, '2025-01-01', 'Activo'),
(2, 15000.00, 10, 12.00, 1800.00, 16800.00, 12000.00, '2025-02-01', 'Activo'),
(3, 8000.00, 8, 8.00, 640.00, 8640.00, 4000.00, '2025-01-15', 'Activo'),
(4, 20000.00, 24, 15.00, 3000.00, 23000.00, 20000.00, '2025-03-01', 'Pendiente'),
(5, 12000.00, 12, 10.00, 1200.00, 13200.00, 6000.00, '2025-02-10', 'Activo'),
(6, 9000.00, 6, 7.00, 630.00, 9630.00, 3000.00, '2025-01-20', 'Activo'),
(7, 18000.00, 18, 14.00, 2520.00, 20520.00, 15000.00, '2025-03-05', 'Pendiente'),
(8, 7000.00, 6, 9.00, 630.00, 7630.00, 2000.00, '2025-01-25', 'Activo'),
(9, 11000.00, 12, 11.00, 1210.00, 12210.00, 7000.00, '2025-02-15', 'Activo'),
(10, 5000.00, 5, 6.00, 300.00, 5300.00, 1000.00, '2025-01-10', 'Activo'),
(11, 16000.00, 16, 13.00, 2080.00, 18080.00, 14000.00, '2025-03-10', 'Pendiente'),
(12, 14000.00, 14, 12.00, 1680.00, 15680.00, 9000.00, '2025-02-20', 'Activo'),
(13, 13000.00, 13, 11.00, 1430.00, 14430.00, 8000.00, '2025-02-05', 'Activo'),
(14, 6000.00, 6, 7.50, 450.00, 6450.00, 2000.00, '2025-01-18', 'Activo'),
(15, 17000.00, 17, 14.00, 2380.00, 19380.00, 15000.00, '2025-03-12', 'Pendiente'),
(16, 7500.00, 7, 8.50, 637.50, 8137.50, 3000.00, '2025-01-22', 'Activo'),
(17, 9500.00, 9, 9.50, 902.50, 10402.50, 5000.00, '2025-02-12', 'Activo'),
(18, 21000.00, 21, 15.00, 3150.00, 24150.00, 20000.00, '2025-03-15', 'Pendiente'),
(19, 12500.00, 12, 10.50, 1312.50, 13812.50, 7000.00, '2025-02-25', 'Activo'),
(20, 3000.00, 3, 5.00, 150.00, 3150.00, 500.00, '2025-01-05', 'Activo');

--Pagos
INSERT INTO Pagos (PrestamoId, FechaPago, MontoAnterior, InteresPagado, MontoAbonado, NuevoSaldo) VALUES
(1, '2025-02-01', 11000.00, 100.00, 1000.00, 10000.00),
(2, '2025-03-01', 16800.00, 150.00, 1200.00, 15600.00),
(3, '2025-02-15', 8640.00, 80.00, 800.00, 7840.00),
(4, '2025-04-01', 23000.00, 200.00, 1500.00, 21500.00),
(5, '2025-03-10', 13200.00, 120.00, 1000.00, 12200.00),
(6, '2025-02-20', 9630.00, 90.00, 900.00, 8730.00),
(7, '2025-04-05', 20520.00, 180.00, 1500.00, 19020.00),
(8, '2025-02-25', 7630.00, 70.00, 700.00, 6930.00),
(9, '2025-03-15', 12210.00, 110.00, 1000.00, 11210.00),
(10, '2025-02-10', 5300.00, 50.00, 500.00, 4800.00),
(11, '2025-04-10', 18080.00, 160.00, 1400.00, 16680.00),
(12, '2025-03-20', 15680.00, 140.00, 1200.00, 14480.00),
(13, '2025-03-05', 14430.00, 130.00, 1100.00, 13330.00),
(14, '2025-02-18', 6450.00, 60.00, 600.00, 5850.00),
(15, '2025-04-12', 19380.00, 170.00, 1500.00, 17880.00),
(16, '2025-02-22', 8137.50, 75.00, 700.00, 7437.50),
(17, '2025-03-12', 10402.50, 95.00, 900.00, 9502.50),
(18, '2025-04-15', 24150.00, 210.00, 2000.00, 22150.00),
(19, '2025-03-25', 13812.50, 120.00, 1000.00, 12812.50),
(20, '2025-02-05', 3150.00, 30.00, 300.00, 2850.00);

--Moras
INSERT INTO Moras (PrestamoId, Fecha, MontoMora) VALUES
(1, '2025-03-05', 200.00),
(2, '2025-04-10', 350.00),
(3, '2025-03-20', 150.00),
(4, '2025-05-01', 500.00),
(5, '2025-04-15', 250.00),
(6, '2025-03-01', 100.00),
(7, '2025-05-10', 450.00),
(8, '2025-03-10', 120.00),
(9, '2025-04-01', 220.00),
(10, '2025-03-15', 80.00),
(11, '2025-05-20', 400.00),
(12, '2025-04-25', 300.00),
(13, '2025-04-05', 270.00),
(14, '2025-03-22', 90.00),
(15, '2025-05-25', 480.00),
(16, '2025-03-28', 130.00),
(17, '2025-04-12', 210.00),
(18, '2025-06-01', 550.00),
(19, '2025-04-30', 260.00),
(20, '2025-03-08', 70.00);