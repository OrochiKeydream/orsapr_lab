using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, рисующий линии для эскиза клавиши МИ-БЕМОЛЬ (Eb).
    /// </summary>
    public class KeyCreatorEb : KeyCreatorBase
    {
        /// <summary>
        /// Метод, рисующий линии для эскиза клавиши МИ-БЕМОЛЬ (Eb).
        /// </summary>
        public override void Build()
        {
            Sketch.ksLineSeg(MarginLeft + 0.375, - 5.5, MarginLeft
                + 0.375, - 15.5, 1);
            Sketch.ksLineSeg(MarginLeft + 0.375, - 15.5, MarginLeft
                - 0.725, - 15.5, 1);
            Sketch.ksLineSeg(MarginLeft - 0.725, - 15.5, MarginLeft
                - 0.725, - 5.5, 1);
            Sketch.ksLineSeg(MarginLeft - 0.725, - 5.5, MarginLeft
                + 0.375, - 5.5, 1);
        }

        public KeyCreatorEb(ksDocument2D sketch, double marginLeft)
            : base(sketch, marginLeft)
        {

        }
    }
}
