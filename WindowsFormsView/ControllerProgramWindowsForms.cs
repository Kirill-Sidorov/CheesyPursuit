using Controller;

namespace WindowsForms
{
    /// <summary>
    /// Управляющий контроллер Windows Forms
    /// </summary>
    public class ControllerProgramWindowsForms : ControllerProgram
    {
        /// <summary>
        /// Создание управляющего контроллера
        /// </summary>
        public ControllerProgramWindowsForms()
        {
            ControllerFactoryWindowsForms factory = new ControllerFactoryWindowsForms(this);

            _controllerMenuState = factory.CreateControllerMenu();
            _controllerGameState = factory.CreateControllerGame();
            _controllerHelpState = factory.CreateControllerHelp();
            _controllerRecordAdderState = factory.CreateControllerRecordAdder();
            _controllerRecordsTableState = factory.CreateControllerRecordsTable();

            _controllerState = _controllerMenuState;

            StartControllerState();
        }
    }
}
