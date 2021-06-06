using Model;

namespace Controller
{
    /// <summary>
    /// Фабрика создания контроллеров-состояний
    /// </summary>
    public abstract class ControllerFactory
    {
        /// <summary>
        /// Управляющий контроллер
        /// </summary>
        protected ControllerProgram _controllerProgram;

        /// <summary>
        /// Объект модели рекордов,
        /// используемый в нескольких контроллерах
        /// </summary>
        protected ModelRecords _modelRecords;

        /// <summary>
        /// Создание фабрики контроллеров-состояний
        /// </summary>
        /// <param name="parControllerProgram">Управляющий контроллер</param>
        public ControllerFactory(ControllerProgram parControllerProgram)
        {
            _controllerProgram = parControllerProgram;
        }

        /// <summary>
        /// Создать контроллер-состояние игрового процесса 
        /// </summary>
        /// <returns>Контроллер-состояние</returns>
        public abstract IControllerState CreateControllerGame();

        /// <summary>
        /// Создать контроллер-состояние меню
        /// </summary>
        /// <returns>Контроллер-состояние</returns>
        public abstract IControllerState CreateControllerMenu();

        /// <summary>
        /// Создать контроллер-состояние справки
        /// </summary>
        /// <returns>Контроллер-состояние</returns>
        public abstract IControllerState CreateControllerHelp();

        /// <summary>
        /// Создать контроллер-состояние добавления нового рекорда
        /// </summary>
        /// <returns>Контроллер-состояние</returns>
        public abstract IControllerState CreateControllerRecordAdder();

        /// <summary>
        /// Создать контроллер-состояние таблицы рекордов
        /// </summary>
        /// <returns>Контроллер-состояние</returns>
        public abstract IControllerState CreateControllerRecordsTable();
    }
}
