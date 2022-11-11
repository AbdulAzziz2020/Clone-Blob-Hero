using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBased : MonoBehaviour
{
    [Header("Dependencies")] 
    [SerializeField] protected CharacterController controller;
    [SerializeField] protected Animator animator;

    [Header("Character Data")] 
    [SerializeField] protected CharacterData characterData;

    public bool isDead;
    protected int _currentHealth;
    protected int _currentDamage;
    [SerializeField] protected float _currentSpeed;
    
    // Observer Pattern
    public event Action OnUpdateUI;

    public abstract void Move();
    public abstract void OnDead();

    private void OnEnable()
    {
        InitStatus();
    }

    private void InitStatus()
    {
        _currentHealth = characterData.baseHealth;
        _currentDamage = characterData.baseDamage;
        _currentSpeed = characterData.baseSpeed;
        isDead = false;
    }

    public virtual void TakeDamage(int damageAmount)
    {
        OnUpdateUI?.Invoke();
        
        _currentHealth -= damageAmount;
        
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnDead();
        }
    }

    public virtual void Heal(int healthAmount)
    {
        OnUpdateUI?.Invoke();
        
        _currentHealth += healthAmount;

        if (_currentHealth >= characterData.baseHealth) 
            _currentHealth = characterData.baseHealth;
    }

    public virtual void Update()
    {
        Move();
    }
}
