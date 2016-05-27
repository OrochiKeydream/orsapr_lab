using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, рисующий линии для эскиза клавиши ЛЯ (A).
    /// </summary>
    public class KeyCreatorA : KeyCreatorBase
    {
        private readonly double _marginFront;

        /// <summary>
        /// Метод, рисующий линии для эскиза клавиши ЛЯ (A).
        /// </summary>
        public override void Build()
        {
            Sketch.ksLineSeg(MarginLeft, - _marginFront, MarginLeft,
                - 5.3, 1);
            Sketch.ksLineSeg(MarginLeft, - 5.3, MarginLeft - 0.7, - 5.3,
                1);
            Sketch.ksLineSeg(MarginLeft - 0.7, - 5.3, MarginLeft - 0.7,
                - 15.5, 1);
            Sketch.ksLineSeg(MarginLeft - 0.7, - 15.5, MarginLeft - 1.9,
                - 15.5, 1);
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
        public KeyCreatorA(ksDocument2D sketch, double marginLeft,
            double marginFront) : base(sketch, marginLeft)
        {
            _marginFront = marginFront;
        }
    }
}
