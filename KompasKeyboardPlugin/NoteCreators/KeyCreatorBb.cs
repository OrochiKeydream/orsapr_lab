using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, рисующий линии для эскиза клавиши СИ-БЕМОЛЬ (Bb).
    /// </summary>
    public class KeyCreatorBb : KeyCreatorBase
    {
        /// <summary>
        /// Метод, рисующий линии для эскиза клавиши СИ-БЕМОЛЬ (Bb).
        /// </summary>
        public override void Build()
        {
            Sketch.ksLineSeg(MarginLeft + 0.25, - 5.5, MarginLeft + 0.25,
                - 15.5, 1);
            Sketch.ksLineSeg(MarginLeft + 0.25, - 15.5, MarginLeft - 0.85,
                - 15.5, 1);
            Sketch.ksLineSeg(MarginLeft - 0.85, - 15.5, MarginLeft - 0.85,
                - 5.5, 1);
            Sketch.ksLineSeg(MarginLeft - 0.85, - 5.5, MarginLeft + 0.25,
                - 5.5, 1);
        }

        public KeyCreatorBb(ksDocument2D sketch, double marginLeft)
            : base(sketch, marginLeft)
        {

        }
    }
}
