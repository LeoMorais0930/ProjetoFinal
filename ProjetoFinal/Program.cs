using System;
using System.Windows.Forms;

namespace ProjetoFinal
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicializar o formul�rio Inicio
            Application.Run(new Inicio());
        }
    }
}
