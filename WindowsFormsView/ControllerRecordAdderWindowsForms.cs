using Controller;
using Model;

namespace WindowsForms
{
    /// <summary>
    /// Контроллер-состояние добавления нового рекорда Windows Forms
    /// </summary>
    public class ControllerRecordAdderWindowsForms : ControllerRecordAdderState
    {
        /// <summary>
        /// Создание контроллера-состояние добавления нового рекорда Windows Forms
        /// </summary>
        /// <param name="parControllerProgram">Управляющий контроллер</param>
        /// <param name="parModelRecords">Модель рекордов</param>
        public ControllerRecordAdderWindowsForms(ControllerProgram parControllerProgram, ModelRecords parModelRecords) : base(parControllerProgram, parModelRecords)
        {
        }

        public override void Start()
        {
            ((ViewRecordAdderWindowsForms)_viewRecordAdder).KeyDownTextBox += ControllerRecordAdderWindowsForms_KeyDownTextBox;
            _viewRecordAdder.Show();
        }

        public override void Stop()
        {
            ((ViewRecordAdderWindowsForms)_viewRecordAdder).KeyDownTextBox -= ControllerRecordAdderWindowsForms_KeyDownTextBox;
            _viewRecordAdder.Close();
        }

        /// <summary>
        /// Обработчик нажатия кнопки клавиатуры на TextBox
        /// </summary>
        /// <param name="parString">Введенная пользователем строка</param>
        private void ControllerRecordAdderWindowsForms_KeyDownTextBox(string parString)
        {
            int gamePoints = ((ModelGame)(ControllerProgram.ControllerGameState.Model)).NumberGamePoints;
            _modelRecords.ListRecords.Add(new Model.GameClasses.Record(parString, gamePoints));
            _modelRecords.WriteToFile();
            ChangeOnControllerMenuState();
        }
    }
}
