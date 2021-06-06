using Model;

namespace View
{
    /// <summary>
    /// Представление рекоров игры
    /// </summary>
    public abstract class ViewRecord : IView
    {
        /// <summary>
        /// Модель рекордов игры
        /// </summary>
        protected ModelRecords _modelRecords;

        /// <summary>
        /// Создание представления рекордов игры
        /// </summary>
        /// <param name="parModelRecords">Модель рекордов игры</param>
        public ViewRecord(ModelRecords parModelRecords)
        {
            _modelRecords = parModelRecords;
        }

        public abstract void Show();
        public abstract void Close();
    }
}
