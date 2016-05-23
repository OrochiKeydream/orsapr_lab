﻿using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, рисующий линии для эскиза клавиши РЕ (D).
    /// </summary>
    public class KeyCreatorD : KeyCreatorBase
    {
        private ksDocument2D _sketch;
        private double _marginLeft;
        private double _marginFront;

        /// <summary>
        /// Метод, рисующий линии для эскиза клавиши РЕ (D).
        /// </summary>
        /// <param name="sketch">Указатель на эскиз.</param>
        /// <param name="marginLeft">Отступ слева.</param>
        /// <param name="marginFront">Фронтальный отступ.</param>
        public override void Build()
        {
            _sketch.ksLineSeg(_marginLeft, - _marginFront, _marginLeft,
                - 5.3, 1);
            _sketch.ksLineSeg(_marginLeft, - 5.3, _marginLeft - 0.45, - 5.3,
                1);
            _sketch.ksLineSeg(_marginLeft - 0.45, - 5.3, _marginLeft - 0.45,
                - 15.5, 1);
            _sketch.ksLineSeg(_marginLeft - 0.45, - 15.5, _marginLeft - 1.75,
                - 15.5, 1);
            _sketch.ksLineSeg(_marginLeft - 1.75, - 15.5, _marginLeft - 1.75,
                - 5.3, 1);
            _sketch.ksLineSeg(_marginLeft - 1.75, - 5.3, _marginLeft - 2.2,
                - 5.3, 1);
            _sketch.ksLineSeg(_marginLeft - 2.2, - 5.3, _marginLeft - 2.2,
                - _marginFront, 1);
            _sketch.ksLineSeg(_marginLeft - 2.2, - _marginFront, _marginLeft,
                - _marginFront, 1);
        }

        public KeyCreatorD(ksDocument2D sketch, double marginLeft, double marginFront)
        {
            _sketch = sketch;
            _marginLeft = marginLeft;
            _marginFront = marginFront;
        }
    }
}