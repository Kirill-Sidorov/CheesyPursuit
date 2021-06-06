using Model;

namespace View
{
    /// <summary>
    /// Представление меню
    /// </summary>
    public abstract class ViewMenu : IView
    {
        /// <summary>
        /// Модель меню
        /// </summary>
        protected ModelMenu _modelMenu;

        /// <summary>
        /// Создание представления меню
        /// </summary>
        /// <param name="parModelMenu">Модель меню</param>
        public ViewMenu(ModelMenu parModelMenu)
        {
            _modelMenu = parModelMenu;
            _modelMenu.NeedRedraw += NeedRedraw;
        }

        /// <summary>
        /// Перерисовать представление меню
        /// </summary>
        protected abstract void NeedRedraw();

        public abstract void Show();
        public abstract void Close();


    }
}
