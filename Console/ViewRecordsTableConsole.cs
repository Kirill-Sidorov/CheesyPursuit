using Model;
using View;

namespace Console
{
    /// <summary>
    /// Представление таблицы рекордов Console
    /// </summary>
    public class ViewRecordsTableConsole : ViewRecord
    {
        /// <summary>
        /// Создания представления таблицы рекордов Console
        /// </summary>
        /// <param name="parModelRecords">Модель рекордов</param>
        public ViewRecordsTableConsole(ModelRecords parModelRecords) : base(parModelRecords)
        {
        }

        public override void Show()
        {
            DrawTable();
        }

        public override void Close()
        {
            ConsoleOutput.Clear();
        }

        /// <summary>
        /// Нарисовать таблицу рекордов
        /// </summary>
        private void DrawTable()
        {
            int offsetY = 1;
            ConsoleOutput.Write("Имя игрока - очки", ViewResource.OFFSET_RECORD_X, offsetY, System.ConsoleColor.Yellow);
            foreach (Model.GameClasses.Record record in _modelRecords.ListRecords)
            {
                offsetY += 1;
                ConsoleOutput.Write(record.Name + " - " + record.Score, ViewResource.OFFSET_RECORD_X, offsetY, System.ConsoleColor.Yellow);
            }
            ConsoleOutput.PrintOnConsole();
        }
    }
}
