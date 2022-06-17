using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Base abstraction for pools which inherit MonoBehaviour
/// </summary>
/// <typeparam name="T">The type of the pool</typeparam>
public class Pool<T> where T : MonoBehaviour
{
    private List<T> pool;

    #region Public Properties

    /// <summary>
    /// Pool's object prefab
    /// </summary>
    public T prefab { get; }
    /// <summary>
    /// Container for objects in pool
    /// </summary>
    public Transform objectsContainer { get; }

    /// <summary>
    /// Creates a pool of objects
    /// </summary>
    /// <param name="prefab">Object's prefab</param>
    /// <param name="capacity">Amount in pool</param>
    /// <param name="container">Objects' holder container</param>

    #endregion
    
    public Pool(T prefab, int capacity, Transform container)
    {
        this.prefab = prefab;
        this.objectsContainer = container;
        CreatePool(capacity);
    }

    #region Private Functions
    private void CreatePool(int capacity)
    {
        pool = new List<T>();
        for (int i = 0; i < capacity; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActive = false)
    {
        var newObject = Object.Instantiate(prefab, objectsContainer);
        newObject.gameObject.SetActive(isActive);
        pool.Add(newObject);
        return newObject;
    }


    #endregion


    #region Public Functions
    /// <summary>
    /// Returns if the pool has a free object
    /// </summary>
    /// <param name="freeElement">Out parameter of free element</param>
    /// <returns>Bool if a pool has a free element</returns>
    public bool HasFreeObject(out T freeElement)
    {
        foreach (var element in pool)
        {
            if (!element.gameObject.activeInHierarchy)
            {
                freeElement = element;
                freeElement.gameObject.SetActive(true);
                return true;
            }
        }
        freeElement = null;
        return false;
    }
    /// <summary>
    /// Returns an object from pool
    /// </summary>
    /// <returns>An object of specified type from pool</returns>
    public T GetFreeElement()
    {
        if (HasFreeObject(out var element))
            return element;
        else
            return CreateObject(true);
    }

    #endregion
}
