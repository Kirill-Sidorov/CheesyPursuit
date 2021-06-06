using Controller;
using Model;
using System;

namespace Console
{
    /// <summary>
    /// Контроллер-состояние таблицы рекордов Console
    /// </summary>
    public class ControllerRecordsTableConsole : ControllerRecordsTableState
    {
        /// <summary>
        /// Создание контроллер-состояние таблицы рекордов Console
        /// </summary>
        /// <param name="parControllerProgram">Управляющий контроллер</param>
        /// <param name="parModelRecords">Модель рекордов</param>
        public ControllerRecordsTableConsole(ControllerProgram parControllerProgram, ModelRecords parModelRecords) : base(parControllerProgram, parModelRecords)
        {
        }

        public override void Start()
        {
            _viewRecordsTable.Show();
            RunLoopHandlerKeyDownRecordsTableConsole();
        }

        public override void Stop()
        {
            _viewRecordsTable.Close();
        }

        /// <summary>
        /// Запустить цикл обработки нажатия на кнопки клавиатуры
        /// </summary>
        private void RunLoopHandlerKeyDownRecordsTableConsole()
        {
            bool isHandleKeyDownRecordsTable = true;
            do
            {
                ConsoleKeyInfo keyInfo = System.Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isHandleKeyDownRecordsTable = false;
                    ChangeOnControllerMenuState();
                }

            } while (isHandleKeyDownRecordsTable);
        }
    }
}
