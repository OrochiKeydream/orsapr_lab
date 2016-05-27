using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, рисующий линии для эскиза первой клавиши ЛЯ (A).
    /// Поскольку у клавиши ЛЯ есть вырез для клавиши СОЛЬ-БЕМОЛЬ,
    /// а клавиша ЛЯ может оказаться первой в секции, то
    /// необходимо сделать эскиз клавиши, котрая не
    /// предусматривает выреза для клавиши СОЛЬ-БЕМОЛЬ.
    /// </summary>
    public class KeyCreatorAAdditional : KeyCreatorBase
    {
        private readonly double _marginFront;

        /// <summary>
        /// Метод, рисующий линии для эскиза первой клавиши ЛЯ (A).
        /// </summary>
        /// <param name="sketch">Указатель на эскиз.</param>
        /// <param name="marginLeft">Отступ слева.</param>
        /// <param name="marginFront">Фронтальный отступ.</param>
        public override void Build()
        {
            Sketch.ksLineSeg(MarginLeft, - _marginFront, MarginLeft,
                - 15.5, 1);
            Sketch.ksLineSeg(MarginLeft, - 15.5, MarginLeft - 1.9, - 15.5,
                1);
            Sketch.ksLineSeg(MarginLeft - 1.9, - 15.5, MarginLeft - 1.9,
                - 5.3, 1);
            Sketch.ksLineSeg(MarginLeft - 1.9, - 5.3, MarginLeft - 2.2,
                - 5.3, 1);
            Sketch.ksLineSeg(MarginLeft - 2.2, - 5.3, MarginLeft - 2.2,
                - _marginFront, 1);
            Sketch.ksLineSeg(MarginLeft - 2.2, - _marginFront, MarginLeft,
                - _marginFront, 1);
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="sketch">Эскиз</param>
        /// <param name="marginLeft">Отступ слева</param>
        /// <param name="marginFront">Фронтальный отступ</param>
        public KeyCreatorAAdditional(ksDocument2D sketch, double marginLeft,
            double marginFront) : base(sketch, marginLeft)
        {
            _marginFront = marginFront;
        }
    }
}
