using Controller;
using Model;

namespace Console
{
    /// <summary>
    /// Фабрика контроллеров-состояний Console
    /// </summary>
    public class ControllerFactoryConsole : ControllerFactory
    {
        /// <summary>
        /// Создание фабрики контроллеров-состояний Console
        /// </summary>
        /// <param name="parControllerProgram">Управляющий контроллер</param>
        public ControllerFactoryConsole(ControllerProgram parControllerProgram) : base(parControllerProgram)
        {
        }

        /// <summary>
        /// Создать контроллер-состояние игрового процесса
        /// </summary>
        /// <returns>Контроллер-состояние</returns>
        public override IControllerState CreateControllerGame()
        {
            ControllerGameConsole controllerGameState = new ControllerGameConsole(_controllerProgram);

            ModelGame modelGame = (ModelGame)controllerGameState.Model;
            controllerGameState.SetView(new ViewGameConsole(modelGame));

            return controllerGameState;
        }

        /// <summary>
        /// Создать контроллер-состояние справки
        /// </summary>
        /// <returns>Контроллер-состояние</returns>
        public override IControllerState CreateControllerHelp()
        {
            ControllerHelpConsole controllerHelpState = new ControllerHelpConsole(_controllerProgram);

            ModelHelp modelHelp = (ModelHelp)controllerHelpState.Model;
            controllerHelpState.SetView(new ViewHelpConsole(modelHelp));

            return controllerHelpState;
        }

        /// <summary>
        /// Создать контроллер-состояние меню
        /// </summary>
        /// <returns>Контроллер-состояние</returns>
        public override IControllerState CreateControllerMenu()
        {
            ControllerMenuConsole cotrollerMenuState = new ControllerMenuConsole(_controllerProgram);

            ModelMenu modelMenu = (ModelMenu)cotrollerMenuState.Model;
            cotrollerMenuState.SetView(new ViewMenuConsole(modelMenu));

            return cotrollerMenuState;
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

            ControllerRecordAdderConsole controllerRecordAdderState = new ControllerRecordAdderConsole(_controllerProgram, _modelRecords);

            controllerRecordAdderState.SetView(new ViewRecordAdderConsole(_modelRecords));

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

            ControllerRecordsTableConsole controllerRecordsTableState = new ControllerRecordsTableConsole(_controllerProgram, _modelRecords);

            controllerRecordsTableState.SetView(new ViewRecordsTableConsole(_modelRecords));

            return controllerRecordsTableState;
        }
    }
}
