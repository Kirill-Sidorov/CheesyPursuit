namespace Model
{
    /// <summary>
    /// Управляющий класс сыром игрового поля
    /// </summary>
    public class CheeseManager
    {
        /// <summary>
        /// Событие перезагрузки поля сыра игры
        /// </summary>
        public event dResetCheeseField ResetCheeseField = null;

        /// <summary>
        /// Матрица поля сыра игры
        /// </summary>
        private bool[,] _cheeseField;

        /// <summary>
        /// Текущая координата x съеденного сыра
        /// </summary>
        private int _currentEatenCheeseX;

        /// <summary>
        /// Текущая координата y съеденного сыра
        /// </summary>
        private int _currentEatenCheeseY;

        /// <summary>
        /// Флаг того, что был съеден сыр
        /// </summary>
        private bool _isEatenCheese;

        /// <summary>
        /// Текущая координата x съеденного сыра
        /// </summary>
        public int EatenCheeseX
        {
            get { return _currentEatenCheeseX; }
        }

        /// <summary>
        /// Текущая координата y съеденного сыра
        /// </summary>
        public int EatenCheeseY
        {
            get { return _currentEatenCheeseY; }
        }

        /// <summary>
        /// Флаг того, что был съеден сыр
        /// </summary>
        public bool IsEatenCheese
        {
            get { return _isEatenCheese; }
            set { _isEatenCheese = value; }
        }

        /// <summary>
        /// Перезагрузить поле сыра игры
        /// </summary>
        public void Reset()
        {
            _isEatenCheese = false;
            _cheeseField = new bool[ModelResource.ROW, ModelResource.COLUMN];
            for (int i = 0; i < ModelResource.ROW; i++)
            {
                for (int j = 0; j < ModelResource.COLUMN; j++)
                {
                    _cheeseField[i, j] = true;
                }
            }
            _cheeseField[ModelResource.PLAYER_INITIAL_POSITION_Y, ModelResource.PLAYER_INITIAL_POSITION_X] = false;
            ResetCheeseField?.Invoke();
        }

        /// <summary>
        /// Съесть сыр
        /// </summary>
        /// <param name="parI">Строка матрицы поля сыра игры</param>
        /// <param name="parJ">Столбец матрицы поля сыра игры</param>
        public void EatCheese(int parI, int parJ)
        {
            if (_cheeseField[parI, parJ])
            {
                _isEatenCheese = true;
                _cheeseField[parI, parJ] = false;
                _currentEatenCheeseX = parJ;
                _currentEatenCheeseY = parI;
            }
        }

        /// <summary>
        /// Получить наличие сыра в элементе матрицы поля сыра
        /// </summary>
        /// <param name="parI">Строка матрицы поля сыра игры</param>
        /// <param name="parJ">Столбец матрицы поля сыра игры</param>
        /// <returns>True - сыр есть, false - нет</returns>
        public bool GetCheeseFieldValue(int parI, int parJ)
        {
            return _cheeseField[parI, parJ];
        }
    }
}
