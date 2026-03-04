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