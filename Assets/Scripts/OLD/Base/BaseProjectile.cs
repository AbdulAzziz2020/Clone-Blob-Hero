using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour
{
    [SerializeField] protected int projectileSpeed;
    [SerializeField] protected int projectileDamage;

    public abstract void Shoot();

    public virtual void OnDestroyed()
    {
        gameObject.SetActive(false);
    }

    public void Update()
    {
        Shoot();
    }
}
