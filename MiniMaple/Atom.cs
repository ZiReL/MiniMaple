namespace MiniMaple;

/// <summary>
/// Абстрактный базовый класс для всех элементов выражения. Определяет обязательный набор методов.
/// </summary>
public abstract class Atom
{
    /// <summary>
    /// Проверка выражений на равенство
    /// </summary>
    public abstract bool Eq(Atom other);

    /// <summary>
    /// Проверка отрицательности выражения
    /// </summary>
    public abstract bool Negative { get; }

    /// <summary>
    /// Отрицание (смена знака) выражения
    /// </summary>
    public abstract Atom Neg();

    /// <summary>
    /// Сумма выражений
    /// </summary>
    public abstract Atom Add(Atom other);

    /// <summary>
    /// Разность выражений
    /// </summary>
    public abstract Atom Sub(Atom other);

    /// <summary>
    /// Производная выражения по заданной переменной
    /// </summary>
    public abstract Atom Diff(string sym="x");
}
