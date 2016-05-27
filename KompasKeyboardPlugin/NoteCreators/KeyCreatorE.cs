using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, рисующий линии для эскиза клавиши МИ (E).
    /// </summary>
    public class KeyCreatorE : KeyCreatorBase
    {
        private readonly double _marginFront;

        /// <summary>
        /// Метод, рисующий линии для эскиза клавиши МИ (E).
        /// </summary>
        public override void Build()
        {
            Sketch.ksLineSeg(MarginLeft, - _marginFront, MarginLeft,
                - 5.3, 1);
            Sketch.ksLineSeg(MarginLeft, - 5.3, MarginLeft - 0.9, - 5.3,
                1);
            Sketch.ksLineSeg(MarginLeft - 0.9, -5.3, MarginLeft - 0.9,
                - 15.5, 1);
            Sketch.ksLineSeg(MarginLeft - 0.9, -15.5, MarginLeft - 2.2,
                - 15.5, 1);
            Sketch.ksLineSeg(MarginLeft - 2.2, -15.5, MarginLeft - 2.2,
                - _marginFront, 1);
            Sketch.ksLineSeg(MarginLeft - 2.2, - _marginFront, MarginLeft,
                - _marginFront, 1);
        }

        public KeyCreatorE(ksDocument2D sketch, double marginLeft,
            double marginFront) : base(sketch, marginLeft)
        {
            _marginFront = marginFront;
        }
    }
}
