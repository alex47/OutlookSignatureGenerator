using System;
using System.Windows.Forms;

namespace SignatureGeneratorProgram
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

            //continentsForm.ShowDialog();
            //userDataSheetForm.ShowDialog();

            Application.Run(new FormWizard());
            //Application.Run(new FormUserDataSheet());
            //Application.Run(new FormContinentSelection());
        }
    }
}
