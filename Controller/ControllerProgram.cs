namespace Controller
{
    /// <summary>
    /// Управляющий класс контроллер, содержащий контроллеры-состояния программы
    /// </summary>
    public abstract class ControllerProgram
    {
        /// <summary>
        /// Контроллер-состояние игрового процесса
        /// </summary>
        protected IControllerState _controllerGameState;

        /// <summary>
        /// Контроллер-состояние меню игры
        /// </summary>
        protected IControllerState _controllerMenuState;

        /// <summary>
        /// Контроллер-состояние справки игры
        /// </summary>
        protected IControllerState _controllerHelpState;

        /// <summary>
        /// Контроллер-состояние добавления нового рекорда
        /// </summary>
        protected IControllerState _controllerRecordAdderState;

        /// <summary>
        /// Контроллер-состояние таблицы рекордов
        /// </summary>
        protected IControllerState _controllerRecordsTableState;

        /// <summary>
        /// Текущее состояние контроллера
        /// </summary>
        protected IControllerState _controllerState;

        /// <summary>
        /// Контроллер-состояние игрового процесса
        /// </summary>
        public IControllerState ControllerGameState => _controllerGameState;

        /// <summary>
        /// Контроллер-состояние меню игры
        /// </summary>
        public IControllerState ControllerMenuState => _controllerMenuState;

        /// <summary>
        /// Контроллер-состояние справки игры
        /// </summary>
        public IControllerState ControllerHelpState => _controllerHelpState;

        /// <summary>
        /// Контроллер-состояние добавления нового рекорда
        /// </summary>
        public IControllerState ControllerRecordAdderState => _controllerRecordAdderState;

        /// <summary>
        /// Контроллер-состояние таблицы рекордов
        /// </summary>
        public IControllerState ControllerRecordsTableState => _controllerRecordsTableState;

        /// <summary>
        /// Изменить состояние
        /// </summary>
        /// <param name="parState">Новое состояние</param>
        public void ChangeState(IControllerState parState)
        {
            StopControllerState();
            _controllerState = parState;
            StartControllerState();
        }

        /// <summary>
        /// Запустить контроллер-состояние
        /// </summary>
        protected void StartControllerState()
        {
            _controllerState.Start();
        }

        /// <summary>
        /// Остановить контроллер-состояние
        /// </summary>
        protected void StopControllerState()
        {
            _controllerState.Stop();
        }
    }
}
