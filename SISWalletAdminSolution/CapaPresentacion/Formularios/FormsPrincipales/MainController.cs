namespace CapaPresentacion.Formularios.FormsPrincipales
{
    using CapaEntidades;

    public class MainController
    {
        #region PATRON SINGLETON
        private static MainController instance;
        public static MainController GetInstance()
        {
            if (instance == null)
            {
                instance = new MainController();
                return instance;
            }

            return instance;
        }
        #endregion

        public FrmPrincipal FrmPrincipal { get; set; }

        public Usuarios Usuario { get; set; }
    }
}
