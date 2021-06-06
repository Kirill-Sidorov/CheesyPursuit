using Controller;
using System;

namespace Console
{
    /// <summary>
    /// Контроллер-состояние справки Console
    /// </summary>
    public class ControllerHelpConsole : ControllerHelpState
    {
        /// <summary>
        /// Создание контроллера-состояние справки Console
        /// </summary>
        /// <param name="parControllerProgram">Управляющий контроллер</param>
        public ControllerHelpConsole(ControllerProgram parControllerProgram) : base(parControllerProgram)
        {
        }

        public override void Start()
        {
            _viewHelp.Show();
            RunLoopHandlerKeyDownHelpConsole();
        }

        public override void Stop()
        {
            _viewHelp.Close();
        }

        /// <summary>
        /// Запустить цикл обработки нажатия на кнопки клавиатуры
        /// </summary>
        private void RunLoopHandlerKeyDownHelpConsole()
        {
            bool isHandleKeyDownHelp = true;
            do
            {
                ConsoleKeyInfo keyInfo = System.Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isHandleKeyDownHelp = false;
                    ChangeOnControllerMenuState();
                }

            } while (isHandleKeyDownHelp);
        }
    }
}
