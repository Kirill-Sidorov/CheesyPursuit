using Controller;
using Model;
using System;

namespace Console
{
    /// <summary>
    /// Контроллер-состояние меню Console
    /// </summary>
    public class ControllerMenuConsole : ControllerMenuState
    {
        /// <summary>
        /// Создание контроллера-состояние меню Console
        /// </summary>
        /// <param name="parControllerProgram">Управляющий контроллер</param>
        public ControllerMenuConsole(ControllerProgram parControllerProgram) : base(parControllerProgram)
        {
            _modelMenu.Items[(int)MenuItemCode.GAME].Selected += ChangeOnControllerGameState;
            _modelMenu.Items[(int)MenuItemCode.RECORDS].Selected += ChangeOnControllerRecordsTableState;
            _modelMenu.Items[(int)MenuItemCode.HELP].Selected += ChangeOnControllerHelpState;
        }

        public override void Start()
        {
            _viewMenu.Show();
            RunLoopHandlerKeyDownMenuConsole();
        }

        public override void Stop()
        {
            _viewMenu.Close();
        }

        /// <summary>
        /// Запустить цикл обработки нажатия на кнопки клавиатуры
        /// </summary>
        private void RunLoopHandlerKeyDownMenuConsole()
        {
            bool isHandleKeyDownMenu = true;
            do
            {
                ConsoleKeyInfo keyInfo = System.Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        _modelMenu.FocusNext();
                        break;
                    case ConsoleKey.UpArrow:
                        _modelMenu.FocusPrevious();
                        break;
                    case ConsoleKey.Enter:
                        isHandleKeyDownMenu = false;
                        _modelMenu.SelectFocusedItem();
                        break;
                }

            } while (isHandleKeyDownMenu);
        }
    }
}
