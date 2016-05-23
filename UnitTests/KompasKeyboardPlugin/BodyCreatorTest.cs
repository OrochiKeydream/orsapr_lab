using System;
using KompasKeyboardPlugin;
using NUnit.Framework;
using Kompas6API5;

namespace UnitTests.KompasKeyboardPlugin
{
    /// <summary>
    /// Модульное тестирование класса BodyCreator.
    /// </summary>
    [TestFixture]
    public class BodyCreatorTest
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
            
            var bodyCreatorObject = new BodyCreator();
            var ex = Assert.Throws<NullReferenceException>(()
                => bodyCreatorObject.Build(document3DNull,
                keyboardDataNull));

            Assert.That(ex.Message, Is.EqualTo("Метод ссылается на null" +
                                               " объект."));
        }
    }
}