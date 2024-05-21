using System;

public class SingleLinkedList<T>
{
    public T Value { get; set; }

    public SingleLinkedList<T> Next { get; set; }

    public SingleLinkedList(T value)
    {
        Value = value;
    }


}
