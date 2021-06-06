using Model;
using View;

namespace Controller
{
    /// <summary>
    /// Контроллер-состояние игрового процесса
    /// </summary>
    public abstract class ControllerGameState : IControllerState
    {
        /// <summary>
        /// Модель игрового процесса
        /// </summary>
        protected ModelGame _modelGame;

        /// <summary>
        /// Представление игрового процесса
        /// </summary>
        protected ViewGame _viewGame;

        /// <summary>
        /// Управляющий контроллер
        /// </summary>
        private ControllerProgram _controllerProgram;

        public IModel Model => _modelGame;

        public ControllerProgram ControllerProgram => _controllerProgram;

        /// <summary>
        /// Создание контроллера-состояния игрового процесса
        /// </summary>
        /// <param name="parControllerProgram">Управляющий контроллер</param>
        public ControllerGameState(ControllerProgram parControllerProgram)
        {
            _controllerProgram = parControllerProgram;
            _modelGame = new ModelGame();
        }

        /// <summary>
        /// Изменить на состояние добавления нового рекорда
        /// </summary>
        protected void ChangeOnControllerRecordAdderState()
        {
            ControllerProgram.ChangeState(ControllerProgram.ControllerRecordAdderState);
        }

        public abstract void Start();

        public abstract void Stop();

        public void SetView(IView parView)
        {
            _viewGame = (ViewGame)parView;
        }
    }
}
