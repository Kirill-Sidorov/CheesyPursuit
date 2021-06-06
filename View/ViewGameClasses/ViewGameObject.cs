namespace View
{
    /// <summary>
    /// Общий класс-представление объектов игры
    /// </summary>
    public abstract class ViewGameObject
    {
        /// <summary>
        /// Смещение по оси x
        /// </summary>
        protected int _offsetX;

        /// <summary>
        /// Смещение по оси y
        /// </summary>
        protected int _offsetY;

        /// <summary>
        /// Создание представления объекта игры
        /// </summary>
        /// <param name="parOffsetX">Смещение по оси x</param>
        /// <param name="parOffsetY">Смещение по оси y</param>
        public ViewGameObject(int parOffsetX, int parOffsetY)
        {
            _offsetX = parOffsetX;
            _offsetY = parOffsetY;
        }

        /// <summary>
        /// Нарисовать объект
        /// </summary>
        public abstract void Draw();
    }
}
