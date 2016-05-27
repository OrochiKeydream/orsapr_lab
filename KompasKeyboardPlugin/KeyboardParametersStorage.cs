using System;
using System.Windows.Forms;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, хранящий данные о клавиатуре.
    /// </summary>
    public class KeyboardParametersStorage
    {
        #region Поля класса.

        #region Константы класса.

        private const int keyAmountLow = 61;
        private const int keyAmountMiddle = 76;
        private const int keyAmountHigh = 88;

        private const double bodyLengthHighMax = 150.0;
        private const double bodyLengthHighMin = 125.0;

        private const double bodyLengthMiddleMax = 140.0;
        private const double bodyLengthMiddleMin = 110.0;

        private const double bodyLengthLowMax = 130.0;
        private const double bodyLengthLowMin = 90.0;

        private const double bodyHeightMax = 20.0;
        private const double bodyHeightMin = 5.0;

        private const double bodyDepthMax = 40.0;
        private const double bodyDepthMin = 20.0;

        private const int xlrSocketsMax = 4;
        private const int xlrSocketsMin = 0;

        private const int trsSocketsMax = 6;
        private const int trsSocketsMin = 0;

        private const int midiSocketsMax = 3;
        private const int midiSocketsMin = 0;

        private const double boardLengthLow = 82.9;
        private const double boardLengthMiddle = 103.6;
        private const double boardLengthHigh = 119.7;

        private const int whiteKeyAmountLow = 36;
        private const int whiteKeyAmountMiddle = 45;
        private const int whiteKeyAmountHigh = 52;

        private const int blackKeyAmountLow = keyAmountLow
            - whiteKeyAmountLow;
        private const int blackKeyAmountMiddle = keyAmountMiddle
            - whiteKeyAmountMiddle;
        private const int blackKeyAmountHigh = keyAmountHigh
            - whiteKeyAmountHigh;

        private const string bodyLenghtString = "\"Длина корпуса\"";
        private const string bodyHeightString = "\"Высота корпуса\"";
        private const string bodyDepthString = "\"Глубина корпуса\"";
        private const string xlrSocketsString = "\"Количество разъемов XLR\"";
        private const string trsSocketsString = "\"Количество разъемов TRS\"";
        private const string midiSocketsString = "\"Количество разъемов MIDI\"";

        #endregion

        /// <summary>
        /// Поля, содержащие параметры корпуса.
        /// </summary>
        private double _bodyLength;
        private double _bodyHeight;
        private double _bodyDepth;

        public double BodyLength => _bodyLength;
        public double BodyHeight => _bodyHeight;
        public double BodyDepth => _bodyDepth;

        /// <summary>
        /// Поля, отражающие наличие элементов на панели управления.
        /// </summary>
        private bool _panelDisplay;
        private bool _panelButtons;
        private bool _panelKnobs;
        private WheelSetup _panelWheel;

        public bool PanelDisplay => _panelDisplay;
        public bool PanelButtons => _panelButtons;
        public bool PanelKnobs => _panelKnobs;
        public WheelSetup PanelWheel => _panelWheel;

        /// <summary>
        /// Поля, отражающие количество разъемов коммутационной панели.
        /// </summary>
        private int _commutationXLRSockets;
        private int _commutationTRSSockets;
        private int _commutationMIDISockets;

        public int CommutationXLR => _commutationXLRSockets;
        public int CommutationTRS => _commutationTRSSockets;
        public int CommutationMIDI => _commutationMIDISockets;

        /// <summary>
        /// Поля, содержащие параметры клавиатурной секции.
        /// </summary>
        private KeyboardType _keyboardType;
        private int _keyboardKeyAmount;
        private double _boardLength;

        private int _whiteKeyAmount;
        private int _blackKeyAmount;

        public KeyboardType KeyboardType => _keyboardType;
        public int KeyboardKeyAmount => _keyboardKeyAmount;
        public double BoardLength => _boardLength;

        public int WhiteKeyAmount => _whiteKeyAmount;
        public int BlackKeyAmount => _blackKeyAmount;

        #endregion

        /// <summary>
        /// Метод, записывающий данные в поля класса.
        /// </summary>
        /// <param name="bodyLength">Длина клавиатуры.</param>
        /// <param name="bodyHeight">Высота клавиатуры.</param>
        /// <param name="bodyDepth">Глубина клавиатуры.</param>
        /// <param name="panelDisplay">Наличие дисплея.</param>
        /// <param name="panelButtons">Наличие кнопок.</param>
        /// <param name="panelKnobs">Наличие ручек.</param>
        /// <param name="panelWheel">Наличие колеса модуляции.</param>
        /// <param name="commutationXLRSockets">Количество разъемов XLR.</param>
        /// <param name="commutationTRSSockets">Количество разъемов TRS.</param>
        /// <param name="commutationMIDISockets">Количество разъемов MIDI.</param>
        /// <param name="keyboardType">Тип клавиатуры.</param>
        /// <param name="keyboardKeyAmount">Количество клавиш.</param>
        public void Record(double bodyLength, double bodyHeight,
            double bodyDepth, bool panelDisplay, bool panelButtons,
            bool panelKnobs, bool panelWheel, int commutationXLRSockets,
            int commutationTRSSockets, int commutationMIDISockets,
            KeyboardType keyboardType, KeysAmountMode keyAmount)
        {
            if (!Validation(bodyHeight, bodyHeightMax, bodyHeightMin,
                bodyHeightString))
            {
                throw new ArgumentException();
            }
            _bodyHeight = bodyHeight;

            if (!Validation(bodyDepth, bodyDepthMax, bodyDepthMin,
                bodyDepthString))
            {
                throw new ArgumentException();
            }
            _bodyDepth = bodyDepth;

            switch (keyAmount)
            {
                case KeysAmountMode.Low:
                    {
                        if (!Validation(bodyLength, bodyLengthLowMax,
                            bodyLengthLowMin, bodyLenghtString))
                        {
                            throw new ArgumentException();
                        }
                        _bodyLength = bodyLength;
                        _keyboardKeyAmount = keyAmountLow;
                        _boardLength = boardLengthLow;
                        _whiteKeyAmount = whiteKeyAmountLow;
                        _blackKeyAmount = blackKeyAmountLow;

                        break;
                    }
                case KeysAmountMode.Middle:
                    {
                        if (!Validation(bodyLength, bodyLengthMiddleMax,
                            bodyLengthMiddleMin, bodyLenghtString))
                        {
                            throw new ArgumentException();
                        }
                        _bodyLength = bodyLength;
                        _keyboardKeyAmount = keyAmountMiddle;
                        _boardLength = boardLengthMiddle;
                        _whiteKeyAmount = whiteKeyAmountMiddle;
                        _blackKeyAmount = blackKeyAmountMiddle;

                        break;
                    }
                case KeysAmountMode.High:
                    {
                        if (!Validation(bodyLength, bodyLengthHighMax,
                            bodyLengthHighMin, bodyLenghtString))
                        {
                            throw new ArgumentException();
                        }
                        _bodyLength = bodyLength;
                        _keyboardKeyAmount = keyAmountHigh;
                        _boardLength = boardLengthHigh;
                        _whiteKeyAmount = whiteKeyAmountHigh;
                        _blackKeyAmount = blackKeyAmountHigh;

                        break;
                    }
            }

            _panelDisplay = panelDisplay;
            _panelButtons = panelButtons;
            _panelKnobs = panelKnobs;

            _keyboardType = keyboardType;

            if (panelWheel)
            {
                if (_bodyLength - _boardLength / 2 >= 5.0)
                {
                    _panelWheel = WheelSetup.EnableFront;
                }
                else
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show("Нет места для колеса " +
                                             "модуляции. Расположить" +
                                             " колесо сверху?", "Внимание",
                                             buttons,
                                             MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        _panelWheel = WheelSetup.EnableBack;
                    }
                    else
                    {
                        _panelWheel = WheelSetup.Disable;
                    }
                }
            }
            else
            {
                _panelWheel = WheelSetup.Disable;
            }

            if (!Validation(commutationXLRSockets, xlrSocketsMax,
                xlrSocketsMin, xlrSocketsString))
            {
                throw new ArgumentException();
            }
            _commutationXLRSockets = commutationXLRSockets;

            if (!Validation(commutationTRSSockets, trsSocketsMax,
                trsSocketsMin, trsSocketsString))
            {
                throw new ArgumentException();
            }
            _commutationTRSSockets = commutationTRSSockets;

            if (!Validation(commutationMIDISockets, midiSocketsMax,
                midiSocketsMin, midiSocketsString))
            {
                throw new ArgumentException();
            }
            _commutationMIDISockets = commutationMIDISockets;
        }

        /// <summary>
        /// Метод, проверяющий граничные уловия параметров корпуса.
        /// </summary>
        /// <param name="currentValue">Текущее значение</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <param name="minValue">Минимальное значение</param>
        /// <param name="stringValue">Строка с именем параметра</param>
        /// <returns></returns>
        private bool Validation(double currentValue, double maxValue,
            double minValue, string stringValue)
        {
            if (currentValue > maxValue || currentValue < minValue)
            {
                throw new ArgumentException($"Параметр {stringValue} " +
                                            $"должен быть в диапазоне от " +
                                            $"{minValue} до {maxValue}.");
            }
            return true;
        }

        /// <summary>
        /// Метод, проверяющий граничные условия количества разъемов.
        /// </summary>
        /// <param name="currentValue">Текущее значение</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <param name="minValue">Минимальное значение</param>
        /// <param name="stringValue">Строка с именем параметра</param>
        /// <returns></returns>
        private bool Validation(int currentValue, int maxValue,
            int minValue, string stringValue)
        {
            if (currentValue > maxValue || currentValue < minValue)
            {
                throw new ArgumentException($"Параметра {stringValue} " +
                                            $"должен быть в диапазоне от " +
                                            $"{minValue} до {maxValue}.");
            }
            return true;
        }
    }
}
