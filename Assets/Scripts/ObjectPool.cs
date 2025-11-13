using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool<T> where T : Component
{
    private readonly List<T> _pool = new List<T>();

    public void Add(T item)
    {
        _pool.Add(item);
    }

    public bool TryGet(out T result)
    {
        result = _pool.FirstOrDefault(item => !item.gameObject.activeSelf);

        return result != null;
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.gameObject.SetActive(false);
        }
    }
    
    public IEnumerable<T> GetActive()
    {
        return _pool.Where(item => item.gameObject.activeSelf);
    }
}