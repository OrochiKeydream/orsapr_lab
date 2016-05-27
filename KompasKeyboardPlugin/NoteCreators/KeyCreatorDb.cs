using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, рисующий линии для эскиза клавиши РЕ-БЕМОЛЬ (Db).
    /// </summary>
    public class KeyCreatorDb : KeyCreatorBase
    {
        /// <summary>
        /// Метод, рисующий линии для эскиза клавиши РЕ-БЕМОЛЬ (Db).
        /// </summary>
        public override void Build()
        {
            Sketch.ksLineSeg(MarginLeft + 0.825, - 5.5, MarginLeft
                + 0.825, - 15.5, 1);
            Sketch.ksLineSeg(MarginLeft + 0.825, - 15.5, MarginLeft
                - 0.275, - 15.5, 1);
            Sketch.ksLineSeg(MarginLeft - 0.275, - 15.5, MarginLeft
                - 0.275, - 5.5, 1);
            Sketch.ksLineSeg(MarginLeft - 0.275, - 5.5, MarginLeft
                + 0.825, - 5.5, 1);
        }

        public KeyCreatorDb(ksDocument2D sketch, double marginLeft)
            : base(sketch, marginLeft)
        {

        }
    }
}
