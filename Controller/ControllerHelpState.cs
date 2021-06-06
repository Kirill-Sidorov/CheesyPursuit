using Model;
using View;

namespace Controller
{
    /// <summary>
    /// Контроллер-состояние справки
    /// </summary>
    public abstract class ControllerHelpState : IControllerState
    {
        /// <summary>
        /// Модель справки
        /// </summary>
        protected ModelHelp _modelHelp;

        /// <summary>
        /// Представление справки
        /// </summary>
        protected ViewHelp _viewHelp;

        /// <summary>
        /// Управляющий контроллер
        /// </summary>
        private ControllerProgram _controllerProgram;

        public IModel Model => _modelHelp;

        public ControllerProgram ControllerProgram => _controllerProgram;

        /// <summary>
        /// Создание контроллера-состояния справки
        /// </summary>
        /// <param name="parControllerProgram">Управляющий контроллер</param>
        public ControllerHelpState(ControllerProgram parControllerProgram)
        {
            _controllerProgram = parControllerProgram;
            _modelHelp = new ModelHelp();
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
            _viewHelp = (ViewHelp)parView;
        }

        public abstract void Start();
        public abstract void Stop();
    }
}
