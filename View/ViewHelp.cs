using Model;

namespace View
{
    /// <summary>
    /// Представление справки игры
    /// </summary>
    public abstract class ViewHelp : IView
    {
        /// <summary>
        /// Модель справки игры
        /// </summary>
        protected ModelHelp _modelHelp;

        /// <summary>
        /// Создание представления справки игры
        /// </summary>
        /// <param name="parModelHelp">Модель справки игры</param>
        public ViewHelp(ModelHelp parModelHelp)
        {
            _modelHelp = parModelHelp;
        }

        public abstract void Close();
        public abstract void Show();
    }
}
