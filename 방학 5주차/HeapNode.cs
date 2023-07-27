using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeapNode<T>
{
    public int Key { get; private set; }
    public T Value { get; private set; }

    public HeapNode(int key, T value)
    {
        this.Key = key;
        this.Value = value;
    }
}
