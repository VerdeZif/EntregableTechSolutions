------------------------------------------------------------
-- 1) CREAR BASE DE DATOS
------------------------------------------------------------
IF DB_ID('TechSolutionsDB') IS NOT NULL
    ALTER DATABASE TechSolutionsDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE IF EXISTS TechSolutionsDB;
GO

CREATE DATABASE TechSolutionsDB;
GO

USE TechSolutionsDB;
GO

------------------------------------------------------------
-- 2) TABLAS
------------------------------------------------------------

-- ROLES
CREATE TABLE Roles(
    RoleId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL
);

-- USUARIOS
CREATE TABLE Usuarios(
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(200) NOT NULL,
    NombreCompleto NVARCHAR(100) NOT NULL,
    FotoPerfil VARBINARY(MAX) NULL,
    RoleId INT NOT NULL,
    CONSTRAINT FK_Usuarios_Roles FOREIGN KEY(RoleId) REFERENCES Roles(RoleId)
);

-- CLIENTES (AHORA ASOCIADO A USUARIO)
CREATE TABLE Clientes(
    ClienteId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(100),
    Telefono NVARCHAR(20),
    Direccion NVARCHAR(200),
    Foto VARBINARY(MAX) NULL,
    CONSTRAINT FK_Clientes_Usuarios FOREIGN KEY(UserId) REFERENCES Usuarios(UserId)
);

-- PRODUCTOS
CREATE TABLE Productos(
    ProductoId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(200),
    Precio DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL,
    Imagen VARBINARY(MAX) NULL
);

-- VENTAS
CREATE TABLE Ventas(
    VentaId INT IDENTITY(1,1) PRIMARY KEY,
    ClienteId INT NOT NULL,
    UserId INT NOT NULL,
    Fecha DATETIME NOT NULL,
    Total DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_Ventas_Clientes FOREIGN KEY(ClienteId) REFERENCES Clientes(ClienteId),
    CONSTRAINT FK_Ventas_Usuarios FOREIGN KEY(UserId) REFERENCES Usuarios(UserId)
);

-- DETALLE DE VENTA
CREATE TABLE DetalleVenta(
    DetalleId INT IDENTITY(1,1) PRIMARY KEY,
    VentaId INT NOT NULL,
    ProductoId INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_DetalleVenta_Ventas FOREIGN KEY(VentaId) REFERENCES Ventas(VentaId),
    CONSTRAINT FK_DetalleVenta_Productos FOREIGN KEY(ProductoId) REFERENCES Productos(ProductoId)
);

------------------------------------------------------------
-- 3) ROLES
------------------------------------------------------------
INSERT INTO Roles (Nombre) VALUES ('Administrador'), ('Vendedor'), ('Cliente');

------------------------------------------------------------
-- 4) ADMIN (password = admin123)
------------------------------------------------------------
INSERT INTO Usuarios (Username, PasswordHash, NombreCompleto, RoleId)
VALUES (
    'admin',
    CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256', 'admin123'), 2),
    'Administrador General',
    1
);

------------------------------------------------------------
-- 5) CARGA MASIVA DE CLIENTES Y SUS USUARIOS
------------------------------------------------------------
DECLARE @i INT = 1;
WHILE @i <= 100
BEGIN
    DECLARE @Username NVARCHAR(50) = 'cliente' + CAST(@i AS NVARCHAR);
    DECLARE @UserId INT;

    INSERT INTO Usuarios (Username, PasswordHash, NombreCompleto, RoleId)
    VALUES (
        @Username,
        CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256', 'cliente123'), 2),
        'Cliente ' + CAST(@i AS NVARCHAR),
        3
    );

    SET @UserId = SCOPE_IDENTITY();

    INSERT INTO Clientes (UserId, Nombre, Correo, Telefono, Direccion)
    VALUES (
        @UserId,
        'Cliente ' + CAST(@i AS NVARCHAR),
        'cliente' + CAST(@i AS NVARCHAR) + '@mail.com',
        '999999999',
        'Direcci�n ' + CAST(@i AS NVARCHAR)
    );

    SET @i += 1;
END

------------------------------------------------------------
-- 6) PRODUCTOS
------------------------------------------------------------
SET @i = 1;
WHILE @i <= 50
BEGIN
    INSERT INTO Productos (Nombre, Descripcion, Precio, Stock)
    VALUES ('Producto ' + CAST(@i AS NVARCHAR),
            'Descripci�n Producto ' + CAST(@i AS NVARCHAR),
            ROUND((RAND()*50)+5,2),
            40);
    SET @i += 1;
END

------------------------------------------------------------
-- 7) TYPE TABLE PARA DETALLE DE VENTA
------------------------------------------------------------
CREATE TYPE TVP_DetalleVenta AS TABLE(
    ProductoId INT,
    Cantidad INT,
    PrecioUnitario DECIMAL(18,2)
);
GO

------------------------------------------------------------
-- 8) PROCEDIMIENTO PARA REGISTRAR VENTA
------------------------------------------------------------
CREATE PROCEDURE sp_RegistrarVenta
(
    @UserId INT,
    @ClienteId INT,
    @Total DECIMAL(18,2),
    @Detalle TVP_DetalleVenta READONLY
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM Clientes WHERE ClienteId = @ClienteId)
        BEGIN
            RAISERROR('Cliente no existe.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE UserId = @UserId)
        BEGIN
            RAISERROR('Usuario no existe.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        INSERT INTO Ventas (ClienteId, UserId, Fecha, Total)
        VALUES (@ClienteId, @UserId, GETDATE(), @Total);

        DECLARE @VentaId INT = SCOPE_IDENTITY();

        INSERT INTO DetalleVenta (VentaId, ProductoId, Cantidad, PrecioUnitario)
        SELECT @VentaId, ProductoId, Cantidad, PrecioUnitario
        FROM @Detalle;


        --Esto aumente
        -- Descontar stock
        UPDATE P
        SET P.Stock = P.Stock - D.Cantidad
        FROM Productos P
        INNER JOIN @Detalle D ON P.ProductoId = D.ProductoId;

        COMMIT TRANSACTION;

        SELECT @VentaId AS VentaId;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO
---------------------------------------------------------
--9) Procedimiento para obtener ventas filtradas
---------------------------------------------------------
CREATE PROCEDURE sp_ObtenerVentasFiltradas
(
    @FechaInicio DATETIME = NULL,
    @FechaFin DATETIME = NULL,
    @ClienteId INT = NULL,
    @VendedorId INT = NULL,
    @TotalMin DECIMAL(18,2) = NULL,
    @TotalMax DECIMAL(18,2) = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        V.VentaId,
        C.Nombre AS NombreCliente,
        U.NombreCompleto AS NombreVendedor,
        V.Fecha,
        V.Total
    FROM Ventas V
    INNER JOIN Clientes C ON V.ClienteId = C.ClienteId
    INNER JOIN Usuarios U ON V.UserId = U.UserId
    WHERE
        (@FechaInicio IS NULL OR V.Fecha >= @FechaInicio)
        AND (@FechaFin IS NULL OR V.Fecha <= @FechaFin)
        AND (@ClienteId IS NULL OR V.ClienteId = @ClienteId)
        AND (@VendedorId IS NULL OR V.UserId = @VendedorId)
        AND (@TotalMin IS NULL OR V.Total >= @TotalMin)
        AND (@TotalMax IS NULL OR V.Total <= @TotalMax)
    ORDER BY V.Fecha DESC;
END;
GO

------------------------------------------------------------
-- 10) REPORTES MENSUALES POR VENDEDOR, CLIENTE Y PRODUCTO
------------------------------------------------------------

-- Reporte por Vendedor
CREATE PROCEDURE sp_ReporteMensualPorVendedor
    @Mes INT,
    @Anio INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        U.NombreCompleto AS Vendedor,
        COUNT(V.VentaId) AS CantidadVentas,
        SUM(V.Total) AS TotalVendido
    FROM Ventas V
    INNER JOIN Usuarios U ON V.UserId = U.UserId
    WHERE MONTH(V.Fecha) = @Mes AND YEAR(V.Fecha) = @Anio
    GROUP BY U.NombreCompleto
    ORDER BY TotalVendido DESC;
END;
GO

-- Reporte por Cliente
CREATE PROCEDURE sp_ReporteMensualPorCliente
    @Mes INT,
    @Anio INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        C.Nombre AS Cliente,
        COUNT(V.VentaId) AS ComprasRealizadas,
        SUM(V.Total) AS MontoTotal
    FROM Ventas V
    INNER JOIN Clientes C ON V.ClienteId = C.ClienteId
    WHERE MONTH(V.Fecha) = @Mes AND YEAR(V.Fecha) = @Anio
    GROUP BY C.Nombre
    ORDER BY MontoTotal DESC;
END;
GO

-- Reporte por Producto
CREATE PROCEDURE sp_ReporteMensualPorProducto
    @Mes INT,
    @Anio INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        P.Nombre AS Producto,
        SUM(D.Cantidad) AS CantidadVendida,
        SUM(D.Cantidad * D.PrecioUnitario) AS TotalGenerado
    FROM DetalleVenta D
    INNER JOIN Ventas V ON D.VentaId = V.VentaIdF
    INNER JOIN Productos P ON D.ProductoId = P.ProductoId
    WHERE MONTH(V.Fecha) = @Mes AND YEAR(V.Fecha) = @Anio
    GROUP BY P.Nombre
    ORDER BY CantidadVendida DESC;
END;
GO


Select * from Clientes;
Select * from Roles;
select * from Usuarios;
select * from Productos;
select * from Ventas;
select * from DetalleVenta;