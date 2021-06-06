using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestCheesyPursuit
{
    [TestClass]
    public class CheeseManagerTests
    {
        /// <summary>
        /// Проверка наличия кусочка сыра в элементе матрицы поля
        /// </summary>
        [TestMethod]
        public void GetCheeseFieldValueTest()
        {
            ModelGame modelGame = new ModelGame();
            CheeseManager cheeseManager = modelGame.CheeseManager;
            cheeseManager.Reset();

            bool actualCheeseFieldValue = cheeseManager.GetCheeseFieldValue(1, 1);
            bool expectedCheeseFieldValue = true;

            Assert.AreEqual(expectedCheeseFieldValue, actualCheeseFieldValue);
        }

        /// <summary>
        /// Проверка метода съедания кусочка сыра
        /// </summary>
        [TestMethod]
        public void EatCheeseTest()
        {
            ModelGame modelGame = new ModelGame();
            CheeseManager cheeseManager = modelGame.CheeseManager;
            cheeseManager.Reset();

            cheeseManager.EatCheese(1, 1);

            bool actualCheeseFieldValue = cheeseManager.GetCheeseFieldValue(1, 1);
            bool expectedCheeseFieldValue = false;

            Assert.AreEqual(expectedCheeseFieldValue, actualCheeseFieldValue);
        }
    }
}
