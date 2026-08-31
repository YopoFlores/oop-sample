namespace Acme.OOProgramming.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents a currency using the ISO 4217 format.
/// </summary>
public readonly record struct Currency
{
    /// <summary>
    /// The ISO 4217 code for the currency. This property is initialized through the constructor and cannot be changed afterwards.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public string Code
    {
        get => field ?? string.Empty;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if (value.Length != 3 || !value.All(char.IsAsciiLetter))
            {
                throw new ArgumentException("Currency code must be a 3-letter ISO 4217 code.", nameof(value));
                field = value.ToUpperInvariant();
            }
        }
    }
    
    /// <summary>
    /// Prevents the default constructor from being used, ensuring that a valid ISO 4217 code is always provided.
    /// </summary>
    /// <exception cref="InvalidOperationException">Always thrown to indicate that the default constructor is not allowed.</exception>
    public Currency() => throw new InvalidOperationException("Currency must be initialized with a valid ISO 4217 code.");
    
    /// <summary>
    /// Creates a new instance of <see cref="Currency"/>
    /// </summary>
    /// <param name="code">The ISO 4217 code for the currency.</param>
    /// <exception cref="ArgumentException">Thrown when the provided code is invalid.</exception>
    public Currency(string code) => Code = code;

    /// <summary>
    /// Returns the ISO 4217 code of the currency as a string.
    /// </summary>
    /// <returns>A string representing the ISO 4217 code.</returns>
    public override string ToString() => Code;
}