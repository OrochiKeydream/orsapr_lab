using System;
using KompasKeyboardPlugin;
using NUnit.Framework;
using Kompas6API5;

namespace UnitTests.KompasKeyboardPlugin
{
    /// <summary>
    /// Модульное тестирование класса PanelCreator.
    /// </summary>
    [TestFixture]
    public class PanelCreatorTest
    {
        /// <summary>
        /// Тестирование метода Build.
        /// </summary>
        [Test]
        [TestCase(TestName = "Тест с передачей null объекта")]
        public void BuildTest()
        {
            KeyboardParametersStorage keyboardDataNull = null;
            ksDocument3D document3DNull = null;

            var panelCreatorObject = new PanelCreator();
            Assert.Throws<NullReferenceException>(()
                => panelCreatorObject.Build(document3DNull,
                keyboardDataNull));
        }
    }
}