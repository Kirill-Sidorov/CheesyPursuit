using Controller;
using Model;
using System;
using System.Threading;

namespace Console
{
    /// <summary>
    /// Контроллер-состояние игрового процесса Console
    /// </summary>
    public class ControllerGameConsole : ControllerGameState
    {
        /// <summary>
        /// Игровой процесс выполняется
        /// </summary>
        private bool _isGamePlay;

        /// <summary>
        /// Задержка после завершения игры
        /// </summary>
        private bool _isDeleyGameOver;

        /// <summary>
        /// Создание контроллера-состояние игрового процесса Console
        /// </summary>
        /// <param name="parControllerProgram">Управляющий контроллер</param>
        public ControllerGameConsole(ControllerProgram parControllerProgram) : base(parControllerProgram)
        {
            _modelGame.CatManager.AtePlayerDelay += () => _isDeleyGameOver = true;
            _modelGame.CatManager.AtePlayerQuick += () => _isGamePlay = false;
        }

        public override void Start()
        {
            _isGamePlay = true;
            _isDeleyGameOver = false;
            _modelGame.ResetAllGame();
            _viewGame.Show();
            RunLoopHandlerKeyDownGameConsole();
        }

        public override void Stop()
        {
            _viewGame.Close();
        }

        /// <summary>
        /// Запустить цикл обработки нажатия на кнопки клавиатуры
        /// </summary>
        private void RunLoopHandlerKeyDownGameConsole()
        {
            bool isHandleKeyDownGame = true;
            do
            {
                ConsoleKeyInfo keyInfo = System.Console.ReadKey();
                if (_isGamePlay)
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.DownArrow:
                            _modelGame.MovePlayer(Movement.DOWN);
                            break;
                        case ConsoleKey.UpArrow:
                            _modelGame.MovePlayer(Movement.UP);
                            break;
                        case ConsoleKey.RightArrow:
                            _modelGame.MovePlayer(Movement.RIGHT);
                            break;
                        case ConsoleKey.LeftArrow:
                            _modelGame.MovePlayer(Movement.LEFT);
                            break;
                    }
                } 
                else if (_isDeleyGameOver)
                {
                    isHandleKeyDownGame = false;  
                }
            } while (isHandleKeyDownGame);
            ChangeOnControllerRecordAdderState();
        }
    }
}
