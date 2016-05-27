using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, рисующий линии для эскиза последней клавиши ДО (C).
    /// Поскольку у клавиши ДО есть вырез для клавиши РЕ-БЕМОЛЬ,
    /// а клавиша ДО может оказаться последней в секции, то
    /// необходимо сделать эскиз клавиши, котрая не
    /// предусматривает выреза.
    /// </summary>
    public class KeyCreatorCAdditional : KeyCreatorBase
    {
        private readonly double _marginFront;

        /// <summary>
        /// Метод, рисующий линии для эскиза последней клавиши ДО (C).
        /// </summary>
        public override void Build()
        {
            Sketch.ksLineSeg(MarginLeft, - _marginFront, MarginLeft,
                - 15.5, 1);
            Sketch.ksLineSeg(MarginLeft, - 15.5, MarginLeft - 2.2, - 15.5,
                1);
            Sketch.ksLineSeg(MarginLeft - 2.2, - 15.5, MarginLeft - 2.2,
                - _marginFront, 1);
            Sketch.ksLineSeg(MarginLeft - 2.2, - _marginFront, MarginLeft,
                - _marginFront, 1);
        }

        public KeyCreatorCAdditional(ksDocument2D sketch, double marginLeft,
            double marginFront) : base(sketch, marginLeft)
        {
            _marginFront = marginFront;
        }
    }
}
