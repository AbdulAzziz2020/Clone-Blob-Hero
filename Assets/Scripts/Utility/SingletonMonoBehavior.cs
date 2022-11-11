using System;
using UnityEngine;

public class SingletonMonoBehavior<T> : MonoBehaviour where T : Component
{
    public static T Instance;

    public virtual void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this as T;
    }
}