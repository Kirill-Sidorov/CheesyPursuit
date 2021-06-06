namespace View
{
    /// <summary>
    /// Общий интерфейс всех представлений
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Показать представление
        /// </summary>
        void Show();

        /// <summary>
        /// Закрыть представление
        /// </summary>
        void Close();
    }
}