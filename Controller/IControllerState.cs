using Model;
using View;

namespace Controller
{
    /// <summary>
    /// Общий интерфейс всех контроллеров-состояний
    /// </summary>
    public interface IControllerState
    {
        /// <summary>
        /// Модель контроллера
        /// </summary>
        IModel Model { get; }

        /// <summary>
        /// Управляющий контроллер
        /// </summary>
        ControllerProgram ControllerProgram { get; }

        /// <summary>
        /// Запустить контроллер-состояние
        /// </summary>
        void Start();

        /// <summary>
        /// Остановить контроллер-состояние
        /// </summary>
        void Stop();

        /// <summary>
        /// Установить представление контроллеру
        /// </summary>
        /// <param name="parView">Объект представления</param>
        void SetView(IView parView);
    }
}
