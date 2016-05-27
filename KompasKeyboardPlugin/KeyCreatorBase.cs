using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Базовый класс для построения клавиши.
    /// </summary>
    public abstract class KeyCreatorBase
    {
        /// <summary>
        /// Поля класса.
        /// </summary>
        protected readonly ksDocument2D Sketch;
        protected readonly double MarginLeft;

        /// <summary>
        /// Метод для построения клавиши.
        /// </summary>
        public abstract void Build();

        /// <summary>
        /// Базовый конструктор, инициализирующий одинаковые для всех клавиш
        /// поля.
        /// </summary>
        /// <param name="sketch">Эскиз</param>
        /// <param name="marginLeft">Динамический отступ слева</param>
        protected KeyCreatorBase(ksDocument2D sketch, double marginLeft)
        {
            Sketch = sketch;
            MarginLeft = marginLeft;
        }
    }
}
