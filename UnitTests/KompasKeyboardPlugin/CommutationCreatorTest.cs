using System;
using KompasKeyboardPlugin;
using NUnit.Framework;
using Kompas6API5;

namespace UnitTests.KompasKeyboardPlugin
{
    [TestFixture]
    public class CommutationCreatorTest
    {
        [Test]
        [TestCase(TestName = "Тест с передачей null объекта")]
        public void BuildTest()
        {
            KeyboardParametersStorage keyboardDataNull = null;
            ksDocument3D document3DNull = null;

            var commutationCreatorObject = new CommutationCreator();
            var ex = Assert.Throws<NullReferenceException>(()
                => commutationCreatorObject.Build(document3DNull,
                keyboardDataNull));

            Assert.That(ex.Message, Is.EqualTo("Метод ссылается на null" +
                                               " объект."));
        }
    }
}