using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KompasKeyboardPlugin;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Kompas6API5;
using Kompas6Constants3D;

namespace UnitTests.KompasKeyboardPlugin
{
    [TestFixture]
    public class BodyCreatorTest
    {
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

            Assert.That(ex.Message, Is.EqualTo("Метод ссылается на null объект."));
        }
    }

}