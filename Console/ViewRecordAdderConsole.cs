using Model;
using View;

namespace Console
{
    /// <summary>
    /// Представление добавления нового рекорда Console
    /// </summary>
    public class ViewRecordAdderConsole : ViewRecord
    {
        /// <summary>
        /// Создания представления добавления нового рекорда Console
        /// </summary>
        /// <param name="parModelRecords">Модель рекордов</param>
        public ViewRecordAdderConsole(ModelRecords parModelRecords) : base(parModelRecords)
        {
        }

        public override void Show()
        {
            DrawRecordAdder();
        }

        public override void Close()
        {
            ConsoleOutput.Clear();
        }

        /// <summary>
        /// Нарисовать представление добавления нового рекорда игры
        /// </summary>
        private void DrawRecordAdder()
        {
            System.Console.CursorVisible = true;
            System.Console.SetCursorPosition(ViewResource.OFFSET_CURSOR_X, ViewResource.OFFSET_CURSOR_Y);
            ConsoleOutput.Write("Введите имя и нажмите Enter:", ViewResource.OFFSET_RECORD_ADDER_STRING_X, ViewResource.OFFSET_RECORD_ADDER_STRING_Y, System.ConsoleColor.Yellow);
            ConsoleOutput.PrintOnConsole();
        }
    }
}
