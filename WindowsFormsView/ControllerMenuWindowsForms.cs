using Controller;
using Model;
using System.Windows.Forms;

namespace WindowsForms
{
    /// <summary>
    /// Контроллер-состояние меню Windows Forms
    /// </summary>
    public class ControllerMenuWindowsForms : ControllerMenuState
    {
        /// <summary>
        /// Создание контроллера-состояние меню Windows Forms
        /// </summary>
        /// <param name="parControllerProgram">Управляющий контроллер</param>
        public ControllerMenuWindowsForms(ControllerProgram parControllerProgram) : base(parControllerProgram)
        {
            _modelMenu.Items[(int)MenuItemCode.GAME].Selected += ChangeOnControllerGameState;
            _modelMenu.Items[(int)MenuItemCode.RECORDS].Selected += ChangeOnControllerRecordsTableState;
            _modelMenu.Items[(int)MenuItemCode.HELP].Selected += ChangeOnControllerHelpState;
            _modelMenu.Items[(int)MenuItemCode.EXIT].Selected += () => Application.Exit();
        }

        public override void Start()
        {
            ((ViewMenuWindowsForms)_viewMenu).KeyDownViewMenu += ControllerMenuWindowsForms_KeyDown;
            _viewMenu.Show();
        }

        public override void Stop()
        {
            ((ViewMenuWindowsForms)_viewMenu).KeyDownViewMenu -= ControllerMenuWindowsForms_KeyDown;
            _viewMenu.Close();
        }

        /// <summary>
        /// Обработчик нажатия кнопки клавиатуры
        /// </summary>
        /// <param name="parE">KeyEventArgs</param>
        private void ControllerMenuWindowsForms_KeyDown(KeyEventArgs parE)
        {
            switch (parE.KeyData)
            {
                case Keys.Down:
                    _modelMenu.FocusNext();
                    break;
                case Keys.Up:
                    _modelMenu.FocusPrevious();
                    break;
                case Keys.Enter:
                    _modelMenu.SelectFocusedItem();
                    break;
            }
        }
    }
}

