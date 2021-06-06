using System.Windows.Forms;

namespace WindowsForms
{
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Запустить программу
        /// </summary>
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            new ControllerProgramWindowsForms();
        }
    }
}
