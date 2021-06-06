using Console.ViewGameClassesConsole;
using Model;
using System;
using System.Threading;
using View;

namespace Console
{
    /// <summary>
    /// Представление игрового процесса Console
    /// </summary>
    public class ViewGameConsole : ViewGame
    {
        /// <summary>
        /// Создание представления игрового процесса Console
        /// </summary>
        /// <param name="parModelGame">Модель игрового процесса</param>
        public ViewGameConsole(ModelGame parModelGame) : base(parModelGame)
        {
            _modelGame.CatManager.AtePlayerDelay += StopGame;
        }

        public override void Show()
        {
            StartGame();
        }

        public override void Close()
        {
            ConsoleOutput.Clear();
        }

        /// <summary>
        /// Запустить игровой процесс
        /// </summary>
        private void StartGame()
        {
            _threadView = new Thread(RunGameLoop);
            _threadView.Start();
        }

        /// <summary>
        /// Остановить игровой процесс
        /// </summary>
        private void StopGame()
        {
            _threadView.Abort();
            ConsoleOutput.Write("Конец игры! Нажмите любую кнопку клавиатуры", ViewResource.OFFSET_GAMEOVER_X, ViewResource.OFFSET_GAMEOVER_Y, ConsoleColor.Red);
            ConsoleOutput.PrintOnConsole();
        }

        /// <summary>
        /// Запустить игровой цикл
        /// </summary>
        private void RunGameLoop()
        {
            int objectOffsetX = 25;
            int objectOffsetY = 7;
            int sttingOffsetY = objectOffsetY - 4;

            ViewPlayerConsole viewPlayer = new ViewPlayerConsole(_modelGame.Player, objectOffsetX, objectOffsetY);
            ViewCheeseManagerConsole viewCheeseManager = new ViewCheeseManagerConsole(_modelGame.CheeseManager, objectOffsetX, objectOffsetY);
            ViewCatManagerConsole viewCatManager = new ViewCatManagerConsole(_modelGame.CatManager, objectOffsetX, objectOffsetY);

            ConsoleColor color = ConsoleColor.Yellow;

            while (true)
            {
                lock (_locker)
                {
                    ConsoleOutput.Clear();

                    viewCheeseManager.Draw();
                    viewPlayer.Draw();
                    viewCatManager.Draw();

                    ConsoleOutput.Write("Количество сыра - " + _modelGame.NumberGamePoints, objectOffsetX, sttingOffsetY, color);
                    ConsoleOutput.Write("Количество кошек - " + _modelGame.NumberCats, objectOffsetX, sttingOffsetY + 1, color);

                    ConsoleOutput.PrintOnConsole();
                    System.Console.CursorVisible = false;
                    Thread.Sleep(ViewResource.TIMEOUT);
                }
            }
        }

    }
}
