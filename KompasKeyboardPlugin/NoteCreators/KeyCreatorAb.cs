using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, рисующий линии для эскиза клавиши ЛЯ-БЕМОЛЬ (Ab).
    /// </summary>
    public class KeyCreatorAb : KeyCreatorBase
    {
        private ksDocument2D _sketch;
        private double _marginLeft;

        /// <summary>
        /// Метод, рисующий линии для эскиза клавиши ЛЯ-БЕМОЛЬ (Ab).
        /// </summary>
        /// <param name="sketch">Указатель на эскиз.</param>
        /// <param name="marginLeft">Отступ слева.</param>
        /// <param name="marginFront">Фронтальный отступ.</param>
        public override void Build()
        {
            _sketch.ksLineSeg(_marginLeft + 0.575, - 5.5, _marginLeft
                + 0.575, - 15.5, 1);
            _sketch.ksLineSeg(_marginLeft + 0.575, - 15.5, _marginLeft
                - 0.525, - 15.5, 1);
            _sketch.ksLineSeg(_marginLeft - 0.525, - 15.5, _marginLeft
                - 0.525, - 5.5, 1);
            _sketch.ksLineSeg(_marginLeft - 0.525, - 5.5, _marginLeft
                + 0.575, - 5.5, 1);
        }

        public KeyCreatorAb(ksDocument2D sketch, double marginLeft)
        {
            _sketch = sketch;
            _marginLeft = marginLeft;
        }
    }
}
