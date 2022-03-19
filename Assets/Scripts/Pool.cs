using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    public  T ObjectPrefab { get; }
    private Transform ParentObject { get; }
    private List<T> listObjects = new List<T>();
    public List<T> ListObjects => listObjects;

    public Pool(T prefab, int count, Transform parentObject)
    {
        ObjectPrefab = prefab;
        ParentObject = parentObject;
        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var creatObject = Object.Instantiate(ObjectPrefab,ParentObject);
        creatObject.gameObject.SetActive(isActiveByDefault);
        listObjects.Add(creatObject);
        return creatObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var item in listObjects)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                element = item;
                item.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;
    }
    public T GetFreElement()
    {
        if (HasFreeElement(out T element))
        {
            return element;
        }
        else
        {
           return CreateObject(true);
        }  
    }
}
