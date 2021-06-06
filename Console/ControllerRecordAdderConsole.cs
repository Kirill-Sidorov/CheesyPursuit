using Controller;
using Model;
using System;

namespace Console
{
    /// <summary>
    /// Контроллер-состояние добавления нового рекорда Console
    /// </summary>
    public class ControllerRecordAdderConsole : ControllerRecordAdderState
    {
        /// <summary>
        /// Создание контроллера-состояние добавления нового рекорда Console
        /// </summary>
        /// <param name="parControllerProgram">Управляющий контроллер</param>
        /// <param name="parModelRecords">Модель рекордов</param>
        public ControllerRecordAdderConsole(ControllerProgram parControllerProgram, ModelRecords parModelRecords) : base(parControllerProgram, parModelRecords)
        {
        }

        public override void Start()
        {
            _viewRecordAdder.Show();
            RunLoopHandlerKeyDownRecordAdderConsole();
        }

        public override void Stop()
        {
            _viewRecordAdder.Close();
        }

        /// <summary>
        /// Запустить цикл обработки нажатия на кнопки клавиатуры
        /// </summary>
        private void RunLoopHandlerKeyDownRecordAdderConsole()
        {
            bool isHandleKeyDownRecordAdder = true;
            do
            {
                string name = System.Console.ReadLine();
                if (name != "")
                {
                    isHandleKeyDownRecordAdder = false;
                    int gamePoints = ((ModelGame)(ControllerProgram.ControllerGameState.Model)).NumberGamePoints;
                    _modelRecords.ListRecords.Add(new Model.GameClasses.Record(name, gamePoints));
                    _modelRecords.WriteToFile();
                    ChangeOnControllerMenuState();
                }
            } while (isHandleKeyDownRecordAdder);
        }
    }
}
