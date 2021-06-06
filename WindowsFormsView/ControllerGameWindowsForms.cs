using Controller;
using Model;
using System.Windows.Forms;

namespace WindowsForms
{
    /// <summary>
    /// Контроллер-состояние игрового процесса Windows Forms
    /// </summary>
    public class ControllerGameWindowsForms : ControllerGameState
    {
        /// <summary>
        /// Создание контроллера-состояние игрового процесса Windows Forms
        /// </summary>
        /// <param name="parControllerProgram">Управляющий контроллер</param>
        public ControllerGameWindowsForms(ControllerProgram parControllerProgram) : base(parControllerProgram)
        {
            _modelGame.CatManager.AtePlayerDelay += ChangeOnControllerRecordAdderState;
            _modelGame.CatManager.AtePlayerQuick += () => { ((ViewGameWindowsForms)_viewGame).KeyDownViewGame -= ControllerGameWindowsForms_KeyDown; };
        }

        public override void Start()
        {
            _modelGame.ResetAllGame();
            ((ViewGameWindowsForms)_viewGame).KeyDownViewGame += ControllerGameWindowsForms_KeyDown;
            _viewGame.Show();
        }

        public override void Stop()
        {
            _viewGame.Close();
        }

        /// <summary>
        /// Обработчик нажатия кнопки клавиатуры
        /// </summary>
        /// <param name="parE">KeyEventArgs</param>
        private void ControllerGameWindowsForms_KeyDown(KeyEventArgs parE)
        {
            switch (parE.KeyData)
            {
                case Keys.Down:
                    _modelGame.MovePlayer(Movement.DOWN);
                    break;
                case Keys.Up:
                    _modelGame.MovePlayer(Movement.UP);
                    break;
                case Keys.Right:
                    _modelGame.MovePlayer(Movement.RIGHT);
                    break;
                case Keys.Left:
                    _modelGame.MovePlayer(Movement.LEFT);
                    break;
            }
        }
    }
}
