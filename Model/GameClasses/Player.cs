namespace Model
{
    /// <summary>
    /// Игрок-мышь
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Координата x на игровом поле
        /// </summary>
        private int _x;

        /// <summary>
        /// Координата y на игровом поле
        /// </summary>
        private int _y;

        /// <summary>
        /// Матрица взаимного расположения объектов игры
        /// </summary>
        private FieldElement[,] _gameField;

        /// <summary>
        /// Создание игрока
        /// </summary>
        /// <param name="parGameField">Ссылка на матрицу взаимного расположения объеков игры</param>
        public Player(ref FieldElement[,] parGameField)
        {
            _gameField = parGameField;
        }

        /// <summary>
        /// Координата x на игровом поле
        /// </summary>
        public int X
        {
            get { return _x; }
            set
            {
                if (value >= 0 && value < ModelResource.COLUMN && _gameField[_y, value] != FieldElement.CAT)
                {
                    _x = value;
                }
            }
        }

        /// <summary>
        /// Координата y на игровом поле
        /// </summary>
        public int Y
        {
            get { return _y; }
            set
            {
                if (value >= 0 && value < ModelResource.ROW && _gameField[value, _x] != FieldElement.CAT)
                {
                    _y = value;
                }
            }
        }
    }
}
