using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Базовый класс для построения клавиши.
    /// </summary>
    public abstract class KeyCreatorBase
    {
        /// <summary>
        /// Метод для построения клавиши.
        /// </summary>
        /// <param name="sketch">Указатель на эскиз.</param>
        public abstract void Build();
    }
}
