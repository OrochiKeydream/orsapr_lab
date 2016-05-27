using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, рисующий линии для эскиза клавиши ЛЯ-БЕМОЛЬ (Ab).
    /// </summary>
    public class KeyCreatorAb : KeyCreatorBase
    {
        /// <summary>
        /// Метод, рисующий линии для эскиза клавиши ЛЯ-БЕМОЛЬ (Ab).
        /// </summary>
        /// <param name="sketch">Указатель на эскиз.</param>
        /// <param name="marginLeft">Отступ слева.</param>
        /// <param name="marginFront">Фронтальный отступ.</param>
        public override void Build()
        {
            Sketch.ksLineSeg(MarginLeft + 0.575, - 5.5, MarginLeft
                + 0.575, - 15.5, 1);
            Sketch.ksLineSeg(MarginLeft + 0.575, - 15.5, MarginLeft
                - 0.525, - 15.5, 1);
            Sketch.ksLineSeg(MarginLeft - 0.525, - 15.5, MarginLeft
                - 0.525, - 5.5, 1);
            Sketch.ksLineSeg(MarginLeft - 0.525, - 5.5, MarginLeft
                + 0.575, - 5.5, 1);
        }

        public KeyCreatorAb(ksDocument2D sketch, double marginLeft)
            : base(sketch, marginLeft)
        {

        }
    }
}
