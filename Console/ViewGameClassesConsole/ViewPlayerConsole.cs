using Model;
using System;
using View;

namespace Console.ViewGameClassesConsole
{
    /// <summary>
    /// Представление игрока Console
    /// </summary>
    public class ViewPlayerConsole : ViewGameObject
    {
        /// <summary>
        /// Объект игрока
        /// </summary>
        private Player _player;

        /// <summary>
        /// Цвет игрока
        /// </summary>
        private ConsoleColor _colorPlayer;

        /// <summary>
        /// Создание представления игрока
        /// </summary>
        /// <param name="parPalyer">Объект игрока</param>
        /// <param name="parOffsetX">Смещение по оси x</param>
        /// <param name="parOffsetY">Смещение по оси y</param>
        public ViewPlayerConsole(Player parPalyer, int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
            _player = parPalyer;
            _colorPlayer = ConsoleColor.Blue;
        }

        public override void Draw()
        {
            ConsoleOutput.Write("███", _player.X * ViewResource.OFFSET_X + _offsetX, _player.Y * ViewResource.OFFSET_Y + _offsetY, _colorPlayer);
        }
    }
}
