namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Перечисление вариантов установки колеса модуляции.
    /// Disable - отсутствие колеса модуляции.
    /// EnableFront - наличие колеса модуляции рядом с
    /// клавиатурной секцией.
    /// EnableBack - Наличие колеса модуляции позади
    /// клавиатурной секции.
    /// </summary>
    public enum WheelSetup
    {
        Disable = 0,
        EnableFront,
        EnableBack
    }
}