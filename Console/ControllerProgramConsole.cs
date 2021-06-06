using Controller;

namespace Console
{
    /// <summary>
    /// Управляющий контроллер Console
    /// </summary>
    public class ControllerProgramConsole : ControllerProgram
    {
        /// <summary>
        /// Создание управляющего контроллера
        /// </summary>
        public ControllerProgramConsole()
        {
            ControllerFactoryConsole factory = new ControllerFactoryConsole(this);
            _controllerMenuState = factory.CreateControllerMenu();
            _controllerGameState = factory.CreateControllerGame();
            _controllerRecordsTableState = factory.CreateControllerRecordsTable();
            _controllerRecordAdderState = factory.CreateControllerRecordAdder();
            _controllerHelpState = factory.CreateControllerHelp();

            _controllerState = _controllerMenuState;

            StartControllerState();
        }
    }
}
