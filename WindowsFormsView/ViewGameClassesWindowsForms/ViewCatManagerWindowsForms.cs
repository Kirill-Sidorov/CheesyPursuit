using Model;
using System.Drawing;
using View;

namespace WindowsForms
{
    /// <summary>
    /// Представление кошек игры
    /// </summary>
    public class ViewCatManagerWindowsForms : ViewGameObject
    {
        /// <summary>
        /// Управляющий объект кошками игры
        /// </summary>
        private CatManager _catManager;

        /// <summary>
        /// Графический буфер
        /// </summary>
        private BufferedGraphics _bufferedGraphics;

        /// <summary>
        /// Изображение кошки
        /// </summary>
        private Image _image = Properties.Resources.cat;

        /// <summary>
        /// Создание представления кошек игры
        /// </summary>
        /// <param name="parCatManager">Управляющий объект кошками игры</param>
        /// <param name="parBufferedGraphics">Графический буфер</param>
        /// <param name="parOffsetX">Смещение по оси x</param>
        /// <param name="parOffsetY">Смещение по оси y</param>
        public ViewCatManagerWindowsForms(CatManager parCatManager, BufferedGraphics parBufferedGraphics, int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
            _bufferedGraphics = parBufferedGraphics;
            _catManager = parCatManager;
        }

        public override void Draw()
        {
            while (_catManager.HasNextCat())
            {
                var coordinates = _catManager.MoveCat();
                _bufferedGraphics.Graphics.DrawImage(_image, coordinates.Item1 * ViewResource.OFFSET + _offsetX, coordinates.Item2 * ViewResource.OFFSET + _offsetY);
            }
        }
    }
}
