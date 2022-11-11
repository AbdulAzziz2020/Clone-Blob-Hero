using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : BaseProjectile
{
    public BaseCharacter target;
    
    private Vector3 _ref = Vector3.zero;

    public override void Shoot()
    {
        if (target == null)
        {
            OnDestroyed();
            return;
        }

        // Vector3 offset = target.transform.position - transform.position;
        //
        // transform.position += offset.normalized * projectileSpeed * Time.deltaTime;
        //
        // if (offset.sqrMagnitude < 1.5f)
        // {
        //     OnDestroyed();
        //     target.TakeDamage(projectileDamage);
        // }
        
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref _ref, projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnDestroyed();
        target.TakeDamage(projectileDamage);
    }
}
