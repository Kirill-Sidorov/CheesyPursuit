namespace Model
{
    /// <summary>
    /// Элементы игры
    /// </summary>
    public enum FieldElement
    {
        EMPTY,
        CAT,
        PLAYER
    }

    /// <summary>
    /// Элементы меню
    /// </summary>
    public enum MenuItemCode
    {
        GAME,
        RECORDS,
        HELP,
        EXIT
    }

    /// <summary>
    /// Состояния элемента меню
    /// </summary>
    public enum Status
    {
        NORMAL,
        FOCUSED,
        SELECTED
    }

    /// <summary>
    /// Направление движения
    /// </summary>
    public enum Movement
    {
        UP = 0,
        DOWN,
        RIGHT,
        LEFT
    }

    /// <summary>
    /// Игрок был съеден
    /// </summary>
    public delegate void dAtePlayer();

    /// <summary>
    /// Необходима перезагрузка поля сыра игры
    /// </summary>
    public delegate void dResetCheeseField();

    /// <summary>
    /// Элемент меню был выбран
    /// </summary>
    public delegate void dSelected();

    /// <summary>
    /// Необходимо перерисовать меню
    /// </summary>
    public delegate void dNeedRedraw();

    /// <summary>
    /// Общие ресурсы модели игры
    /// </summary>
    public static class ModelResource
    {
        /// <summary>
        /// Количество строк игрового поля
        /// </summary>
        public const int ROW = 5;

        /// <summary>
        /// Количество колонок игрового поля
        /// </summary>
        public const int COLUMN = 7;

        /// <summary>
        /// Начальная позиция игрока по оси x
        /// </summary>
        public const int PLAYER_INITIAL_POSITION_X = 3;

        /// <summary>
        /// Начальная позиция игрока по оси y
        /// </summary>
        public const int PLAYER_INITIAL_POSITION_Y = 2;

        /// <summary>
        /// Путь к файлу рекордов
        /// </summary>
        public const string FILE_PATH = "records.txt";
    }
}
