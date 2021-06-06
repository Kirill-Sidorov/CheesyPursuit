using Model;
using System.Drawing;
using System.Windows.Forms;
using View;

namespace WindowsForms
{
    /// <summary>
    /// Представление меню Windows Forms
    /// </summary>
    public class ViewMenuWindowsForms : ViewMenu
    {
        /// <summary>
        /// Событие нажатия кнопки клавиатуры
        /// </summary>
        public event dKeyDown KeyDownViewMenu;

        /// <summary>
        /// Форма представления
        /// </summary>
        private Form _form;

        /// <summary>
        /// Шрифт меню
        /// </summary>
        private Font _font;

        /// <summary>
        /// Поверхность рисования меню
        /// </summary>
        private Graphics _graphics;

        /// <summary>
        /// Создание представления меню Windows Forms
        /// </summary>
        /// <param name="parModelHelp">Модель меню</param>
        public ViewMenuWindowsForms(ModelMenu parModelMenu) : base(parModelMenu)
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
        private void ViewMenuWindowsForms_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Enter)
                return;
            KeyDownViewMenu?.Invoke(e);
        }

        /// <summary>
        /// Обработчик перерисовки меню
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">PaintEventArgs</param>
        private void ViewMenuWindowsForms_Paint(object sender, PaintEventArgs e)
        {
            DrawMenu();
        }

        public override void Show()
        {
            _form.KeyDown += ViewMenuWindowsForms_KeyDown;
            _form.Paint += ViewMenuWindowsForms_Paint;
            DrawMenu();
            if (Application.OpenForms.Count == 0)
            {
                Application.Run(_form);
            }
        }

        public override void Close()
        {
            _form.KeyDown -= ViewMenuWindowsForms_KeyDown;
            _form.Paint -= ViewMenuWindowsForms_Paint;
        }
        
        protected override void NeedRedraw()
        {
            DrawMenu();
        }

        /// <summary>
        /// Нарисовать меню
        /// </summary>
        private void DrawMenu()
        {
            int offsetY = 0;
            _graphics.Clear(Color.DimGray);
            foreach (Model.MenuItem item in _modelMenu.Items.Values)
            {
                DrawMenuItem(item, offsetY);
                offsetY += 50;
            }
        }

        /// <summary>
        /// Нарисовать элемент меню
        /// </summary>
        /// <param name="parItem">Элемент меню</param>
        /// <param name="offsetY">Смещение элемента меню</param>
        private void DrawMenuItem(Model.MenuItem parItem, int offsetY)
        {   
            Brush brush = Brushes.Black;

            switch (parItem.CurrentStatus)
            {
                case Status.NORMAL:
                    brush = Brushes.White;
                    break;
                case Status.FOCUSED:
                    brush = Brushes.Yellow;
                    break;
            }
            _graphics.FillRectangle(brush, ViewResource.OFFSET_BUTTON_X, ViewResource.OFFSET_BUTTON_Y + offsetY, ViewResource.WIDTH_BUTTON, ViewResource.HEIGHT_BUTTON);
            _graphics.DrawRectangle(Pens.Black, ViewResource.OFFSET_BUTTON_X, ViewResource.OFFSET_BUTTON_Y + offsetY, ViewResource.WIDTH_BUTTON, ViewResource.HEIGHT_BUTTON);

            RectangleF rect = new RectangleF(ViewResource.OFFSET_BUTTON_X + 10, ViewResource.OFFSET_BUTTON_Y + offsetY + 10, ViewResource.WIDTH_BUTTON - 10, ViewResource.HEIGHT_BUTTON - 10);
            _graphics.DrawString(parItem.Name, _font, Brushes.Black, rect);
        }
    }
}
