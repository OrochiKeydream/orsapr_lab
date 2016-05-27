using System;
using KompasKeyboardPlugin;
using NUnit.Framework;
using Kompas6API5;

namespace UnitTests.KompasKeyboardPlugin
{
    /// <summary>
    /// Модульное тестирование класса BoardCreator.
    /// </summary>
    [TestFixture]
    public class BordCreatorTest
    {
        /// <summary>
        /// Тестирование метода Build.
        /// </summary>
        [Test]
        [TestCase(TestName = "Тест с передачей null объекта")]
        public void BuildTestNegative()
        {
            KeyboardParametersStorage keyboardDataNull = null;
            ksDocument3D document3DNull = null;

            var obj = new BoardCreator();
            Assert.Throws<NullReferenceException>(()
                => obj.Build(document3DNull, keyboardDataNull));
        }
    }
}