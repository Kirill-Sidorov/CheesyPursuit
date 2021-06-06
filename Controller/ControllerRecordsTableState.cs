using Model;
using View;

namespace Controller
{
    /// <summary>
    /// Контроллер-состояние таблицы рекордов
    /// </summary>
    public abstract class ControllerRecordsTableState : IControllerState
    {
        /// <summary>
        /// Модель рекордов
        /// </summary>
        protected ModelRecords _modelRecords;

        /// <summary>
        /// Пердставление таблицы рекордов
        /// </summary>
        protected ViewRecord _viewRecordsTable;

        private ControllerProgram _controllerProgram;

        public IModel Model => _modelRecords;

        public ControllerProgram ControllerProgram => _controllerProgram;

        /// <summary>
        /// Создание контроллера-состояния таблицы рекордов
        /// </summary>
        /// <param name="parControllerProgram">Управляющий контроллер</param>
        /// <param name="parModelRecords">Модель рекордов</param>
        public ControllerRecordsTableState(ControllerProgram parControllerProgram, ModelRecords parModelRecords)
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
            _viewRecordsTable = (ViewRecord)parView;
        }

        public abstract void Start();

        public abstract void Stop();
    }
}
