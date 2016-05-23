using KompasKeyboardPlugin;
using NUnit.Framework;

namespace UnitTests.KompasKeyboardPlugin
{
    /// <summary>
    /// Модульное тестирование класса KeyboardParameters.
    /// </summary>
    [TestFixture]
    public class KeyboardParametersStorageTest
    {
        [Test]
        [TestCase(130, 10, 30, true, true, true, true, 1, 1, 1,
            KeyboardType.Piano, KeysAmountMode.High, ExpectedResult = 0,
            TestName = "Позитивный тест (88 клавиш)")]
        [TestCase(130, 10, 30, true, true, true, true, 1, 1, 1,
            KeyboardType.Piano, KeysAmountMode.Middle, ExpectedResult = 0,
            TestName = "Позитивный тест (76 клавиш)")]
        [TestCase(130, 10, 30, true, true, true, true, 1, 1, 1,
            KeyboardType.Piano, KeysAmountMode.Low, ExpectedResult = 0,
            TestName = "Позитивный тест (61 клавиша)")]
        [TestCase(0, 0, 0, true, true, true, true, 0, 0, 0, KeyboardType.Piano,
            KeysAmountMode.High, ExpectedResult = 1,
            TestName = "Негативный тест с нулевыми значениями")]
        [TestCase(double.MinValue, double.MinValue, double.MinValue, true,
            true, true, true, int.MinValue, int.MinValue, int.MinValue,
            KeyboardType.Piano, KeysAmountMode.High, ExpectedResult = 1,
            TestName = "Негативный тест с минимальными значениями")]
        public int RecordTest(double bodyLength, double bodyHeight,
            double bodyDepth, bool panelDisplay, bool panelButtons,
            bool panelKnobs, bool panelWheel, int commutationXLRSockets,
            int commutationTRSSockets, int commutationMIDISockets,
            KeyboardType keyboardType, KeysAmountMode keyAmount)
        {
            var keyboardParametersStorage = new KeyboardParametersStorage();

            return keyboardParametersStorage.Record(bodyLength, bodyHeight,
                bodyDepth, panelDisplay, panelButtons, panelKnobs,
                panelWheel, commutationXLRSockets, commutationTRSSockets,
                commutationMIDISockets, keyboardType, keyAmount);
        }
    }
}
