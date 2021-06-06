using Model;
using System.Threading;

namespace View
{
    /// <summary>
    /// Представление игрового процесса
    /// </summary>
    public abstract class ViewGame : IView
    {
        /// <summary>
        /// Поток отрисовки представления
        /// </summary>
        protected Thread _threadView;

        /// <summary>
        /// "Объект-заглушка" блокировки потока
        /// </summary>
        protected object _locker;

        /// <summary>
        /// Модель игрового процесса
        /// </summary>
        protected ModelGame _modelGame;

        /// <summary>
        /// Создание представления игрового процесса
        /// </summary>
        /// <param name="parModelGame">Модель игрового процесса</param>
        public ViewGame(ModelGame parModelGame)
        {
            _modelGame = parModelGame;
            _locker = new object();
        }

        public abstract void Show();
        public abstract void Close();
    }
}
