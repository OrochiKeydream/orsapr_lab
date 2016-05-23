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

        public double BodyLength
        {
            get
            {
                return _bodyLength;
            }
        }
        public double BodyHeight
        {
            get
            {
                return _bodyHeight;
            }
        }
        public double BodyDepth
        {
            get
            {
                return _bodyDepth;
            }
        }

        /// <summary>
        /// Поля, отражающие наличие элементов на панели управления.
        /// </summary>
        private bool _panelDisplay;
        private bool _panelButtons;
        private bool _panelKnobs;
        private WheelSetup _panelWheel;

        public bool PanelDisplay
        {
            get
            {
                return _panelDisplay;
            }
        }
        public bool PanelButtons
        {
            get
            {
                return _panelButtons;
            }
        }
        public bool PanelKnobs
        {
            get
            {
                return _panelKnobs;
            }
        }
        public WheelSetup PanelWheel
        {
            get
            {
                return _panelWheel;
            }
        }

        /// <summary>
        /// Поля, отражающие количество разъемов коммутационной панели.
        /// </summary>
        private int _commutationXLRSockets;
        private int _commutationTRSSockets;
        private int _commutationMIDISockets;

        public int CommutationXLR
        {
            get
            {
                return _commutationXLRSockets;
            }
        }
        public int CommutationTRS
        {
            get
            {
                return _commutationTRSSockets;
            }
        }
        public int CommutationMIDI
        {
            get
            {
                return _commutationMIDISockets;
            }
        }

        /// <summary>
        /// Поля, содержащие параметры клавиатурной секции.
        /// </summary>
        private KeyboardType _keyboardType;     // Тип клавиатуры.
        private int _keyboardKeyAmount;         // Количество клавиш.
        private double _boardLength;            // Длина клавиатурной секции.

        private int _whiteKeyAmount;
        private int _blackKeyAmount;

        public KeyboardType KeyboardType
        {
            get
            {
                return _keyboardType;
            }
        }
        public int KeyboardKeyAmount
        {
            get
            {
                return _keyboardKeyAmount;
            }
        }
        public double BoardLength
        {
            get
            {
                return _boardLength;
            }
        }

        public int WhiteKeyAmount
        {
            get
            {
                return _whiteKeyAmount;
            }
        }
        public int BlackKeyAmount
        {
            get
            {
                return _blackKeyAmount;
            }
        }

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
        public int Record(double bodyLength, double bodyHeight,
            double bodyDepth, bool panelDisplay, bool panelButtons,
            bool panelKnobs, bool panelWheel, int commutationXLRSockets,
            int commutationTRSSockets, int commutationMIDISockets,
            KeyboardType keyboardType, KeysAmountMode keyAmount)
        {
            if (!NewValidation(bodyHeight, bodyHeightMax, bodyHeightMin,
                bodyHeightString))
            {
                return 1;
            }
            else
            {
                _bodyHeight = bodyHeight;
            }

            if (!NewValidation(bodyDepth, bodyDepthMax, bodyDepthMin,
                bodyDepthString))
            {
                return 1;
            }
            else
            {
                _bodyDepth = bodyDepth;
            }

            switch (keyAmount)
            {
                case KeysAmountMode.Low:
                    {
                        if (!NewValidation(bodyLength, bodyLengthLowMax,
                            bodyLengthLowMin, bodyLenghtString))
                        {
                            return 1;
                        }
                        else
                        {
                            _bodyLength = bodyLength;
                            _keyboardKeyAmount = keyAmountLow;
                            _boardLength = boardLengthLow;
                            _whiteKeyAmount = whiteKeyAmountLow;
                            _blackKeyAmount = blackKeyAmountLow;

                            break;
                        }
                    }
                case KeysAmountMode.Middle:
                    {
                        if (!NewValidation(bodyLength, bodyLengthMiddleMax,
                            bodyLengthMiddleMin, bodyLenghtString))
                        {
                            return 1;
                        }
                        else
                        {
                            _bodyLength = bodyLength;
                            _keyboardKeyAmount = keyAmountMiddle;
                            _boardLength = boardLengthMiddle;
                            _whiteKeyAmount = whiteKeyAmountMiddle;
                            _blackKeyAmount = blackKeyAmountMiddle;

                            break;
                        }
                    }
                case KeysAmountMode.High:
                    {
                        if (!NewValidation(bodyLength, bodyLengthHighMax,
                            bodyLengthHighMin, bodyLenghtString))
                        {
                            return 1;
                        }
                        else
                        {
                            _bodyLength = bodyLength;
                            _keyboardKeyAmount = keyAmountHigh;
                            _boardLength = boardLengthHigh;
                            _whiteKeyAmount = whiteKeyAmountHigh;
                            _blackKeyAmount = blackKeyAmountHigh;

                            break;
                        }
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
                    result = MessageBox.Show("Нет места для колеса модуляции. Расположить колесо сверху?",
                        "Внимание", buttons, MessageBoxIcon.Question);
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

            if (!NewValidation(commutationXLRSockets, xlrSocketsMax,
                xlrSocketsMin, xlrSocketsString))
            {
                return 1;
            }
            else
            {
                _commutationXLRSockets = commutationXLRSockets;
            }

            if (!NewValidation(commutationTRSSockets, trsSocketsMax,
                trsSocketsMin, trsSocketsString))
            {
                return 1;
            }
            else
            {
                _commutationTRSSockets = commutationTRSSockets;
            }

            if (!NewValidation(commutationMIDISockets, midiSocketsMax,
                midiSocketsMin, midiSocketsString))
            {
                return 1;
            }
            else
            {
                _commutationMIDISockets = commutationMIDISockets;
            }

            return 0;
        }

        /// <summary>
        /// Метод валидации введенных пользователем данных.
        /// </summary>
        /// <returns></returns>
        public bool Validation()
        {
            if (_keyboardKeyAmount == keyAmountHigh)
            {
                if (_bodyLength > bodyLengthHighMax || _bodyLength
                    < bodyLengthHighMin)
                {
                    MessageBox.Show("Длина корпуса при количестве клавиш 88 должна быть в диапазоне от 125 до 150.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (_keyboardKeyAmount == keyAmountMiddle)
            {
                if (_bodyLength > bodyLengthMiddleMax || _bodyLength
                    < bodyLengthMiddleMin)
                {
                    MessageBox.Show("Длина корпуса при количестве клавиш 76 должна быть в диапазоне от 110 до 140.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (_keyboardKeyAmount == keyAmountLow)
            {
                if (_bodyLength > bodyLengthLowMax || _bodyLength
                    < bodyLengthLowMin)
                {
                    MessageBox.Show("Длина корпуса при количестве клавиш 61 должна быть в диапазоне от 90 до 130.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (_bodyHeight > bodyHeightMax || _bodyHeight < bodyHeightMin)
            {
                MessageBox.Show("Высота корпуса должна быть в диапазоне от 5 до 20.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_bodyDepth > bodyDepthMax || _bodyDepth < bodyDepthMin)
            {
                MessageBox.Show("Глубина корпуса должна быть в диапазоне от 20 до 40.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_commutationXLRSockets > xlrSocketsMax || _commutationXLRSockets < xlrSocketsMin)
            {
                MessageBox.Show("Количество разъемов XLR должно быть в диапазоне от 0 до 4.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_commutationTRSSockets > trsSocketsMax || _commutationTRSSockets < trsSocketsMin)
            {
                MessageBox.Show("Количество разъемов TRS должно быть в диапазоне от 0 до 6.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_commutationMIDISockets > midiSocketsMax || _commutationMIDISockets < midiSocketsMin)
            {
                MessageBox.Show("Количество разъемов MIDI должно быть в диапазоне от 0 до 3.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Метод, проверяющий граничные уловия параметров корпуса.
        /// </summary>
        /// <param name="currentValue">Текущее значение</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <param name="minValue">Минимальное значение</param>
        /// <param name="stringValue">Строка с именем параметра</param>
        /// <returns></returns>
        private bool NewValidation(double currentValue, double maxValue, double minValue, string stringValue)
        {
            if (currentValue > maxValue || currentValue < minValue)
            {
                MessageBox.Show("Параметр " + stringValue
                    + " должен быть в диапазоне от " + minValue + " до "
                    + maxValue + ".", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Метод, проверяющий граничные условия количества разъемов.
        /// </summary>
        /// <param name="currentValue">Текущее значение</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <param name="minValue">Минимальное значение</param>
        /// <param name="stringValue">Строка с именем параметра</param>
        /// <returns></returns>
        private bool NewValidation(int currentValue, int maxValue, int minValue, string stringValue)
        {
            if (currentValue > maxValue || currentValue < minValue)
            {
                MessageBox.Show("Параметр " + stringValue
                    + " должен быть в диапазоне от " + minValue + " до "
                    + maxValue + ".", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
