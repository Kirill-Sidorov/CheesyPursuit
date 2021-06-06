using Model;
using View;

namespace Controller
{
    /// <summary>
    /// Контроллер-состояние добавления нового рекорда
    /// </summary>
    public abstract class ControllerRecordAdderState : IControllerState
    {
        /// <summary>
        /// Модель рекордов
        /// </summary>
        protected ModelRecords _modelRecords;

        /// <summary>
        /// Пердставление добавления нового рекорда
        /// </summary>
        protected ViewRecord _viewRecordAdder;

        private ControllerProgram _controllerProgram;

        public IModel Model => _modelRecords;

        public ControllerProgram ControllerProgram => _controllerProgram;

        /// <summary>
        /// Создание контроллера-состояния добавления нового рекорда
        /// </summary>
        /// <param name="parControllerProgram">Управляющий контроллер</param>
        /// <param name="parModelRecords">Модель рекордов</param>
        public ControllerRecordAdderState(ControllerProgram parControllerProgram, ModelRecords parModelRecords)
        {
            _controllerProgram = parControllerProgram;
            _modelRecords = parModelRecords;
        }

        /// <summary>
        /// Изменить на состояние меню
        /// </summary>
        protected void ChangeOnControllerMenuState()
        {
            ControllerProgram.ChangeState(ControllerProgram.ControllerMenuState);
        }

        public void SetView(IView parView)
        {
            _viewRecordAdder = (ViewRecord)parView;
        }

        public abstract void Start();

        public abstract void Stop();
    }
}
