using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Базовый класс построения части клавиатуры.
    /// </summary>
    public abstract class KeyboardPartBase
    {
        public ksPart part;

        /// <summary>
        /// Метод построения части клавиатуры.
        /// </summary>
        /// <param name="document3D"></param>
        /// <param name="data"></param>
        public abstract void Build(ksDocument3D document3D,
            KeyboardParametersStorage data);
    }
}
