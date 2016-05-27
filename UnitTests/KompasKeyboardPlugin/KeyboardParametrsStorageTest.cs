using System;
using KompasKeyboardPlugin;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace UnitTests.KompasKeyboardPlugin
{
    /// <summary>
    /// Модульное тестирование класса KeyboardParameters.
    /// </summary>
    [TestFixture]
    public class KeyboardParametersStorageTest
    {
        /// <summary>
        /// Тестирование метода Record с негативными сценариями.
        /// </summary>
        /// <param name="bodyLength">Длина клавиатуры</param>
        /// <param name="bodyHeight">Высота клавиатуры</param>
        /// <param name="bodyDepth">Глубина клавиатуры</param>
        /// <param name="panelDisplay">Наличие дисплея</param>
        /// <param name="panelButtons">Наличие кнопок</param>
        /// <param name="panelKnobs">Наличие ручек</param>
        /// <param name="panelWheel">Наличие колеса модуляции</param>
        /// <param name="commutationXLRSockets">Количество разъемов XLR
        /// </param>
        /// <param name="commutationTRSSockets">Количество разъемов TRS
        /// </param>
        /// <param name="commutationMIDISockets">Количество разъемовMIDI
        /// </param>
        /// <param name="keyboardType">Тип клавиатуры</param>
        /// <param name="keyAmount">Количество клавиш</param>
        [Test]
        [TestCase(0, 0, 0, true, true, true, true, 0, 0, 0, KeyboardType.Piano,
            KeysAmountMode.High,
            TestName = "Негативный тест с нулевыми значениями")]
        [TestCase(double.MinValue, double.MinValue, double.MinValue, true,
            true, true, true, int.MinValue, int.MinValue, int.MinValue,
            KeyboardType.Piano, KeysAmountMode.High,
            TestName = "Негативный тест с минимальными значениями")]
        public void RecordTestNegative(double bodyLength, double bodyHeight,
            double bodyDepth, bool panelDisplay, bool panelButtons,
            bool panelKnobs, bool panelWheel, int commutationXLRSockets,
            int commutationTRSSockets, int commutationMIDISockets,
            KeyboardType keyboardType, KeysAmountMode keyAmount)
        {
            var obj = new KeyboardParametersStorage();
            Assert.Throws<ArgumentException>(()
                => obj.Record(bodyLength, bodyHeight,
                bodyDepth, panelDisplay, panelButtons, panelKnobs,
                panelWheel, commutationXLRSockets, commutationTRSSockets,
                commutationMIDISockets, keyboardType, keyAmount));
        }

        /// <summary>
        /// Тестирование метода Record с позитивными сценариями.
        /// </summary>
        /// <param name="bodyLength">Длина клавиатуры</param>
        /// <param name="bodyHeight">Высота клавиатуры</param>
        /// <param name="bodyDepth">Глубина клавиатуры</param>
        /// <param name="panelDisplay">Наличие дисплея</param>
        /// <param name="panelButtons">Наличие кнопок</param>
        /// <param name="panelKnobs">Наличие ручек</param>
        /// <param name="panelWheel">Наличие колеса модуляции</param>
        /// <param name="commutationXLRSockets">Количество разъемов XLR
        /// </param>
        /// <param name="commutationTRSSockets">Количество разъемов TRS
        /// </param>
        /// <param name="commutationMIDISockets">Количество разъемов MIDI
        /// </param>
        /// <param name="keyboardType">Тип клавиатуры</param>
        /// <param name="keyAmount">Количество клавиш</param>
        [Test]
        [TestCase(130, 10, 30, true, true, true, true, 1, 1, 1,
            KeyboardType.Piano, KeysAmountMode.High,
            TestName = "Позитивный тест (88 клавиш)")]
        [TestCase(130, 10, 30, true, true, true, true, 1, 1, 1,
            KeyboardType.Piano, KeysAmountMode.Middle,
            TestName = "Позитивный тест (76 клавиш)")]
        [TestCase(130, 10, 30, true, true, true, true, 1, 1, 1,
            KeyboardType.Piano, KeysAmountMode.Low,
            TestName = "Позитивный тест (61 клавиша)")]
        public void RecordTestPositive(double bodyLength, double bodyHeight,
            double bodyDepth, bool panelDisplay, bool panelButtons,
            bool panelKnobs, bool panelWheel, int commutationXLRSockets,
            int commutationTRSSockets, int commutationMIDISockets,
            KeyboardType keyboardType, KeysAmountMode keyAmount)
        {
            var obj = new KeyboardParametersStorage();
            obj.Record(bodyLength, bodyHeight, bodyDepth, panelDisplay,
                panelButtons, panelKnobs, panelWheel, commutationXLRSockets,
                commutationTRSSockets, commutationMIDISockets, keyboardType,
                keyAmount);
            Assert.AreEqual(obj.BodyLength, bodyLength);
            Assert.AreEqual(obj.BodyHeight, bodyHeight);
            Assert.AreEqual(obj.BodyDepth, bodyDepth);
            Assert.AreEqual(obj.CommutationXLR, commutationXLRSockets);
            Assert.AreEqual(obj.CommutationTRS, commutationTRSSockets);
            Assert.AreEqual(obj.CommutationMIDI, commutationMIDISockets);
        }
    }
}
