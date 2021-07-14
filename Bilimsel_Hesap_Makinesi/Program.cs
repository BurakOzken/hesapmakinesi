using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Modern_Hesap_Makinesi
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Modern_Hesap_Makinesi());
        }
    }
}
 