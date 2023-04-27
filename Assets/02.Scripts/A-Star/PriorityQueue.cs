using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue<T> where T : IComparable<T>
{
    //MinHeap
    public List<T> _heap = new List<T>();
    public int Count => _heap.Count;

    public T Contains(T t)
    {
        int idx = _heap.IndexOf(t);
        if (idx < 0) return default(T);
        return _heap[idx];
    }

    public void Push(T data)
    {
        //���ο� �� ���� ���� �� �ؿ��ٰ� �ְ� �÷����鼭 �ڸ��� ã�´�.
        _heap.Add(data);
        int now = _heap.Count - 1; //�� ������ ������ �ε����� �����´�.

        while (now > 0) //��������� �ö󰥶����� �θ���� �����ô�?
        {
            int next = (now - 1) / 2;
            if (_heap[now].CompareTo(_heap[next]) < 0)
            {
                break;
            }

            T temp = _heap[now];
            _heap[now] = _heap[next];
            _heap[next] = temp;

            now = next;
        }
    }

    public T Pop()
    {
        T ret = _heap[0];

        int lastIndex = _heap.Count - 1;
        _heap[0] = _heap[lastIndex];
        _heap.RemoveAt(lastIndex);

        lastIndex--;

        int now = 0;

        while (true)
        {
            int left = 2 * now + 1;//�����ڽ�
            int right = 2 * now + 2;//�������ڽ�

            int next = now;
            if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                next = left;

            if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                next = right;

            if (next == now)
                break;

            T temp = _heap[now];
            _heap[now] = _heap[next];
            _heap[next] = temp;

            now = next;
        }

        return ret;
    }

    public T Peak()
    {
        return _heap.Count == 0 ? default(T) : _heap[0];
    }

    public void Clear()
    {
        _heap.Clear(); //�� Ŭ����
    }
}
