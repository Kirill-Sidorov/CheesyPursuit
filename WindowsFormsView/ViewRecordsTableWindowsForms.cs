using Model;
using System.Drawing;
using System.Windows.Forms;
using View;

namespace WindowsForms
{
    /// <summary>
    /// Представление таблицы рекордов Windows Forms
    /// </summary>
    public class ViewRecordsTableWindowsForms : ViewRecord
    {
        /// <summary>
        /// Событие нажатия кнопки клавиатуры
        /// </summary>
        public event dKeyDown KeyDownViewRecordsTable;

        /// <summary>
        /// Форма представления
        /// </summary>
        private Form _form;

        /// <summary>
        /// Шрифт представления
        /// </summary>
        private Font _font;

        /// <summary>
        /// Поверхность рисования таблицы рекордов
        /// </summary>
        private Graphics _graphics;

        /// <summary>
        /// Создание представления таблицы рекордов Windows Forms
        /// </summary>
        /// <param name="parModelHelp">Модель рекордов</param>
        public ViewRecordsTableWindowsForms(ModelRecords parModelRecords) : base(parModelRecords)
        {
            _form = ViewFormSingleton.GetInstance();
            _font = new Font("Courier New", ViewResource.FONT_SIZE);
            _graphics = _form.CreateGraphics();
        }

        /// <summary>
        /// Обработчик нажатия кнопки клавиатуры
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">KeyEventArgs</param>
        private void ViewRecordsTableWindowsForms_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                KeyDownViewRecordsTable?.Invoke(e);
            }
        }

        /// <summary>
        /// Обработчик перерисовки таблицы рекордов
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">PaintEventArgs</param>
        private void ViewRecordsTableWindowsForms_Paint(object sender, PaintEventArgs e)
        {
            DrawTable();
        }

        public override void Show()
        {
            _form.KeyDown += ViewRecordsTableWindowsForms_KeyDown;
            _form.Paint += ViewRecordsTableWindowsForms_Paint;
            DrawTable();
        }

        public override void Close()
        {
            _form.KeyDown -= ViewRecordsTableWindowsForms_KeyDown;
            _form.Paint -= ViewRecordsTableWindowsForms_Paint;
        }

        /// <summary>
        /// Нарисовать таблицу рекордов
        /// </summary>
        private void DrawTable()
        {
            int offsetY = 20;
            _graphics.Clear(Color.DimGray);
            _graphics.DrawString("Имя игрока - очки", _font, Brushes.Yellow, 90, offsetY);
            foreach (Model.GameClasses.Record record in _modelRecords.ListRecords)
            {
                offsetY += 30;
                _graphics.DrawString(record.Name + " - " + record.Score, _font, Brushes.Yellow, ViewResource.OFFSET_RECORD_X, offsetY);
            }
        }
    }
}
