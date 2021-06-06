using Model;
using System;
using View;

namespace Console
{
    /// <summary>
    /// Представление меню Console
    /// </summary>
    public class ViewMenuConsole : ViewMenu
    {
        /// <summary>
        /// Создание представления меню Console
        /// </summary>
        /// <param name="parModelMenu">Модель меню</param>
        public ViewMenuConsole(ModelMenu parModelMenu) : base(parModelMenu)
        {
        }

        public override void Show()
        {
            DrawMenu();
        }

        public override void Close()
        {
            ConsoleOutput.Clear();
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
            int offsetY = 5;
            ConsoleOutput.Clear();
            foreach(Model.MenuItem item in _modelMenu.Items.Values)
            {
                DrawMenuItem(item, offsetY);
                offsetY += 5;
            }
            ConsoleOutput.PrintOnConsole();
            System.Console.CursorVisible = false;
        }

        /// <summary>
        /// Нарисовать элемент меню
        /// </summary>
        /// <param name="parItem">Элемент меню</param>
        /// <param name="offset">Смещение элемента меню</param>
        private void DrawMenuItem(Model.MenuItem parItem, int offsetY)
        {
            ConsoleColor color = ConsoleColor.Black;
            switch (parItem.CurrentStatus)
            {
                case Status.NORMAL:
                    color = ConsoleColor.White;
                    break;
                case Status.FOCUSED:
                    color = ConsoleColor.Yellow;
                    break;
            }
            ConsoleOutput.Write(parItem.Name, ViewResource.OFFSET_MENU_ITEM_X, offsetY, color);
        }
    }
}
