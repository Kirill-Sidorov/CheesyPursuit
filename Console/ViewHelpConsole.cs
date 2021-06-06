using Model;
using View;

namespace Console
{
    /// <summary>
    /// Представление справки Console
    /// </summary>
    public class ViewHelpConsole : ViewHelp
    {
        /// <summary>
        /// Создание представления справки Console
        /// </summary>
        /// <param name="parModelHelp">Модель справки</param>
        public ViewHelpConsole(ModelHelp parModelHelp) : base(parModelHelp)
        {
        }

        public override void Show()
        {
            DrawHelp();
        }

        public override void Close()
        {
            ConsoleOutput.Clear();
        }

        /// <summary>
        /// Нарисовать справку 
        /// </summary>
        private void DrawHelp()
        {
            ConsoleOutput.Write(_modelHelp.Text, ViewResource.OFFSET_HELP, ViewResource.OFFSET_HELP, System.ConsoleColor.Yellow);
            ConsoleOutput.PrintOnConsole();
        }
    }
}
