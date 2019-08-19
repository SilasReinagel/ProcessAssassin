using System.Collections.Generic;

public static class EnumerableExtensions
{
    public static List<T> AsList<T>(this T item) => new List<T> { item };
}

