using System.Windows.Forms;

namespace WindowsForms
{
    /// <summary>
    /// Нажата кнопка клавиатуры
    /// </summary>
    /// <param name="parE">KeyEventArgs</param>
    public delegate void dKeyDown(KeyEventArgs parE);

    /// <summary>
    /// Нажата кнопка клавиатуры на TextBox
    /// </summary>
    /// <param name="parString">Введенная пользователем строка</param>
    public delegate void dKeyDownTextBox(string parString);

    /// <summary>
    /// Общие ресурсы представлений Windows Forms
    /// </summary>
    public static class ViewResource
    {
        /// <summary>
        /// Интервал отрисовки представления игрового процесса
        /// </summary>
        public const int TIMEOUT = 10;

        /// <summary>
        /// Ширина основной формы программы
        /// </summary>
        public const int WIDTH_FORM = 400;

        /// <summary>
        /// Высота основной формы программы
        /// </summary>
        public const int HEIGHT_FORM = 450;

        /// <summary>
        /// Ширина диалогового окна
        /// </summary>
        public const int WIDTH_FORM_DIALOG = 300;

        /// <summary>
        /// Высота диалогового окна
        /// </summary>
        public const int HEIGHT_FORM_DIALOG = 200;

        /// <summary>
        /// Смещение игрового объекта
        /// </summary>
        public const int OFFSET = 40;

        /// <summary>
        /// Смещение кнопки меню по оси X
        /// </summary>
        public const int OFFSET_BUTTON_X = 130;

        /// <summary>
        /// Смещение кнопки меню по оси Y
        /// </summary>
        public const int OFFSET_BUTTON_Y = 80;

        /// <summary>
        /// Ширина кнопки меню
        /// </summary>
        public const int WIDTH_BUTTON = 120;

        /// <summary>
        /// Высота кнопки меню
        /// </summary>
        public const int HEIGHT_BUTTON = 40;

        /// <summary>
        /// Размер шрифта программы
        /// </summary>
        public const int FONT_SIZE = 16;

        /// <summary>
        /// Ширина поля ввода текста
        /// </summary>
        public const int WIDTH_TEXT_BOX = 200;

        /// <summary>
        /// Высота поля ввода текта
        /// </summary>
        public const int HEIGHT_TEXT_BOX = 20;

        /// <summary>
        /// Смещение поля ввода по оси X
        /// </summary>
        public const int X_TEXT_BOX = 50;

        /// <summary>
        /// Смещение поля ввода по оси Y
        /// </summary>
        public const int Y_TEXT_BOX = 100;

        /// <summary>
        /// Смещение текста справки
        /// </summary>
        public const int TEXT_HELP = 10;

        /// <summary>
        /// Смещение сообщения при добавлении нового рекорда по оси X
        /// </summary>
        public const int RECORD_ADDER_X = 65;

        /// <summary>
        /// Смещение сообщения при добавлении нового рекорда по оси Y
        /// </summary>
        public const int RECORD_ADDER_Y = 30;

        /// <summary>
        /// Смещение записи о рекорде по оси X
        /// </summary>
        public const int OFFSET_RECORD_X = 90;
    }
}
