using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, рисующий линии для эскиза клавиши ДО (C).
    /// </summary>
    public class KeyCreatorC : KeyCreatorBase
    {
        private readonly double _marginFront;

        /// <summary>
        /// Метод, рисующий линии для эскиза клавиши ДО (C).
        /// </summary>
        public override void Build()
        {
            Sketch.ksLineSeg(MarginLeft, - _marginFront, MarginLeft,
                - 15.5, 1);
            Sketch.ksLineSeg(MarginLeft, - 15.5, MarginLeft - 1.3,
                - 15.5, 1);
            Sketch.ksLineSeg(MarginLeft - 1.3, - 15.5, MarginLeft - 1.3,
                - 5.3, 1);
            Sketch.ksLineSeg(MarginLeft - 1.3, - 5.3, MarginLeft - 2.2,
                - 5.3, 1);
            Sketch.ksLineSeg(MarginLeft - 2.2, - 5.3, MarginLeft - 2.2,
                - _marginFront, 1);
            Sketch.ksLineSeg(MarginLeft - 2.2, - _marginFront, MarginLeft,
                - _marginFront, 1);
        }

        public KeyCreatorC(ksDocument2D sketch, double marginLeft,
            double marginFront) : base(sketch, marginLeft)
        {
            _marginFront = marginFront;
        }
    }
}
