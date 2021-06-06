using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Модель меню игры
    /// </summary>
    public class ModelMenu : IModel
    {
        /// <summary>
        /// Событие перерисовки меню
        /// </summary>
        public event dNeedRedraw NeedRedraw = null;

        /// <summary>
        /// Элементы меню
        /// </summary>
        public Dictionary<int, MenuItem> Items;

        /// <summary>
        /// Сфокусированный элемент меню
        /// </summary>
        private int _focusedItemIndex;

        /// <summary>
        /// Создание модели меню
        /// </summary>
        public ModelMenu()
        {
            Items = new Dictionary<int, MenuItem>();
            Items.Add((int)MenuItemCode.GAME, new MenuItem("Играть"));
            Items.Add((int)MenuItemCode.RECORDS, new MenuItem("Рекорды"));
            Items.Add((int)MenuItemCode.HELP, new MenuItem("Справка"));
            Items.Add((int)MenuItemCode.EXIT, new MenuItem("Выход"));
            Items[0].CurrentStatus = Status.FOCUSED;
            _focusedItemIndex = 0;
        }

        /// <summary>
        /// Сфокусироваться на следующем элементе меню
        /// </summary>
        public void FocusNext()
        {
            int previousIndex = _focusedItemIndex;
            if (_focusedItemIndex == Items.Count - 1)
                _focusedItemIndex = 0;
            else
                _focusedItemIndex++;

            Items[_focusedItemIndex].CurrentStatus = Status.FOCUSED;
            Items[previousIndex].CurrentStatus = Status.NORMAL;

            NeedRedraw?.Invoke();
        }

        /// <summary>
        /// Сфокусироваться на предыдущем элементе меню
        /// </summary>
        public void FocusPrevious()
        {
            int previousIndex = _focusedItemIndex;
            if (_focusedItemIndex == 0)
                _focusedItemIndex = Items.Count - 1;
            else
                _focusedItemIndex--;

            Items[_focusedItemIndex].CurrentStatus = Status.FOCUSED;
            Items[previousIndex].CurrentStatus = Status.NORMAL;

            NeedRedraw?.Invoke();
        }

        /// <summary>
        /// Выбрать сфокусированный элемент меню
        /// </summary>
        public void SelectFocusedItem()
        {
            Items[_focusedItemIndex].CurrentStatus = Status.SELECTED;
        }
    }
}
