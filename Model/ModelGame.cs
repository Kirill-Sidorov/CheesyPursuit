namespace Model
{
    /// <summary>
    /// Модель игрового процесса
    /// </summary>
    public class ModelGame : IModel
    {
        /// <summary>
        /// Матрица взаимного расположения объектов игры
        /// </summary>
        private FieldElement[,] _gameField;

        /// <summary>
        /// Объект управления поля сыра
        /// </summary>
        public CheeseManager CheeseManager;

        /// <summary>
        /// Объект управления кошками игры
        /// </summary>
        public CatManager CatManager;

        /// <summary>
        /// Игрок-мышь
        /// </summary>
        public Player Player;

        /// <summary>
        /// Количество кошек на игровом поле
        /// </summary>
        private int _numberCats;

        /// <summary>
        /// Количесто съеденного сыра на игровом поле
        /// </summary>
        private int _numberEatenCheese;

        /// <summary>
        /// Количество игровых очков
        /// </summary>
        private int _numberGamePoints;

        /// <summary>
        /// Флаг начала игры
        /// </summary>
        private bool _isGameStart;

        /// <summary>
        /// Количество кошек на игровом поле
        /// </summary>
        public int NumberCats
        {
            private set { _numberCats = value; }
            get { return _numberCats; }
        }

        /// <summary>
        /// Количесто съеденного сыра на игровом поле
        /// </summary>
        public int NumberEatenCheese
        {
            private set { _numberEatenCheese = value; ++NumberGamePoints; }
            get { return _numberEatenCheese; }
        }

        /// <summary>
        /// Количество игровых очков
        /// </summary>
        public int NumberGamePoints
        {
            private set { _numberGamePoints = value; }
            get { return _numberGamePoints; }
        }


        /// <summary>
        /// Создание модели игрового процесса
        /// </summary>
        public ModelGame()
        {
            _gameField = new FieldElement[ModelResource.ROW, ModelResource.COLUMN];
            CheeseManager = new CheeseManager();
            Player = new Player(ref _gameField);
            CatManager = new CatManager(ref _gameField);
        }

        /// <summary>
        /// Перезагрузить полностью игровую модель
        /// </summary>
        public void ResetAllGame()
        {
            NumberCats = 3;
            NumberGamePoints = 0;
            ResetGame();
        }

        /// <summary>
        /// Перезагрузить текущую игру
        /// </summary>
        private void ResetGame()
        {
            ResetGameField();
            CheeseManager.Reset();
            CatManager.Reset();
            _isGameStart = false;
            _numberEatenCheese = 0;
            ResetPlayer();
        }

        /// <summary>
        /// Перезагрузить игрока
        /// </summary>
        private void ResetPlayer()
        {
            Player.X = ModelResource.PLAYER_INITIAL_POSITION_X;
            Player.Y = ModelResource.PLAYER_INITIAL_POSITION_Y;
        }

        /// <summary>
        /// Перезагрузить матрицу взаимного расположения объектов
        /// </summary>
        private void ResetGameField()
        {
            for (int i = 0; i < ModelResource.ROW; i++)
            {
                for (int j = 0; j < ModelResource.COLUMN; j++)
                {
                    _gameField[i, j] = FieldElement.EMPTY;
                }
            }
        }

        /// <summary>
        /// Переместить игрока
        /// </summary>
        /// <param name="parMovement">Направление перемещения</param>
        public void MovePlayer(Movement parMovement)
        {
            if (!_isGameStart)
            {
                CatManager.InitCats(NumberCats);
                _isGameStart = true;
            }

            _gameField[Player.Y, Player.X] = FieldElement.EMPTY;
            switch (parMovement)
            {
                case Movement.UP:
                    Player.Y--;
                    break;
                case Movement.DOWN:
                    Player.Y++;
                    break;
                case Movement.RIGHT:
                    Player.X++;
                    break;
                case Movement.LEFT:
                    Player.X--;
                    break;
            }
            _gameField[Player.Y, Player.X] = FieldElement.PLAYER;
            CheeseManager.EatCheese(Player.Y, Player.X);

            if(CheeseManager.IsEatenCheese && ++NumberEatenCheese == 34)
            {
                NumberCats++;
                ResetGame();
            }
        }
    }
}
