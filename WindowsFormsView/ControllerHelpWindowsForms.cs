using Controller;
using System.Windows.Forms;

namespace WindowsForms
{
    /// <summary>
    /// Контроллер-состояние справки Windows Forms
    /// </summary>
    public class ControllerHelpWindowsForms : ControllerHelpState
    {
        /// <summary>
        /// Создание контроллера-состояние справки Windows Forms
        /// </summary>
        /// <param name="parControllerProgram">Управляющий контроллер</param>
        public ControllerHelpWindowsForms(ControllerProgram parControllerProgram) : base(parControllerProgram)
        {
        }

        public override void Start()
        {
            ((ViewHelpWindowsForms)_viewHelp).KeyDownViewHelp += ControllerHelpWindowsForms_KeyDown;
            _viewHelp.Show();
        }

        public override void Stop()
        {
            ((ViewHelpWindowsForms)_viewHelp).KeyDownViewHelp -= ControllerHelpWindowsForms_KeyDown;
            _viewHelp.Close();
        }

        /// <summary>
        /// Обработчик нажатия кнопки клавиатуры
        /// </summary>
        /// <param name="parE">KeyEventArgs</param>
        private void ControllerHelpWindowsForms_KeyDown(KeyEventArgs parE)
        {
            if (parE.KeyData == Keys.Escape)
            {
                ChangeOnControllerMenuState();
            }
        }
    }
}
