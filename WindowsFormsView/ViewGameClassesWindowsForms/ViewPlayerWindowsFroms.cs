using Model;
using System.Drawing;
using View;

namespace WindowsForms
{
    /// <summary>
    /// Представление игрока
    /// </summary>
    public class ViewPlayerWindowsFroms : ViewGameObject
    {
        /// <summary>
        /// Объект игрока
        /// </summary>
        private Player _player;

        /// <summary>
        /// Графический буфер
        /// </summary>
        private BufferedGraphics _bufferedGraphics;

        /// <summary>
        /// Изображение игрока
        /// </summary>
        private Image _image = Properties.Resources.mouse;

        /// <summary>
        /// Создание представления игрока
        /// </summary>
        /// <param name="parPlayer">Объект игрока</param>
        /// <param name="parBufferedGraphics">Графический буфер</param>
        /// <param name="parOffsetX">Смещение по оси x</param>
        /// <param name="parOffsetY">Смещение по оси y</param>
        public ViewPlayerWindowsFroms(Player parPlayer, BufferedGraphics parBufferedGraphics, int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
            _bufferedGraphics = parBufferedGraphics;
            _player = parPlayer;
        }

        public override void Draw()
        {
            _bufferedGraphics.Graphics.DrawImage(_image, _player.X * ViewResource.OFFSET + _offsetX, _player.Y * ViewResource.OFFSET + _offsetY);
        }
    }
}
