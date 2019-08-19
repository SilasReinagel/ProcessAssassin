using System;
using System.Threading.Tasks;

public sealed class Maybe<T>
{
    public static Maybe<T> Of(T value) => new Maybe<T>(false, value);
    public static Maybe<T> Missing => new Maybe<T>(true, default(T));
    public static Maybe<T> Unsure(T value) => new Maybe<T>(IsDefaultValue(value), value);
    public static Maybe<string> Unsure(string value) => new Maybe<string>(IsDefaultValue(value), value);
    public static Maybe<T> Unsure<TIn>(Func<TIn, T> valueFunc, TIn param)
    {
        var validatedValue = valueFunc.Invoke(param);
        return new Maybe<T>(IsDefaultValue(validatedValue), validatedValue);
    }
    public static Task<Maybe<T>> AsTask(T value) => Task.FromResult(new Maybe<T>(false, value));

    private static bool IsDefaultValue(T value) => value == null || value.Equals(default(T));
    private static bool IsDefaultValue(string value) => string.IsNullOrWhiteSpace(value);

    public bool IsMissing { get; }
    public bool IsPresent => !IsMissing;
    public T Value { get; }

    private Maybe(bool isMissing, T value)
    {
        IsMissing = isMissing;
        Value = value;
    }

    public static implicit operator Maybe<T>(T value) => new Maybe<T>(false, value);
    public static implicit operator bool(Maybe<T> maybe) => maybe.IsPresent;

    public override string ToString() => IsMissing ? "Missing" : Value.ToString();
    
    public override bool Equals(object obj) => obj is Maybe<T> maybe && Equals(maybe);
    public bool Equals(Maybe<T> other) => IsMissing == other.IsMissing && (IsPresent ? Value.Equals(other.Value) : Equals(Value, other.Value));

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = 176239257;
            hashCode = (hashCode * 14269593) ^ IsMissing.GetHashCode();
            hashCode = (hashCode * 14269593) ^ (Value == null ? 0 : Value.GetHashCode());
            return hashCode;
        }
    }
}
