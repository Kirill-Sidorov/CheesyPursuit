using Model;
using System;
using View;

namespace Console.ViewGameClassesConsole
{
    /// <summary>
    /// Представление кошек игры Console
    /// </summary>
    public class ViewCatManagerConsole : ViewGameObject
    {
        /// <summary>
        /// Управляющий объект кошками игры
        /// </summary>
        private CatManager _catManager;

        /// <summary>
        /// Цвет кошек
        /// </summary>
        private ConsoleColor _colorCat;

        /// <summary>
        /// Создание представления кошек игры
        /// </summary>
        /// <param name="parCatManager">Управляющий объект кошками игры</param>
        /// <param name="parOffsetX">Смещение по оси x</param>
        /// <param name="parOffsetY">Смещение по оси y</param>
        public ViewCatManagerConsole(CatManager parCatManager, int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
            _catManager = parCatManager;
            _colorCat = ConsoleColor.Red;
        }

        public override void Draw()
        {
            while (_catManager.HasNextCat())
            {
                var coordinates = _catManager.MoveCat();
                int x = (int)Math.Round(coordinates.Item1, MidpointRounding.AwayFromZero);
                int y = (int)Math.Round(coordinates.Item2, MidpointRounding.AwayFromZero);
                ConsoleOutput.Write("███", x * ViewResource.OFFSET_X + _offsetX, y * ViewResource.OFFSET_Y + _offsetY, _colorCat);
            }
        }
    }
}
