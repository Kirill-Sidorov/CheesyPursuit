using System;
using System.Timers;

namespace Model
{
    /// <summary>
    /// Управляющий класс кошками игры
    /// </summary>
    public class CatManager
    {
        /// <summary>
        /// Игрок был съеден - событие с задержкой
        /// </summary>
        public event dAtePlayer AtePlayerDelay = null;

        /// <summary>
        /// Игрок был съеден - мгновенное событие
        /// </summary>
        public event dAtePlayer AtePlayerQuick = null;

        /// <summary>
        /// Генератор псевдослучайных чисел
        /// </summary>
        private Random _random = new Random();

        /// <summary>
        /// Все кошки игры
        /// </summary>
        private Cat[] _cats;

        /// <summary>
        /// Матрица взаимного расположения объектов игры
        /// </summary>
        private FieldElement[,] _gameField;

        /// <summary>
        /// Текущий элемент массива кошек 
        /// </summary>
        private int _currentCat;

        /// <summary>
        /// Количество кошек на игровом поле
        /// </summary>
        private int _numberCats;

        /// <summary>
        /// Создание объекта управления кошками
        /// </summary>
        /// <param name="parGameField">Ссылка на матрицу взаимного расположения объеков игры</param>
        public CatManager(ref FieldElement[,] parGameField)
        {
            _gameField = parGameField;
        }

        /// <summary>
        /// Инициализировать кошек игры
        /// </summary>
        /// <param name="parNumberCats">Количество кошек на игровом поле</param>
        public void InitCats(int parNumberCats)
        {
            _numberCats = parNumberCats;
            _cats = new Cat[parNumberCats];
            for (int i = 0; i < _numberCats; i++)
            {
                _cats[i] = new Cat();
                ResetCat(_cats[i]);
            }
            _currentCat = 0;
        }

        /// <summary>
        /// Перезагрузить объект управления кошками
        /// </summary>
        public void Reset()
        {
            _cats = null;
            _numberCats = 0;
        }

        /// <summary>
        /// Перезагрузить кошку
        /// </summary>
        /// <param name="parCat">Кошка</param>
        private void ResetCat(Cat parCat)
        {
            int initialPositionX = 0;
            int initialPositionY = 0;
            float speedX = 0;
            float speedY = 0;

            float speed = _random.Next(2, 8) * 0.005f;

            switch ((Movement)_random.Next(0, 4))
            {
                case Movement.UP:
                    speedY = -1 * speed;
                    initialPositionX = _random.Next(0, ModelResource.COLUMN);
                    parCat.X = initialPositionX;
                    parCat.Y = ModelResource.ROW;
                    parCat.I = ModelResource.ROW - 1;
                    parCat.J = initialPositionX;
                    break;
                case Movement.DOWN:
                    speedY = speed;
                    initialPositionX = _random.Next(0, ModelResource.COLUMN);
                    parCat.X = initialPositionX;
                    parCat.Y = -1;
                    parCat.I = 0;
                    parCat.J = initialPositionX;
                    break;
                case Movement.RIGHT:
                    speedX = speed;
                    initialPositionY = _random.Next(0, ModelResource.ROW);
                    parCat.X = -1;
                    parCat.Y = initialPositionY;
                    parCat.I = initialPositionY;
                    parCat.J = 0;
                    break;
                case Movement.LEFT:
                    speedX = -1 * speed;
                    initialPositionY = _random.Next(0, ModelResource.ROW);
                    parCat.X = ModelResource.COLUMN;
                    parCat.Y = initialPositionY;
                    parCat.I = initialPositionY;
                    parCat.J = ModelResource.COLUMN - 1;
                    break;
            }
            parCat.SpeedX = speedX;
            parCat.SpeedY = speedY;
            parCat.IsWalkedAcrossField = false;
        }

        /// <summary>
        /// Переместить кошку
        /// </summary>
        /// <returns>Кортеж координат положения кошки на игровом поле</returns>
        public (float, float) MoveCat()
        {
            Cat cat = _cats[_currentCat];

            cat.Move();

            float x = cat.X;
            float y = cat.Y;

            if (!(x < 0 || y < 0 || x > (ModelResource.COLUMN - 1) || y > (ModelResource.ROW - 1)))
            {
                if (!cat.IsWalkedAcrossField)
                {
                    _gameField[cat.I, cat.J] = FieldElement.CAT;
                    cat.IsWalkedAcrossField = true;
                }
                ChangeLocationCatOnGameObjectsField(cat, x, y);
            }
            else if (cat.IsWalkedAcrossField && (x < -1 || y < -1 || x > ModelResource.COLUMN || y > ModelResource.ROW))
            {
                _gameField[cat.I, cat.J] = FieldElement.EMPTY;
                ResetCat(cat);
            }
            _currentCat++;
            return (cat.X, cat.Y);
        }

        /// <summary>
        /// Изменить положение кошки на матрице взаимного расположения объектов
        /// </summary>
        /// <param name="parCat">Кошка</param>
        /// <param name="parX">Текущая координата x кошки</param>
        /// <param name="parY">Текущая координата y кошки</param>
        private void ChangeLocationCatOnGameObjectsField(Cat parCat, float parX, float parY)
        {
            float limitX = Math.Abs(parX - parCat.J);
            float limitY = Math.Abs(parY - parCat.I);

            if (limitX >= 0.5 || limitY >= 0.5)
            {
                _gameField[parCat.I, parCat.J] = FieldElement.EMPTY;

                parCat.J = (int)Math.Round(parX, MidpointRounding.AwayFromZero);
                parCat.I = (int)Math.Round(parY, MidpointRounding.AwayFromZero);

                if (_gameField[parCat.I, parCat.J] == FieldElement.PLAYER)
                {
                    parCat.X = parCat.J;
                    parCat.Y = parCat.I;
                    AtePlayerQuick?.Invoke();
                    Timer aTimer = new Timer();
                    aTimer.Interval = 10;
                    aTimer.Elapsed += (s, e) => AtePlayerDelay?.Invoke();
                    aTimer.AutoReset = false;
                    aTimer.Enabled = true;
                }
                else if (_gameField[parCat.I, parCat.J] == FieldElement.CAT)
                {
                    parCat.SpeedX *= -1;
                    parCat.SpeedY *= -1;
                }
                else
                {
                    _gameField[parCat.I, parCat.J] = FieldElement.CAT;
                }
            }
        }

        /// <summary>
        /// Есть следующий элемент массива кошек или нет
        /// </summary>
        /// <returns>True - еще есть элементы, False - нет</returns>
        public bool HasNextCat()
        {
            if (_currentCat >= _numberCats)
            {
                _currentCat = 0;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}