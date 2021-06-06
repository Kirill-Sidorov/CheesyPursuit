using Controller;
using Model;
using System.Windows.Forms;

namespace WindowsForms
{
    /// <summary>
    /// Контроллер-состояние таблицы рекордов Windows Forms
    /// </summary>
    public class ControllerRecordsTableWindowsForms : ControllerRecordsTableState
    {
        /// <summary>
        /// Создание контроллер-состояние таблицы рекордов
        /// </summary>
        /// <param name="parControllerProgram">Управляющий контроллер</param>
        /// <param name="parModelRecords">Модель рекордов</param>
        public ControllerRecordsTableWindowsForms(ControllerProgram parControllerProgram, ModelRecords parModelRecords) : base(parControllerProgram, parModelRecords)
        {
        }

        public override void Start()
        {
            ((ViewRecordsTableWindowsForms)_viewRecordsTable).KeyDownViewRecordsTable += ControllerRecordsTableWindowsForms_KeyDown;
            _viewRecordsTable.Show();
        }

        public override void Stop()
        {
            ((ViewRecordsTableWindowsForms)_viewRecordsTable).KeyDownViewRecordsTable -= ControllerRecordsTableWindowsForms_KeyDown;
            _viewRecordsTable.Close();
        }

        /// <summary>
        /// Обработчик нажатия кнопки клавиатуры
        /// </summary>
        /// <param name="parE">KeyEventArgs</param>
        private void ControllerRecordsTableWindowsForms_KeyDown(KeyEventArgs parE)
        {
            if (parE.KeyData == Keys.Escape)
            {
                ChangeOnControllerMenuState();
            }
        }
    }
}
