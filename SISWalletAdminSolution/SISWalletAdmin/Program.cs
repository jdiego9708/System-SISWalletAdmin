using CapaPresentacion.Formularios.FormsPrincipales;
using System;
using System.Windows.Forms;

namespace SISWalletAdmin
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzAwNzg4QDMxMzgyZTMyMmUzMGlYYmQvSkx5WEthZXoveEo2M2dYMXZXNHhvZDAzWUxNSXlla21GVnZxVTg9");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmIniciarSesion
            {
                WindowState = FormWindowState.Normal,
                StartPosition = FormStartPosition.CenterScreen
            });
        }
    }
}
