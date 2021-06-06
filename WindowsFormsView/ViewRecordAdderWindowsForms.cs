using Model;
using System.Drawing;
using System.Windows.Forms;
using View;

namespace WindowsForms
{
    /// <summary>
    /// Представление добавления нового рекорда Windows Forms
    /// </summary>
    public class ViewRecordAdderWindowsForms : ViewRecord
    {
        /// <summary>
        /// Событие нажатия кнопки клавиатуры на TextBox
        /// </summary>
        public event dKeyDownTextBox KeyDownTextBox;

        /// <summary>
        /// Форма представления
        /// </summary>
        private Form _formDialog;

        /// <summary>
        /// Поле ввода
        /// </summary>
        private TextBox _textBox;

        /// <summary>
        /// Шрифт представления
        /// </summary>
        private Font _font;

        /// <summary>
        /// Создание представления добавления нового рекорда Windows Forms
        /// </summary>
        /// <param name="parModelHelp">Модель рекордов</param>
        public ViewRecordAdderWindowsForms(ModelRecords parModelRecords) : base(parModelRecords)
        {
            _formDialog = new Form();
            Size size = new Size(ViewResource.WIDTH_FORM_DIALOG, ViewResource.HEIGHT_FORM_DIALOG);
            _formDialog.MaximumSize = size;
            _formDialog.Size = size;

            _textBox = new TextBox();
            _textBox.Size = new Size(ViewResource.WIDTH_TEXT_BOX, ViewResource.HEIGHT_TEXT_BOX);
            _textBox.Location = new Point(ViewResource.X_TEXT_BOX, ViewResource.Y_TEXT_BOX);

            _font = new Font("Courier New", ViewResource.FONT_SIZE);
            _textBox.Font = _font;

            _textBox.KeyDown += ViewRecordAdderWindowsForms_KeyDown;
            _formDialog.Paint += ViewRecordAdderWindowsForms_Paint;
            _formDialog.Controls.Add(_textBox);
            _formDialog.ActiveControl = _textBox;
            _formDialog.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Обработчик нажатия кнопки клавиатуры
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">KeyEventArgs</param>
        private void ViewRecordAdderWindowsForms_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                KeyDownTextBox?.Invoke(_textBox.Text);
            } 
        }

        public override void Show()
        {
            _textBox.Clear();
            _formDialog.ShowDialog();
        }

        public override void Close()
        {
            _formDialog.Close();
        }

        /// <summary>
        /// Обработчик перерисовки формы добавления нового рекорда
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">PaintEventArgs</param>
        private void ViewRecordAdderWindowsForms_Paint(object sender, PaintEventArgs e)
        {
            _formDialog.BackColor = Color.DimGray;
            Graphics graphics = _formDialog.CreateGraphics(); 
            graphics.DrawString("Введите имя и \nнажмите Enter", _font, Brushes.Yellow, ViewResource.RECORD_ADDER_X, ViewResource.RECORD_ADDER_Y);
        }
    }
}
