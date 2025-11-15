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










------------------------------------------------------------
CARGAR VENDEDORES, CLIENTES Y PRODUCTOS REALES
------------------------------------------------------------
INSERT INTO Usuarios (Username, PasswordHash, NombreCompleto, RoleId)
VALUES 
('jlopez', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256', 'vendedor123'), 2), 'Juan López', 2),
('mramirez', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256', 'vendedor123'), 2), 'María Ramírez', 2),
('cfernandez', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256', 'vendedor123'), 2), 'Carlos Fernández', 2),
('lmartinez', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256', 'vendedor123'), 2), 'Laura Martínez', 2),
('arodriguez', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256', 'vendedor123'), 2), 'Andrés Rodríguez', 2),
('mmendoza', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Miguel Mendoza', 2),
('epalacios', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Elena Palacios', 2),
('fcornejo', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Francisco Cornejo', 2),
('lcuellar', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Lucero Cuéllar', 2),
('jdelgado', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Jhon Delgado', 2),
('pparedes', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Patricia Paredes', 2),
('rhuaman', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Renato Huamán', 2),
('ysalazar', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Yessica Salazar', 2),
('dcarpio', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Diego Carpio', 2),
('vmejia', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Vanessa Mejía', 2),
('jescobar', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Jair Escobar', 2),
('mvallejos', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Maricielo Vallejos', 2),
('kzamora', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Kevin Zamora', 2),
('dlozano', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Doris Lozano', 2),
('tfigueroa', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Teresa Figueroa', 2),
('arodas', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Alexis Rodas', 2),
('bgalvez', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Brenda Gálvez', 2),
('gsegura', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Gustavo Segura', 2),
('jhuerta', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Joel Huerta', 2),
('pmaldonado', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','vendedor123'),2), 'Paola Maldonado', 2);


------------------------------------------------------------
-- Clientes reales
------------------------------------------------------------
DECLARE @UserId INT;

-- Cliente 1
INSERT INTO Usuarios (Username, PasswordHash, NombreCompleto, RoleId)
VALUES ('cgarcia', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256', 'cliente123'), 2), 'Carlos García', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes (UserId, Nombre, Correo, Telefono, Direccion)
VALUES (@UserId, 'Carlos García', 'carlos.garcia@mail.com', '987654321', 'Av. Los Pinos 452');

-- Cliente 2
INSERT INTO Usuarios (Username, PasswordHash, NombreCompleto, RoleId)
VALUES ('mjimenez', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256', 'cliente123'), 2), 'Mariana Jiménez', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes (UserId, Nombre, Correo, Telefono, Direccion)
VALUES (@UserId, 'Mariana Jiménez', 'mariana.jimenez@mail.com', '986543210', 'Calle Las Flores 128');

-- Cliente 3
INSERT INTO Usuarios (Username, PasswordHash, NombreCompleto, RoleId)
VALUES ('dtorres', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256', 'cliente123'), 2), 'Daniel Torres', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes (UserId, Nombre, Correo, Telefono, Direccion)
VALUES (@UserId, 'Daniel Torres', 'daniel.torres@mail.com', '985001122', 'Jr. Lima 230');

-- Cliente 4
INSERT INTO Usuarios (Username, PasswordHash, NombreCompleto, RoleId)
VALUES ('sruiz', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256', 'cliente123'), 2), 'Sandra Ruiz', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes (UserId, Nombre, Correo, Telefono, Direccion)
VALUES (@UserId, 'Sandra Ruiz', 'sandra.ruiz@mail.com', '983221144', 'Av. El Sol 778');

-- Cliente 5
INSERT INTO Usuarios (Username, PasswordHash, NombreCompleto, RoleId)
VALUES ('jcastillo', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256', 'cliente123'), 2), 'Jorge Castillo', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes (UserId, Nombre, Correo, Telefono, Direccion)
VALUES (@UserId, 'Jorge Castillo', 'jorge.castillo@mail.com', '982334455', 'Calle Central 355');

-- Cliente 6
INSERT INTO Usuarios (Username, PasswordHash, NombreCompleto, RoleId)
VALUES ('pvera', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256', 'cliente123'), 2), 'Patricia Vera', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes (UserId, Nombre, Correo, Telefono, Direccion)
VALUES (@UserId, 'Patricia Vera', 'patricia.vera@mail.com', '981112233', 'Av. Los Álamos 909');

-- Cliente 7
INSERT INTO Usuarios (Username, PasswordHash, NombreCompleto, RoleId)
VALUES ('hvaldez', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256', 'cliente123'), 2), 'Héctor Valdez', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes (UserId, Nombre, Correo, Telefono, Direccion)
VALUES (@UserId, 'Héctor Valdez', 'hector.valdez@mail.com', '980224466', 'Calle Misti 621');

-- Cliente 8
INSERT INTO Usuarios (Username, PasswordHash, NombreCompleto, RoleId)
VALUES ('lquiroz', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256', 'cliente123'), 2), 'Lucía Quiróz', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes (UserId, Nombre, Correo, Telefono, Direccion)
VALUES (@UserId, 'Lucía Quiróz', 'lucia.quiroz@mail.com', '989112255', 'Av. Grau 144');

-- Cliente 9
INSERT INTO Usuarios (Username, PasswordHash, NombreCompleto, RoleId)
VALUES ('frojas', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256', 'cliente123'), 2), 'Fernando Rojas', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes (UserId, Nombre, Correo, Telefono, Direccion)
VALUES (@UserId, 'Fernando Rojas', 'fernando.rojas@mail.com', '987889900', 'Jr. Piura 923');

-- Cliente 10
INSERT INTO Usuarios (Username, PasswordHash, NombreCompleto, RoleId)
VALUES ('vnavarro', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256', 'cliente123'), 2), 'Valeria Navarro', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes (UserId, Nombre, Correo, Telefono, Direccion)
VALUES (@UserId, 'Valeria Navarro', 'valeria.navarro@mail.com', '986667788', 'Calle Libertad 505');

-- Cliente 11
INSERT INTO Usuarios (Username, PasswordHash, NombreCompleto, RoleId)
VALUES ('rsalinas', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Ricardo Salinas', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes (UserId, Nombre, Correo, Telefono, Direccion)
VALUES (@UserId, 'Ricardo Salinas', 'ricardo.salinas@mail.com', '987420315', 'Av. Miraflores 210');

-- Cliente 12
INSERT INTO Usuarios VALUES ('apinto', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Ana Pinto', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'Ana Pinto', 'ana.pinto@mail.com', '984500221', 'Calle Los Cedros 402');

-- Cliente 13
INSERT INTO Usuarios VALUES ('lgevara', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Luis Guevara', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'Luis Guevara', 'luis.gevara@mail.com', '988411520', 'Av. Primavera 190');

-- Cliente 14
INSERT INTO Usuarios VALUES ('msifuentes', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Marisol Sifuentes', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'Marisol Sifuentes', 'marisol.sifuentes@mail.com', '986221334', 'Calle Santa Rosa 505');

-- Cliente 15
INSERT INTO Usuarios VALUES ('ccoronel', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Cristian Coronel', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'Cristian Coronel', 'cristian.coronel@mail.com', '985667890', 'Av. Universitaria 345');

-- Cliente 16
INSERT INTO Usuarios VALUES ('fvalencia', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Fiorella Valencia', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'Fiorella Valencia', 'fiorella.valencia@mail.com', '982330112', 'Calle Los Olivos 130');

-- Cliente 17
INSERT INTO Usuarios VALUES ('hquispe', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Hernán Quispe', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'Hernán Quispe', 'hernan.quispe@mail.com', '981554432', 'Jr. Ayacucho 201');

-- Cliente 18
INSERT INTO Usuarios VALUES ('vrobles', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Valeria Robles', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'Valeria Robles', 'valeria.robles@mail.com', '987210600', 'Av. Wilson 600');

-- Cliente 19
INSERT INTO Usuarios VALUES ('nchavez', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Nelson Chávez', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'Nelson Chávez', 'nelson.chavez@mail.com', '987995001', 'Calle Los Laureles 11');

-- Cliente 20
INSERT INTO Usuarios VALUES ('jzambrano', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Jenny Zambrano', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'Jenny Zambrano', 'jenny.zambrano@mail.com', '984118902', 'Av. Venezuela 320');

-- Cliente 21
INSERT INTO Usuarios VALUES ('agonzales', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Adriana Gonzales', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'Adriana Gonzales', 'adriana.g@mail.com', '982551901', 'Calle Cusco 70');

-- Cliente 22
INSERT INTO Usuarios VALUES ('rvasquez', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Renzo Vásquez', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'Renzo Vásquez', 'renzo.v@mail.com', '981332499', 'Jr. Arequipa 1021');

-- Cliente 23
INSERT INTO Usuarios VALUES ('bbermudez', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Brenda Bermúdez', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'Brenda Bermúdez', 'brenda.b@mail.com', '986004321', 'Av. La Marina 501');

-- Cliente 24
INSERT INTO Usuarios VALUES ('oserrano', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Omar Serrano', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'Omar Serrano', 'omar.serrano@mail.com', '981298700', 'Calle Inca Roca 88');

-- Cliente 25
INSERT INTO Usuarios VALUES ('hlagos', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Helena Lagos', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'Helena Lagos', 'helena.l@mail.com', '985432190', 'Av. Paseo Colón 412');

-- Cliente 26
INSERT INTO Usuarios VALUES ('jhuayta', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Jordy Huayta', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'Jordy Huayta', 'jordy.h@mail.com', '986633221', 'Urbanización Los Próceres 50');

-- Cliente 27
INSERT INTO Usuarios VALUES ('psalcedo', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Pamela Salcedo', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'Pamela Salcedo', 'pamela.s@mail.com', '984500772', 'Calle Lima 340');

-- Cliente 28
INSERT INTO Usuarios VALUES ('rponce', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Rolando Ponce', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'Rolando Ponce', 'rolando.ponce@mail.com', '983101900', 'Av. El Maestro 303');

-- Cliente 29
INSERT INTO Usuarios VALUES ('mgamarra', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'María Gamarra', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'María Gamarra', 'maria.gamarra@mail.com', '982771645', 'Av. Los Héroes 922');

-- Cliente 30
INSERT INTO Usuarios VALUES ('amoreno', CONVERT(NVARCHAR(200), HASHBYTES('SHA2_256','cliente123'),2), 'Alonso Moreno', 3);
SET @UserId = SCOPE_IDENTITY();
INSERT INTO Clientes VALUES (@UserId, 'Alonso Moreno', 'alonso.m@mail.com', '989220311', 'Calle Retablo 78');

------------------------------------------------------------
-- ProductoS
------------------------------------------------------------
INSERT INTO Productos (Nombre, Descripcion, Precio, Stock)
VALUES
('Laptop Lenovo ThinkPad E14', 'Intel i5 12th Gen, 16GB RAM, 512GB SSD', 3250, 25),
('Laptop HP Pavilion 15', 'AMD Ryzen 5, 8GB RAM, 512GB SSD', 2800, 30),
('Laptop ASUS TUF Gaming F15', 'Intel i7, RTX 3050, 16GB RAM', 4800, 15),
('Monitor LG 27" IPS 144Hz', 'Monitor gamer 144Hz, 1ms', 950, 40),
('Monitor Samsung Odyssey G5 32"', 'Curvo, 144Hz, 2K', 1600, 20),
('Mouse Logitech MX Master 3S', 'Mouse inalámbrico profesional', 350, 50),
('Mouse Redragon Cobra', 'RGB, 10000 DPI', 120, 100),
('Teclado Mecánico HyperX Alloy', 'Switch Red, RGB', 420, 60),
('Teclado Logitech K380', 'Bluetooth multi-dispositivo', 150, 70),
('SSD Samsung EVO 1TB', 'SSD interno 1TB NVMe', 420, 80),
('SSD Kingston NV2 500GB', 'SSD NVMe económico', 220, 70),
('Memoria RAM Corsair 16GB', 'DDR4 3200MHz', 250, 60),
('Memoria RAM Kingston Fury 8GB', 'DDR4 2666MHz', 140, 80),
('Placa Madre ASUS Prime B560M', 'Intel socket LGA1200', 550, 25),
('Fuente Corsair 650W', '80 Plus Bronze', 330, 35),
('Tarjeta de Video RTX 4060 8GB', 'Gigabyte Windforce', 1800, 10),
('Tarjeta de Video GTX 1650 4GB', 'NVIDIA', 850, 12),
('Router TP-Link AX1800', 'WiFi 6, doble banda', 280, 40),
('Router Mikrotik hap ac2', 'WiFi profesional', 350, 30),
('Smartphone Samsung S23', '128GB, Snapdragon 8 Gen 2', 3800, 20),
('Smartphone iPhone 13', '128GB, 6.1"', 4200, 15),
('Tablet iPad 9th Gen', '10.2", 64GB', 1450, 25),
('Tablet Samsung Galaxy A8', '10.4", 64GB', 900, 30),
('Impresora HP Ink Tank 315', 'Multifuncional', 650, 40),
('Impresora Epson EcoTank L3250', 'Wireless, tanque continuo', 850, 35),
('Audífonos Sony WH-1000XM5', 'Noise Canceling', 1500, 20),
('Audífonos JBL Tune 510BT', 'Bluetooth', 180, 80),
('Audífonos HyperX Cloud II', 'Gamer', 390, 40),
('Webcam Logitech C920', '1080p', 250, 50),
('Parlante JBL Charge 5', 'Bluetooth, resistente al agua', 500, 40),
('Parlante Xiaomi Mi Speaker', 'Bluetooth', 150, 50),
('Hub USB-C 7 en 1', 'HDMI, USB 3.0, SD', 140, 60),
('Cable HDMI 4K 2m', 'Alta velocidad', 30, 200),
('Cargador GaN 65W', 'USB-C PD', 120, 100),
('Power Bank Anker 20,000mAh', 'Carga rápida', 210, 60),
('Proyector Epson X05+', '3600 lúmenes', 1900, 15),
('Proyector Xiaomi Mi Smart', '1080p', 1400, 20),
('Smartwatch Amazfit GTR 3', 'GPS, AMOLED', 550, 35),
('Smartwatch Xiaomi Watch S1', 'AMOLED', 620, 25),
('Cámara de Seguridad Hikvision 1080p', 'Exterior resistente', 180, 70),
('Cámara IP TP-Link Tapo C200', 'Rotación 360°', 130, 120),
('Disco Duro Externo Seagate 2TB', 'USB 3.0', 260, 80),
('Disco Duro Externo WD 1TB', 'USB 3.0', 180, 90),
('Case Gamer NZXT H510', 'Tempered Glass', 370, 20),
('Cooler Master Hyper 212', 'Disipador de aire', 150, 40),
('Laptop MacBook Air M2', '8GB RAM, 256GB SSD', 4800, 10);


Select * from Clientes;
Select * from Roles;
select * from Usuarios;
select * from Productos;
select * from Ventas;
select * from DetalleVenta;
