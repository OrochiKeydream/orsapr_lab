using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, рисующий линии для эскиза клавиши СОЛЬ-БЕМОЛЬ (Gb).
    /// </summary>
    public class KeyCreatorGb : KeyCreatorBase
    {
        /// <summary>
        /// Метод, рисующий линии для эскиза клавиши СОЛЬ-БЕМОЛЬ (Gb).
        /// </summary>
        public override void Build()
        {
            Sketch.ksLineSeg(MarginLeft + 0.95, - 5.5, MarginLeft + 0.95,
                - 15.5, 1);
            Sketch.ksLineSeg(MarginLeft + 0.95, - 15.5, MarginLeft - 0.15,
                - 15.5, 1);
            Sketch.ksLineSeg(MarginLeft - 0.15, - 15.5, MarginLeft - 0.15,
                - 5.5, 1);
            Sketch.ksLineSeg(MarginLeft - 0.15, - 5.5, MarginLeft + 0.95,
                - 5.5, 1);
        }

        public KeyCreatorGb(ksDocument2D sketch, double marginLeft)
            : base(sketch, marginLeft)
        {

        }
    }
}
