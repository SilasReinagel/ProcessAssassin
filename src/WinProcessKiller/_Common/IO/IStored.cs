using System;

public interface IStored<T>
{
    T Get();
    void Update(Func<T, T> update);
}
