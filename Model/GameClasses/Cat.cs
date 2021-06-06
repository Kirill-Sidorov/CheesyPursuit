namespace Model
{
    /// <summary>
    /// Кошка игры
    /// </summary>
    public class Cat
    {
        /// <summary>
        /// Координата x на игровом поле
        /// </summary>
        private float _x;

        /// <summary>
        /// Координата y на игровом поле
        /// </summary>
        private float _y;

        /// <summary>
        /// Скорость кошки по оси x
        /// </summary>
        private float _speedX;

        /// <summary>
        /// Скорость кошки по оси y
        /// </summary>
        private float _speedY;

        /// <summary>
        /// Строка текущего положения кошки в матрице игровых объектов
        /// </summary>
        private int _i;

        /// <summary>
        /// Столбец текущего положения кошки в матрице игровых объектов
        /// </summary>
        private int _j;

        /// <summary>
        /// Флаг того, что кошка прошла через все игровое поле
        /// </summary>
        private bool _isWalkedAcrossField;

        /// <summary>
        /// Координата x на игровом поле
        /// </summary>
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// Координата y на игровом поле
        /// </summary>
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// Скорость кошки по оси x
        /// </summary>
        public float SpeedX
        {
            get { return _speedX; }
            set { _speedX = value; }
        }

        /// <summary>
        /// Скорость кошки по оси y
        /// </summary>
        public float SpeedY
        {
            get { return _speedY; }
            set { _speedY = value; }
        }

        /// <summary>
        /// Строка текущего положения кошки в матрице игровых объектов
        /// </summary>
        public int I
        {
            get { return _i; }
            set { _i = value; }
        }

        /// <summary>
        /// Столбец текущего положения кошки в матрице игровых объектов
        /// </summary>
        public int J
        {
            get { return _j; }
            set { _j = value; }
        }

        /// <summary>
        /// Флаг того, что кошка прошла через все игровое поле
        /// </summary>
        public bool IsWalkedAcrossField
        {
            get { return _isWalkedAcrossField; }
            set { _isWalkedAcrossField = value; }
        }

        /// <summary>
        /// Переместить кошку
        /// </summary>
        public void Move()
        {
            _x += _speedX;
            _y += _speedY;
        }
    }
}
