using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestCheesyPursuit
{
    [TestClass]
    public class CatManagerTests
    {
        /// <summary>
        /// Проверка наличия следующего элемента массива кошек игры
        /// </summary>
        [TestMethod]
        public void HasNextCatTest()
        {
            ModelGame modelGame = new ModelGame();
            CatManager catManager = modelGame.CatManager;

            int numberCats = 0;

            catManager.InitCats(numberCats);

            bool expectedHasNextCat = false;
            bool actualHasNextCat = catManager.HasNextCat();
            
            Assert.AreEqual(expectedHasNextCat, actualHasNextCat);
        }

        /// <summary>
        /// Проверка количества элементов массива кошек после выполнения метода инициализации
        /// </summary>
        [TestMethod]
        public void InitCatsTest()
        {
            ModelGame modelGame = new ModelGame();
            CatManager catManager = modelGame.CatManager;

            int numberCats = 5;

            catManager.InitCats(numberCats);

            int expectedArrayCatsSize = numberCats;

            int actualArrayCatsSize = 0;
            while (catManager.HasNextCat())
            {
                catManager.MoveCat();
                actualArrayCatsSize++;
            }
            
            Assert.AreEqual(expectedArrayCatsSize, actualArrayCatsSize);
        }

        /// <summary>
        /// Проверка количества элементов массива кошек 
        /// после выполнения метода перезагрузки объекта управления кошками 
        /// </summary>
        [TestMethod]
        public void ResetTest()
        {
            ModelGame modelGame = new ModelGame();
            CatManager catManager = modelGame.CatManager;

            catManager.Reset();

            int expectedArrayCatsSize = 0;

            int actualArrayCatsSize = 0;
            while (catManager.HasNextCat())
            {
                catManager.MoveCat();
                actualArrayCatsSize++;
            }

            Assert.AreEqual(expectedArrayCatsSize, actualArrayCatsSize);
        }
    }
}
