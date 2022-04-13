using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.CustomList;

internal class CustomConcurrentList<T> : IList<T>
{
    private T[] _massiv;
    private int _count;
    private int _size;
    private int _index;
    private readonly object _lock = new object();

    public int Count => _count;

    public bool IsReadOnly => false;

    public T this[int index]
    {
        get
        {
            ThrowIfInvalidIndex(index);

            return _massiv[index];
        }
        set
        {
            ThrowIfInvalidIndex(index);

            _massiv[index] = value;
        }
    }


    public CustomConcurrentList() : this(4)
    { }

    public CustomConcurrentList(int size)
    {
        _massiv = new T[size];
        _size = size;
    }

    public void Add(T item)
    {
        lock (_lock)
        {
            _count++;
            if (_count > _size)
                Resize();

            _massiv[_index] = item;
            _index++;
        }
    }

    public bool Remove(T item)
    {
        int index = IndexOf(item);
        if (index == -1)
            return false;

        RemoveAt(index);

        return true;
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_massiv[i].Equals(item))
            {
                return i;
            }
        }

        return -1;
    }

    public void Insert(int index, T item)
    {
        ThrowIfInvalidIndex(index);

        lock ((_lock))
        {            
            _massiv[index] = item;
        }
    }

    public void RemoveAt(int index)
    {
        ThrowIfInvalidIndex(index);

        lock ((_lock))
        {
            T[] massiv = new T[_size];
            int j = 0;
            for (int i = 0; i < _count; i++)
            {
                if (i == index)
                    continue;
                
                massiv[j] = _massiv[i];
                j++;
            }

            _massiv = massiv;
            _count--;
            _index--;
        }
    }

    public void Clear()
    {
        lock (_lock)
        {
            _massiv = new T[_size];
            _index = 0;
            _count = 0;
        }
    }

    public bool Contains(T item)
    {
        if (_count == 0)
            return false;

        for (int i = 0; i < _count; i++)
        {
            if (_massiv[i].Equals(item))
                return true;
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (arrayIndex < 0)
            throw new ArgumentOutOfRangeException();

        if (array.Length - arrayIndex < _count)
            throw new ArgumentOutOfRangeException();

        for (int i = 0; i < _count; i++)
        {
            array[arrayIndex] = _massiv[i];
            arrayIndex++;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new CustomConcurrentListEnumerator<T>(this);
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void Resize()
    {
        T[] array = _massiv;
        _size = _size + 4;
        _massiv = new T[_size];
        array.CopyTo(_massiv, 0);
    }

    private void ThrowIfInvalidIndex(int index)
    {
        if (index < 0 || index >= _count)
            throw new ArgumentOutOfRangeException();
    }
}

internal class CustomConcurrentListEnumerator<T> : IEnumerator<T>
{
    private int _position = -1;
    private CustomConcurrentList<T> _collection;
    private bool _disposed = false;

    public CustomConcurrentListEnumerator(CustomConcurrentList<T> collection)
    {
        _collection = collection;
    }

    public T Current
    {
        get 
        {
            return _collection[_position];
        }
    }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        // Dispose of unmanaged resources.
        Dispose(true);
        // Suppress finalization.
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            // TODO: dispose managed state (managed objects).
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.
        _collection = null;

        _disposed = true;
    }

    public bool MoveNext()
    {
        if (_position < _collection.Count-1)
        {
            _position++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Reset()
    {
        _position = -1;
    }

    ~CustomConcurrentListEnumerator()
    {
        Dispose(false);
    }
}
