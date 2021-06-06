namespace Model.GameClasses
{
    /// <summary>
    /// Запись о рекорде игры
    /// </summary>
    public class Record
    {
        /// <summary>
        /// Имя игрока
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество очков
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Создание записи о рекорде игры
        /// </summary>
        /// <param name="parName">Имя игрока</param>
        /// <param name="parScore">Количество очков</param>
        public Record(string parName, int parScore)
        {
            Name = parName;
            Score = parScore;
        }
    }
}
