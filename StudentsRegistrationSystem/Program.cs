using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Students;
using StudentsRegistrationSystem;

namespace StudentsRegistrationSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Db.d._server = "localhost";
            Db.d._user = "root";
            Db.d._pw = "";
            Db.d._db = "students";
            Db.d.Connect();

            Main m = new Main();
            m.ShowDialog();
        }
    }
}
