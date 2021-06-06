using Model;
using System.Drawing;
using View;

namespace WindowsForms
{
    /// <summary>
    /// Представление поля сыра игры
    /// </summary>
    public class ViewCheeseManagerWindowsForms : ViewGameObject
    {
        /// <summary>
        /// Управляющий объект сыром игрового поля
        /// </summary>
        private CheeseManager _cheeseManager;

        /// <summary>
        /// Графический буфер
        /// </summary>
        private BufferedGraphics _bufferedGraphics;

        /// <summary>
        /// Изображение сыра
        /// </summary>
        private Image _imageCheese = Properties.Resources.cheese;

        /// <summary>
        /// Изображение пустой клетки
        /// </summary>
        private Image _imageEmpty = Properties.Resources.empty;

        /// <summary>
        /// Изображение поля сыра игры
        /// </summary>
        private Bitmap _bitmap = new Bitmap(ModelResource.COLUMN * ViewResource.OFFSET, ModelResource.ROW * ViewResource.OFFSET);

        /// <summary>
        /// Поверхность рисования поля сыра
        /// </summary>
        private Graphics _g;

        /// <summary>
        /// Создание представления поля сыра игры
        /// </summary>
        /// <param name="parCheeseManager">Управляющий объект сыром игрового поля</param>
        /// <param name="parBufferedGraphics">Графический буфер</param>
        /// <param name="parOffsetX">Смещение по оси x</param>
        /// <param name="parOffsetY">Смещение по оси y</param>
        public ViewCheeseManagerWindowsForms(CheeseManager parCheeseManager, BufferedGraphics parBufferedGraphics, int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
            _bufferedGraphics = parBufferedGraphics;
            _cheeseManager = parCheeseManager;
            _cheeseManager.ResetCheeseField += ResetCheeseField;
            _g = Graphics.FromImage(_bitmap);
            ResetCheeseField();
        }

        /// <summary>
        /// Перезагрузить поле сыра игры
        /// </summary>
        private void ResetCheeseField()
        {
            for (int i = 0; i < ModelResource.ROW; i++)
            {
                for (int j = 0; j < ModelResource.COLUMN; j++)
                {
                   _g.DrawImage(_imageCheese, j * ViewResource.OFFSET, i * ViewResource.OFFSET);
                }
            }
            _g.DrawImage(_imageEmpty, ModelResource.PLAYER_INITIAL_POSITION_X * ViewResource.OFFSET, ModelResource.PLAYER_INITIAL_POSITION_Y * ViewResource.OFFSET);
        }

        /// <summary>
        /// Изменить поле сыра игры
        /// </summary>
        private void ChangeCheeseField()
        {
            if (_cheeseManager.IsEatenCheese)
            {
                _g.DrawImage(_imageEmpty, _cheeseManager.EatenCheeseX * ViewResource.OFFSET, _cheeseManager.EatenCheeseY * ViewResource.OFFSET);
                _cheeseManager.IsEatenCheese = false;
            }
        }

        public override void Draw()
        {
            ChangeCheeseField();
            _bufferedGraphics.Graphics.DrawImage(_bitmap, _offsetX, _offsetY);
        }
    }
}
