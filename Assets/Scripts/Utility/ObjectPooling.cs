using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public void InitPool<T>(int size, T prefab, List<T> list) where T : Component
    {
        for (int i = 0; i < size; i++)
        {
            T obj = Instantiate(prefab, transform);
            obj.gameObject.SetActive(false);
            list.Add(obj);
        }
    }

    public T GetObjectInPool<T>(List<T> list) where T : Component
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].gameObject.activeInHierarchy) return list[i];
        }

        return null;
    }

    public void SetActiveObject<T>(Vector3 origin, List<T> list) where T : Component
    {
        T obj = GetObjectInPool<T>(list);

        if (obj != null)
        {
            obj.transform.position = origin;
            obj.gameObject.SetActive(true);
        }
    }
}