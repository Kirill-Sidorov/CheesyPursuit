using Controller;
using Model;

namespace WindowsForms
{
    /// <summary>
    /// Фабрика контроллеров-состояний Windows Forms
    /// </summary>
    public class ControllerFactoryWindowsForms : ControllerFactory
    {
        /// <summary>
        /// Создание фабрики контроллеров-состояний WindowsForms
        /// </summary>
        /// <param name="parControllerProgram">Управляющий контроллер</param>
        public ControllerFactoryWindowsForms(ControllerProgram parControllerProgram) : base(parControllerProgram)
        {
        }

        /// <summary>
        /// Создать контроллер-состояние игрового процесса
        /// </summary>
        /// <returns>Контроллер-состояние</returns>
        public override IControllerState CreateControllerGame()
        {
            ControllerGameWindowsForms controllerGameState = new ControllerGameWindowsForms(_controllerProgram);

            ModelGame modelGame = (ModelGame)controllerGameState.Model;
            controllerGameState.SetView(new ViewGameWindowsForms(modelGame));

            return controllerGameState;
        }

        /// <summary>
        /// Создать контроллер-состояние меню
        /// </summary>
        /// <returns>Контроллер-состояние</returns>
        public override IControllerState CreateControllerMenu()
        {
            ControllerMenuWindowsForms controllerMenuState = new ControllerMenuWindowsForms(_controllerProgram);

            ModelMenu modelMenu = (ModelMenu)controllerMenuState.Model;
            controllerMenuState.SetView(new ViewMenuWindowsForms(modelMenu));

            return controllerMenuState;
        }

        /// <summary>
        /// Создать контроллер-состояние справки
        /// </summary>
        /// <returns>Контроллер-состояние</returns>
        public override IControllerState CreateControllerHelp()
        {
            ControllerHelpWindowsForms controllerHelpState = new ControllerHelpWindowsForms(_controllerProgram);

            ModelHelp modelHelp = (ModelHelp)controllerHelpState.Model;
            controllerHelpState.SetView(new ViewHelpWindowsForms(modelHelp));

            return controllerHelpState;
        }

        /// <summary>
        /// Создать контроллер-состояние добавления рекорда
        /// </summary>
        /// <returns>Контроллер-состояние</returns>
        public override IControllerState CreateControllerRecordAdder()
        {
            if (_modelRecords == null)
            {
                _modelRecords = new ModelRecords();
            }

            ControllerRecordAdderWindowsForms controllerRecordAdderState = new ControllerRecordAdderWindowsForms(_controllerProgram, _modelRecords);

            controllerRecordAdderState.SetView(new ViewRecordAdderWindowsForms(_modelRecords));

            return controllerRecordAdderState;
        }

        /// <summary>
        /// Создать контроллер-состояние таблицы рекордов
        /// </summary>
        /// <returns>Контроллер-состояние</returns>
        public override IControllerState CreateControllerRecordsTable()
        {
            if (_modelRecords == null)
            {
                _modelRecords = new ModelRecords();
            }

            ControllerRecordsTableWindowsForms controllerRecordsTableState = new ControllerRecordsTableWindowsForms(_controllerProgram, _modelRecords);

            controllerRecordsTableState.SetView(new ViewRecordsTableWindowsForms(_modelRecords));

            return controllerRecordsTableState;
        }
    }
}
