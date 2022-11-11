using System;
using UnityEngine;

public class MeteorProjectile : BaseProjectile
{
    public BaseCharacter target;
    private Vector3 _ref = Vector3.zero;
    private Vector3 _curTarget;

    private void Start()
    {
        _curTarget = target.transform.position;
    }

    public override void Shoot()
    {
        Debug.Log(_curTarget);
        
        if (target == null)
        {
            OnDestroyed();
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, _curTarget,
            projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Invoke("OnDestroyed", 1f);
        other.GetComponent<BaseCharacter>().TakeDamage(projectileDamage);
    }
}