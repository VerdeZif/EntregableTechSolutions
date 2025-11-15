# TechSolutions

## Descripción
TechSolutions es un sistema de gestión integral para ventas, clientes, productos y reportes. Está diseñado con una arquitectura en capas que facilita la mantenibilidad, escalabilidad y seguridad.

El sistema permite:
- Registro y gestión de usuarios, clientes, productos y ventas.
- Gestión de cuotas y pagos.
- Generación de reportes mensuales por cliente, producto o vendedor.
- Seguridad y autenticación de usuarios.

---

## Arquitectura del Proyecto
El proyecto sigue un **modelo en capas**:

### 1. Datos (Datos/)
Contiene la interacción directa con la base de datos.

- **Database/**: Conexión y manejo de transacciones.
  - `ConexionDB.cs`: Configuración de la conexión a la base de datos.
  - `TransaccionHelper.cs`: Métodos auxiliares para transacciones.

- **Repositorio/**: Clases que interactúan con las tablas específicas de la base de datos.
  - `UsuarioDatos.cs`
  - `ClienteDatos.cs`
  - `ProductoDatos.cs`
  - `VentaDatos.cs`
  - `ReporteDatos.cs`
  - `ReporteVentaDatos.cs`

---

### 2. Entidad (Entidad/Models/)
Define los modelos y entidades que representan las tablas de la base de datos.

- `Rol.cs`
- `Usuario.cs`
- `Cliente.cs`
- `Producto.cs`
- `Venta.cs`
- `DetalleVenta.cs`
- `ReporteVenta.cs`

---

### 3. Negocio (Negocio/)
Contiene la lógica de negocio y servicios de seguridad.

- **Seguridad/**: Módulos de seguridad y autenticación.
  - `PasswordHasher.cs`: Manejo de contraseñas (hashing, verificación).
  - `AuthService.cs`: Servicio de autenticación de usuarios.

- **Servicios/**: Gestión de operaciones de negocio.
  - `UsuarioNegocio.cs`
  - `ClienteNegocio.cs`
  - `ProductoNegocio.cs`
  - `VentaNegocio.cs`
  - `ReporteNegocio.cs`
  - `ReporteVentaNegocio.cs`

---

### 4. Presentación (Presentacion/)
Contiene la interfaz de usuario y los formularios de Windows Forms.

- **Forms/**: Formularios principales del sistema.
  - `FrmClientes.cs`
  - `FrmEditarPerfilCliente.cs`
  - `FrmEditarPerfilVendedor.cs`
  - `FrmEditarPerfilAdminr.cs`
  - `FrmProductos.cs`
  - `FrmLogin.cs`
  - `FrmAdmin.cs`
  - `FrmRegistroClientes.cs`
  - `FrmRegistroProductos.cs`
  - `FrmRegistroVendedors.cs`
  - `FrmVentas.cs`
  - `FrmUsuarios.cs`
  - `FrmVemdedor.cs`
  - `FrmReportes.cs`

- **Reportes/**: Formularios para generar reportes específicos.
  - `FrmReporteClienteMensual.cs`
  - `FrmReporteProductoMensual.cs`
  - `FrmReporteVendedorMensual.cs`
  - `FrmReporteCVentaIndividuall.cs`

- `Program.cs`: Punto de entrada del sistema.

---

## Estructura de Carpetas
```
TechSolutions/
│
├── Datos/
│   ├── Database/
│   │   ├── ConexionDB.cs
│   │   └── TransaccionHelper.cs
│   └── Repositorio/
│       ├── UsuarioDatos.cs
│       ├── ClienteDatos.cs
│       ├── ProductoDatos.cs
│       ├── VentaDatos.cs
│       ├── ReporteDatos.cs
│       └── ReporteVentaDatos.cs
│
├── Entidad/
│   └── Models/
│       ├── Rol.cs
│       ├── Usuario.cs
│       ├── Cliente.cs
│       ├── Producto.cs
│       ├── Venta.cs
│       ├── DetalleVenta.cs
│       └── ReporteVenta.cs
│
├── Negocio/
│   ├── Seguridad/
│   │   ├── PasswordHasher.cs
│   │   └── AuthService.cs
│   └── Servicios/
│       ├── UsuarioNegocio.cs
│       ├── ClienteNegocio.cs
│       ├── ProductoNegocio.cs
│       ├── VentaNegocio.cs
│       ├── ReporteNegocio.cs
│       └── ReporteVentaNegocio.cs
│
└── Presentacion/
    ├── Forms/
    │   ├── FrmClientes.cs
    │   ├── FrmEditarPerfilCliente.cs
    │   ├── FrmEditarPerfilVendedor.cs
    │   ├── FrmEditarPerfilAdminr.cs
    │   ├── FrmProductos.cs
    │   ├── FrmLogin.cs
    │   ├── FrmAdmin.cs
    │   ├── FrmRegistroClientes.cs
    │   ├── FrmRegistroProductos.cs
    │   ├── FrmRegistroVendedors.cs
    │   ├── FrmVentas.cs
    │   ├── FrmUsuarios.cs
    │   ├── FrmVemdedor.cs
    │   └── FrmReportes.cs
    ├── Reportes/
    │   ├── FrmReporteClienteMensual.cs
    │   ├── FrmReporteProductoMensual.cs
    │   ├── FrmReporteVendedorMensual.cs
    │   └── FrmReporteCVentaIndividuall.cs
    └── Program.cs
```

---

## Instalación
1. Clonar el repositorio:
```bash
git clone <URL-del-repositorio>
```
2. Abrir el proyecto en Visual Studio.
3. Configurar la cadena de conexión en `ConexionDB.cs`.
4. Compilar y ejecutar la solución.

---

## Uso
- Iniciar sesión con un usuario registrado.
- Navegar mediante el menú lateral:
  - Ventana principal
  - Registro de clientes, productos y ventas
  - Gestión de usuarios
  - Consulta de ventas, cuotas y pagos
  - Reportes por cliente, producto o vendedor
- Exportar reportes a PDF desde la interfaz.

---

## Tecnologías
- C# con .NET Framework / .NET 6+
- Windows Forms
- SQL Server

---

## Licencia
Este proyecto es propiedad de TechSolutions. No distribuir sin autorización.