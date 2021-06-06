using Model;
using System;
using View;

namespace Console.ViewGameClassesConsole
{
    /// <summary>
    /// Представление поля сыра игры Console
    /// </summary>
    public class ViewCheeseManagerConsole : ViewGameObject
    {
        /// <summary>
        /// Управляющий объект сыром игрового поля
        /// </summary>
        private CheeseManager _cheeseManager;

        /// <summary>
        /// Цвет сыра
        /// </summary>
        private ConsoleColor _colorCheese;

        /// <summary>
        /// Цвет пустой клетки
        /// </summary>
        private ConsoleColor _colorEmpty;

        /// <summary>
        /// Создание представления поля сыра игры
        /// </summary>
        /// <param name="parCheeseManager">Управляющий объект сыром игрового поля</param>
        /// <param name="parOffsetX">Смещение по оси x</param>
        /// <param name="parOffsetY">Смещение по оси y</param>
        public ViewCheeseManagerConsole(CheeseManager parCheeseManager, int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
            _cheeseManager = parCheeseManager;
            _colorCheese = ConsoleColor.Yellow;
            _colorEmpty = ConsoleColor.Black;
        }

        public override void Draw()
        {
            if (_cheeseManager.IsEatenCheese)
            {
                _cheeseManager.IsEatenCheese = false;
            }

            for (int i = 0; i < ModelResource.ROW; i++)
            {
                for (int j = 0; j < ModelResource.COLUMN; j++)
                {
                    if (_cheeseManager.GetCheeseFieldValue(i, j))
                    {
                        ConsoleOutput.Write("███", j * ViewResource.OFFSET_X + _offsetX, i * ViewResource.OFFSET_Y + _offsetY, _colorCheese);
                    } 
                    else
                    {
                        ConsoleOutput.Write("███", j * ViewResource.OFFSET_X + _offsetX, i * ViewResource.OFFSET_Y + _offsetY, _colorEmpty);
                    }
                    
                }
            }
        }
    }
}
