namespace Acme.OOProgramming.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents a monetary value with an amount and a currency.
/// </summary>
public readonly record struct Money
{
    /// <summary>
    /// Gets the amount of money. This property is initialized through the constructor and cannot be changed afterwards.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public decimal Amount
    {
        get;

        init
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            field = value;
        }
    }
    
    public Currency Currency
    {
        get;
        init
        {
            if(value == default)
                throw new ArgumentNullException(nameof(Currency), "Currency cannot be null or default.");
            field = value;
        }
    }
}