using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
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

        public Usuarios Usuario { get; set; }

        public Turnos Turno { get; set; }

        public int Id_cobro { get; set; }

        public Cobros Cobro { get; set; }
    }
}
