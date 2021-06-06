using Model;
using View;

namespace Controller
{
    /// <summary>
    /// Контроллер-состояние меню
    /// </summary>
    public abstract class ControllerMenuState : IControllerState
    {
        /// <summary>
        /// Модель меню
        /// </summary>
        protected ModelMenu _modelMenu;

        /// <summary>
        /// Представление меню
        /// </summary>
        protected ViewMenu _viewMenu;

        /// <summary>
        /// Управляющий контроллер
        /// </summary>
        private ControllerProgram _controllerProgram;

        public IModel Model => _modelMenu;

        public ControllerProgram ControllerProgram => _controllerProgram;

        /// <summary>
        /// Создание контроллера-состояния меню
        /// </summary>
        /// <param name="parControllerProgram">Управляющий контроллер</param>
        public ControllerMenuState(ControllerProgram parControllerProgram)
        {
            _controllerProgram = parControllerProgram;
            _modelMenu = new ModelMenu();
        }

        /// <summary>
        /// Изменить на состояние игрового процесса
        /// </summary>
        protected void ChangeOnControllerGameState()
        {
            ControllerProgram.ChangeState(ControllerProgram.ControllerGameState);
        }

        /// <summary>
        /// Изменить на состояние справки
        /// </summary>
        protected void ChangeOnControllerHelpState()
        {
            ControllerProgram.ChangeState(ControllerProgram.ControllerHelpState);
        }

        /// <summary>
        /// Изменить на состояние таблицы рекордов
        /// </summary>
        protected void ChangeOnControllerRecordsTableState()
        {
            ControllerProgram.ChangeState(ControllerProgram.ControllerRecordsTableState);
        }

        public abstract void Start();

        public abstract void Stop();

        public void SetView(IView parView)
        {
            _viewMenu = (ViewMenu)parView;
        }
    }
}
