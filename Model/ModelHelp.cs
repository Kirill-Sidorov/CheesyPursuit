using System;
using System.Text;

namespace Model
{
    /// <summary>
    /// Модель справки игры
    /// </summary>
    public class ModelHelp : IModel
    {
        /// <summary>
        /// Текст справки
        /// </summary>
        private String _text;

        /// <summary>
        /// Текст справки
        /// </summary>
        public String Text => _text;

        /// <summary>
        /// Создание справки игры
        /// </summary>
        public ModelHelp()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" Игровое меню: перемещение по пунктам ");
            stringBuilder.Append("\n");
            stringBuilder.Append("меню - стрелкам вверх и вниз; выбор  ");
            stringBuilder.Append("\n");
            stringBuilder.Append("пункта меню - Enter, выход - Esc.    ");
            stringBuilder.Append("\n");
            stringBuilder.Append(" Цель игры: съесть весь сыр на игро- ");
            stringBuilder.Append("\n");
            stringBuilder.Append("вом поле и не попасться кошкам.      ");
            stringBuilder.Append("\n");
            stringBuilder.Append(" Игра: после выбора пункта \"Играть\" ");
            stringBuilder.Append("\n");
            stringBuilder.Append("появляется игровое поле и для старта ");
            stringBuilder.Append("\n");
            stringBuilder.Append("игры необходимо нажать на любую      ");
            stringBuilder.Append("\n");
            stringBuilder.Append("стрелку клавиатуры; упраление мышью  ");
            stringBuilder.Append("\n");
            stringBuilder.Append("осуществляется стрелками клавиатуры; ");
            stringBuilder.Append("\n");
            stringBuilder.Append("после того как весь сыр на игровом   ");
            stringBuilder.Append("\n");
            stringBuilder.Append("поле будет съеден - начнется новая   ");
            stringBuilder.Append("\n");
            stringBuilder.Append("игра, в которой количество кошек     ");
            stringBuilder.Append("\n");
            stringBuilder.Append("увеличится на 1 (текущее количество  ");
            stringBuilder.Append("\n");
            stringBuilder.Append("кошек отображется на игровом  поле); ");
            stringBuilder.Append("\n");
            stringBuilder.Append("игра заканчивается, если кошка ловит ");
            stringBuilder.Append("\n");
            stringBuilder.Append("мышь; в игре побеждает тот, кто съест ");
            stringBuilder.Append("\n");
            stringBuilder.Append("больше всего сыра (лучшие результаты ");
            stringBuilder.Append("\n");
            stringBuilder.Append("попадают в таблицу рекордов); выход ");
            stringBuilder.Append("\n");
            stringBuilder.Append("в меню во время игрового  процесса  ");
            stringBuilder.Append("\n");
            stringBuilder.Append("недоступен.");
            stringBuilder.Append("\n");
            _text = stringBuilder.ToString();
        }
    }
}
