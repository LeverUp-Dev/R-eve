using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinHeap<T>
{
    public int Size { get; private set; }
    public int Count { get; private set; }

    HeapNode<T>[] heap;

    public MinHeap(int size)
    {
        Size = size;

        heap = new HeapNode<T>[Size + 1];
    }

    public HeapNode<T> Find(int index)
    {
        if (Count == 0)
            return null;

        if (index < 1 || index > Count)
            return null;

        return heap[index];
    }

    public HeapNode<T> FindParent(int index)
    {
        return Find(index / 2);
    }

    public HeapNode<T> FindLeftChild(int index)
    {
        return Find(index * 2);
    }

    public HeapNode<T> FindRightChild(int index)
    {
        return Find(index * 2 + 1);
    }

    public void Insert(int key, T value)
    {
        int index = ++Count;

        while (index != 1 && heap[index / 2].Key > key)
        {
            heap[index] = FindParent(index);
            index /= 2;
        }

        heap[index] = new HeapNode<T>(key, value);
    }

    public T Pop()
    {
        if (Count == 0)
            return default;

        int index = 1;
        HeapNode<T> root = heap[index];
        HeapNode<T> last = heap[Count--];

        while (index <= Count)
        {
            if (index * 2 > Count)
                break;

            HeapNode<T> left = FindLeftChild(index);
            HeapNode<T> right = FindRightChild(index);

            if (left != null && left.Key < last.Key)
            {
                heap[index] = left;
                index = index * 2;
                continue;
            }

            if (right != null && right.Key < last.Key)
            {
                heap[index] = right;
                index = index * 2 + 1;
                continue;
            }

            break;
        }

        heap[index] = last;
        return root.Value;
    }
}
