using Model;
using System.Drawing;
using System.Windows.Forms;
using View;

namespace WindowsForms
{
    /// <summary>
    /// Представление справки Windows Forms
    /// </summary>
    public class ViewHelpWindowsForms : ViewHelp
    {
        /// <summary>
        /// Событие нажатия кнопки клавиатуры
        /// </summary>
        public event dKeyDown KeyDownViewHelp;

        /// <summary>
        /// Форма представления
        /// </summary>
        private Form _form;

        /// <summary>
        /// Шрифт справки
        /// </summary>
        private Font _font;

        /// <summary>
        /// Поверхность рисования справки
        /// </summary>
        private Graphics _graphics;

        /// <summary>
        /// Создание представления справки Windows Forms
        /// </summary>
        /// <param name="parModelHelp">Модель справки</param>
        public ViewHelpWindowsForms(ModelHelp parModelHelp) : base(parModelHelp)
        {
            _form = ViewFormSingleton.GetInstance();
            _font = new Font("Courier New", ViewResource.FONT_SIZE - 4);
            _graphics = _form.CreateGraphics();
        }

        /// <summary>
        /// Обработчик нажатия кнопки клавиатуры
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">KeyEventArgs</param>
        private void ViewHelpWindowsForms_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                KeyDownViewHelp?.Invoke(e);
            }
        }

        /// <summary>
        /// Обработчик перерисовки справки
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">PaintEventArgs</param>
        private void ViewHelpWindowsForms_Paint(object sender, PaintEventArgs e)
        {
            DrawHelp();
        }

        public override void Show()
        {
            _form.KeyDown += ViewHelpWindowsForms_KeyDown;
            _form.Paint += ViewHelpWindowsForms_Paint;
            DrawHelp();
        }

        public override void Close()
        {
            _form.KeyDown -= ViewHelpWindowsForms_KeyDown;
            _form.Paint -= ViewHelpWindowsForms_Paint;
        }

        /// <summary>
        /// Нарисовать справку  
        /// </summary>
        private void DrawHelp()
        {
            _graphics.Clear(Color.DimGray);
            _graphics.DrawString(_modelHelp.Text, _font, Brushes.Yellow, ViewResource.TEXT_HELP, ViewResource.TEXT_HELP);
        }

    }
}
