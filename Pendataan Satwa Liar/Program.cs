using Pendataan_Satwa_Liar.Controller;
using Pendataan_Satwa_Liar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pendataan_Satwa_Liar
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var login = new LoginForm();
            var register = new Register();
            var auth = new AuthController(login, register);

            Application.Run(login);
        }

    }

}
