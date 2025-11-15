namespace Presentacion
{
    // Clase principal de la aplicación
    internal static class Program
    {
        // Punto de entrada principal de la aplicación
        [STAThread] // Indica que la aplicación usa el modelo de subprocesos STA (Single Thread Apartment), necesario para Windows Forms
        static void Main()
        {
            // Inicializa la configuración de la aplicación (colores, DPI, estilos, etc.)
            ApplicationConfiguration.Initialize();

            // Ejecuta el formulario de inicio de sesión como ventana principal
            Application.Run(new Forms.FrmLogin());
        }
    }
}
