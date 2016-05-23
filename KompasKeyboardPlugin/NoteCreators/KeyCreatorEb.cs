﻿using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, рисующий линии для эскиза клавиши МИ-БЕМОЛЬ (Eb).
    /// </summary>
    public class KeyCreatorEb : KeyCreatorBase
    {
        private ksDocument2D _sketch;
        double _marginLeft;

        /// <summary>
        /// Метод, рисующий линии для эскиза клавиши МИ-БЕМОЛЬ (Eb).
        /// </summary>
        /// <param name="sketch">Указатель на эскиз.</param>
        /// <param name="marginLeft">Отступ слева.</param>
        /// <param name="marginFront">Фронтальный отступ.</param>
        public override void Build()
        {
            _sketch.ksLineSeg(_marginLeft + 0.375, - 5.5, _marginLeft
                + 0.375, - 15.5, 1);
            _sketch.ksLineSeg(_marginLeft + 0.375, - 15.5, _marginLeft
                - 0.725, - 15.5, 1);
            _sketch.ksLineSeg(_marginLeft - 0.725, - 15.5, _marginLeft
                - 0.725, - 5.5, 1);
            _sketch.ksLineSeg(_marginLeft - 0.725, - 5.5, _marginLeft
                + 0.375, - 5.5, 1);
        }

        public KeyCreatorEb(ksDocument2D sketch, double marginLeft)
        {
            _sketch = sketch;
            _marginLeft = marginLeft;
        }
    }
}