using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    /// <summary>
    /// Класс хранения единственного экземпляра объетка основной формы программы
    /// </summary>
    public class ViewFormSingleton
    {
        /// <summary>
        /// Экземпляр объекта основной формы программы
        /// </summary>
        private static Form _formInstance;

        /// <summary>
        /// Запрет создания объекта извне
        /// </summary>
        private ViewFormSingleton()
        {
        }

        /// <summary>
        /// Получить экземпляр объекта основной формы программы
        /// </summary>
        /// <returns>Экземпляр объекта формы</returns>
        public static Form GetInstance()
        {
            if (_formInstance == null)
            {
                _formInstance = new Form();
                Size size = new Size(ViewResource.WIDTH_FORM, ViewResource.HEIGHT_FORM);
                _formInstance.MaximumSize = size;
                _formInstance.Size = size;
                _formInstance.StartPosition = FormStartPosition.CenterScreen;
            }
            return _formInstance;
        }
    }
}
