using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestCheesyPursuit
{
    /// <summary>
    /// Тестирование класса модели игры ModelGame
    /// </summary>
    [TestClass]
    public class ModelGameTests
    {
        /// <summary>
        /// Проверка значения количества кошек игры после полной перезагрузки игровой модели
        /// </summary>
        [TestMethod]
        public void ResetAllGameCheckNumberCatsTest()
        {
            ModelGame modelGame = new ModelGame();
            modelGame.ResetAllGame();

            int actualNumberCats = modelGame.NumberCats;
            int expectedNumberCats = 3;

            Assert.AreEqual(expectedNumberCats, actualNumberCats);
        }

        /// <summary>
        /// Проверка значения количества очков игры после полной перезагрузки игровой модели
        /// </summary>
        [TestMethod]
        public void ResetAllGameCheckNumberGamePointsTest()
        {
            ModelGame modelGame = new ModelGame();
            modelGame.ResetAllGame();

            int actualNumberGamePoints = modelGame.NumberGamePoints;
            int expectedNumberGamePoints = 0;

            Assert.AreEqual(expectedNumberGamePoints, actualNumberGamePoints);
        }

        /// <summary>
        /// Проверка значения количества съеденного сыра после полной перезагрузки игровой модели
        /// </summary>
        [TestMethod]
        public void ResetAllGameCheckNumberEatenCheeseTest()
        {
            ModelGame modelGame = new ModelGame();
            modelGame.ResetAllGame();

            int actualNumberEatenCheese = modelGame.NumberEatenCheese;
            int expectedNumberEatenCheese = 0;

            Assert.AreEqual(expectedNumberEatenCheese, actualNumberEatenCheese);
        }

        /// <summary>
        /// Проверка изменения координат игрока при перемещении вверх
        /// </summary>
        [TestMethod]
        public void MovePlayerUpTest()
        {
            ModelGame modelGame = new ModelGame();
            modelGame.ResetAllGame();
            modelGame.MovePlayer(Movement.UP);

            int actualPlayerCoordinateY = modelGame.Player.Y;
            int expectedPlayerCoordinateY = ModelResource.PLAYER_INITIAL_POSITION_Y - 1;

            Assert.AreEqual(expectedPlayerCoordinateY, actualPlayerCoordinateY);
        }

        /// <summary>
        /// Проверка изменения координат игрока при перемещении вниз
        /// </summary>
        [TestMethod]
        public void MovePlayerDownTest()
        {
            ModelGame modelGame = new ModelGame();
            modelGame.ResetAllGame();
            modelGame.MovePlayer(Movement.DOWN);

            int actualPlayerCoordinateY = modelGame.Player.Y;
            int expectedPlayerCoordinateY = ModelResource.PLAYER_INITIAL_POSITION_Y + 1;

            Assert.AreEqual(expectedPlayerCoordinateY, actualPlayerCoordinateY);
        }

        /// <summary>
        /// Проверка изменения координат игрока при перемещении вправо
        /// </summary>
        [TestMethod]
        public void MovePlayerRightTest()
        {
            ModelGame modelGame = new ModelGame();
            modelGame.ResetAllGame();
            modelGame.MovePlayer(Movement.RIGHT);

            int actualPlayerCoordinateX = modelGame.Player.X;
            int expectedPlayerCoordinateX = ModelResource.PLAYER_INITIAL_POSITION_X + 1;

            Assert.AreEqual(expectedPlayerCoordinateX, actualPlayerCoordinateX);
        }

        /// <summary>
        /// Проверка изменения координат игрока при перемещении влево
        /// </summary>
        [TestMethod]
        public void MovePlayerLeftTest()
        {
            ModelGame modelGame = new ModelGame();
            modelGame.ResetAllGame();
            modelGame.MovePlayer(Movement.LEFT);

            int actualPlayerCoordinateX = modelGame.Player.X;
            int expectedPlayerCoordinateX = ModelResource.PLAYER_INITIAL_POSITION_X - 1;

            Assert.AreEqual(expectedPlayerCoordinateX, actualPlayerCoordinateX);
        }
    }
}
