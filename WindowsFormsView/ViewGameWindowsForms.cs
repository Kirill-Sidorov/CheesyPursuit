using Model;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using View;

namespace WindowsForms
{
    /// <summary>
    /// Представление игрового процесса Windows Forms
    /// </summary>
    public class ViewGameWindowsForms : ViewGame
    {
        /// <summary>
        /// Событие нажатия кнопки клавиатуры
        /// </summary>
        public event dKeyDown KeyDownViewGame;

        /// <summary>
        /// Форма представления
        /// </summary>
        private Form _form;

        /// <summary>
        /// Графический буфер
        /// </summary>
        private BufferedGraphics _bufferedGraphics;

        /// <summary>
        /// Создание представления игрового процесса Windows Forms
        /// </summary>
        /// <param name="parModelGame">Модель игрового процесса</param>
        public ViewGameWindowsForms(ModelGame parModelGame) : base(parModelGame)
        {
            _form = ViewFormSingleton.GetInstance();
            _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(_form.CreateGraphics(), _form.ClientRectangle);
        }

        /// <summary>
        /// Обработчик нажатия кнопки клавиатуры
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">KeyEventArgs</param>
        private void ViewGameWindowsForms_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownViewGame?.Invoke(e);
        }

        /// <summary>
        /// Обработчик закрытия формы
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">KeyEventArgs</param>
        private void ViewGameWindowsForms_FormClosing(object sender, FormClosingEventArgs e)
        {
            _threadView.Abort();
        }


        public override void Show()
        {
            _form.KeyDown += ViewGameWindowsForms_KeyDown;
            _form.FormClosing += ViewGameWindowsForms_FormClosing;
            StartGame();
        }

        public override void Close()
        {
            _threadView.Abort();
            _form.KeyDown -= ViewGameWindowsForms_KeyDown;
            _form.FormClosing -= ViewGameWindowsForms_FormClosing;
        }

        /// <summary>
        /// Запустить игровой процесс
        /// </summary>
        private void StartGame()
        {
            _threadView = new Thread(RunGameLoop);
            _threadView.Start();
            if (Application.OpenForms.Count == 0)
            {
                Application.Run(_form);
            }
        }

        /// <summary>
        /// Запустить игровой цикл
        /// </summary>
        private void RunGameLoop()
        {
            int objectOffsetX = 50;
            int objectOffsetY = 110;
            int sttingOffsetY = objectOffsetY - 80;

            ViewPlayerWindowsFroms viewPlayer = new ViewPlayerWindowsFroms(_modelGame.Player, _bufferedGraphics, objectOffsetX, objectOffsetY);
            ViewCheeseManagerWindowsForms viewCheeseManager = new ViewCheeseManagerWindowsForms(_modelGame.CheeseManager, _bufferedGraphics, objectOffsetX, objectOffsetY);
            ViewCatManagerWindowsForms viewCatManager = new ViewCatManagerWindowsForms(_modelGame.CatManager, _bufferedGraphics, objectOffsetX, objectOffsetY);

            Font font = new Font("Courier New", ViewResource.FONT_SIZE);
            SolidBrush brush = new SolidBrush(Color.Yellow);

            while (true)
            {
                lock (_locker)
                {
                    _bufferedGraphics.Graphics.Clear(Color.DimGray);

                    viewCheeseManager.Draw();
                    viewPlayer.Draw();
                    viewCatManager.Draw();

                    _bufferedGraphics.Graphics.DrawString("Количество сыра - " + _modelGame.NumberGamePoints, font, brush, objectOffsetX, sttingOffsetY);
                    _bufferedGraphics.Graphics.DrawString("Количество кошек - " + _modelGame.NumberCats, font, brush, objectOffsetX, sttingOffsetY + 20);

                    _bufferedGraphics.Render();

                    Thread.Sleep(ViewResource.TIMEOUT);
                }
            }
        }
    }
}
