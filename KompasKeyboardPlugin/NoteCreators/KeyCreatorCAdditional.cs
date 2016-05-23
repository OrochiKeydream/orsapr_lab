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
        private ksDocument2D _sketch;
        private double _marginLeft;
        private double _marginFront;

        /// <summary>
        /// Метод, рисующий линии для эскиза последней клавиши ДО (C).
        /// </summary>
        /// <param name="sketch">Указатель на эскиз.</param>
        /// <param name="marginLeft">Отступ слева.</param>
        /// <param name="marginFront">Фронтальный отступ.</param>
        public override void Build()
        {
            _sketch.ksLineSeg(_marginLeft, - _marginFront, _marginLeft,
                - 15.5, 1);
            _sketch.ksLineSeg(_marginLeft, - 15.5, _marginLeft - 2.2, - 15.5,
                1);
            _sketch.ksLineSeg(_marginLeft - 2.2, - 15.5, _marginLeft - 2.2,
                - _marginFront, 1);
            _sketch.ksLineSeg(_marginLeft - 2.2, - _marginFront, _marginLeft,
                - _marginFront, 1);
        }

        public KeyCreatorCAdditional(ksDocument2D sketch, double marginLeft, double marginFront)
        {
            _sketch = sketch;
            _marginLeft = marginLeft;
            _marginFront = marginFront;
        }
    }
}
