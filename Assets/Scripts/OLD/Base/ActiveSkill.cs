
using System;
using UnityEngine;

public class ActiveSkill : BaseSkill
{
    [SerializeField] protected float cooldown;
    private float _currentCooldown;
    
    public override void Action()
    {
        
    }

    public void ReduceCooldown()
    {
        if (_currentCooldown > 0) _currentCooldown -= Time.deltaTime;
        else
        {
            _currentCooldown = cooldown;
            Action();
        }
    }

    public virtual void Update()
    {
        ReduceCooldown();
    }

    public override void OnLevelUp()
    {
        
    }
}