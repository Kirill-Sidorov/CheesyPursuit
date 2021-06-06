namespace Model
{
    /// <summary>
    /// Элемент меню
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Событие выбора этого элемента меню
        /// </summary>
        public event dSelected Selected = null;

        /// <summary>
        /// Название элемента меню
        /// </summary>
        private string _name;

        /// <summary>
        /// Состояние элемента меню
        /// </summary>
        private Status _status;

        /// <summary>
        /// Текущее состояние элемента меню
        /// </summary>
        public Status CurrentStatus
        {
            get { return _status; }
            set
            {
                _status = value;
                if (_status == Status.SELECTED)
                {
                    _status = Status.FOCUSED;
                    Selected?.Invoke();
                }
            }
        }

        /// <summary>
        /// Название элемента меню
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Создать элемент меню
        /// </summary>
        /// <param name="parName">Название элемента меню</param>
        public MenuItem(string parName)
        {
            _name = parName;
            _status = Status.NORMAL;
        }
    }
}
