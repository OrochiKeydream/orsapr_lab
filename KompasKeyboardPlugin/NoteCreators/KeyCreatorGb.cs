using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, рисующий линии для эскиза клавиши СОЛЬ-БЕМОЛЬ (Gb).
    /// </summary>
    public class KeyCreatorGb : KeyCreatorBase
    {
        private ksDocument2D _sketch;
        private double _marginLeft;

        /// <summary>
        /// Метод, рисующий линии для эскиза клавиши СОЛЬ-БЕМОЛЬ (Gb).
        /// </summary>
        /// <param name="sketch">Указатель на эскиз.</param>
        /// <param name="marginLeft">Отступ слева.</param>
        /// <param name="marginFront">Фронтальный отступ.</param>
        public override void Build()
        {
            _sketch.ksLineSeg(_marginLeft + 0.95, - 5.5, _marginLeft + 0.95,
                - 15.5, 1);
            _sketch.ksLineSeg(_marginLeft + 0.95, - 15.5, _marginLeft - 0.15,
                - 15.5, 1);
            _sketch.ksLineSeg(_marginLeft - 0.15, - 15.5, _marginLeft - 0.15,
                - 5.5, 1);
            _sketch.ksLineSeg(_marginLeft - 0.15, - 5.5, _marginLeft + 0.95,
                - 5.5, 1);
        }

        public KeyCreatorGb(ksDocument2D sketch, double marginLeft)
        {
            _sketch = sketch;
            _marginLeft = marginLeft;
        }
    }
}
