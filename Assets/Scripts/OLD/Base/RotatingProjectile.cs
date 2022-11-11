
using System;
using UnityEngine;

public class RotatingProjectile : BaseProjectile
{
    public Transform rotateAround;
    [SerializeField] protected float targetDistance;

    private Vector3 _offset;
    public float angle;
    // private float _sqrRange;

    public override void Shoot()
    {
        // transform.RotateAround(rotateAround.transform.position, Vector3.up, projectileSpeed * Time.deltaTime);
        // Vector3 offset = transform.position - rotateAround.position;
        // offset.y = 0;
        //
        // transform.position = rotateAround.position + offset.normalized * targetDistance;

        angle += projectileSpeed * Time.deltaTime;
        if (_offset != null)
        {
            _offset = new Vector3(Mathf.Sin(angle) * targetDistance, 0, Mathf.Cos(angle) * targetDistance) *
                      targetDistance;
        }

        transform.position = rotateAround.position + _offset;
        
        // Debug.Log(targetDistance);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyCharacter en = other.GetComponent<EnemyCharacter>();
        if(en != null && !en.isDead) en.TakeDamage(projectileDamage);
    }
}