using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyCharacter : BaseCharacter
{
    public PlayerCharacter targetCharacter;
    public float attackTimeout = 1f;

    public override void Move()
    {
        if (targetCharacter != null && !targetCharacter.isDead)
        {

            Vector3 _targetPos = targetCharacter.transform.position - transform.position;
            _targetPos.y = 0f;
            Quaternion _rotation = Quaternion.LookRotation(_targetPos.normalized, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _rotation, rotationSpeed * Time.deltaTime);

            if (_targetPos.sqrMagnitude < 2f)
            {
                charAnimator.SetBool("isRun", false);
            }
            else
            {
                characterController.Move(_targetPos.normalized * movementSpeed * Time.deltaTime);
                charAnimator.SetBool("isRun", true);
            }
        }
        else
        {
            FindTarget();
            charAnimator.SetBool("isRun", false);
        }
    }

    private float currentAttackTimeout = 1f;

    void GiveDamage()
    {
        if (targetCharacter == null) return;
        Vector3 _targetPos = targetCharacter.transform.position - transform.position;
        
        if (_targetPos.sqrMagnitude < 2f)
        {
            if (currentAttackTimeout > 0)
            {
                currentAttackTimeout -= Time.deltaTime;
                
            }
            else
            {
                Debug.Log("Attack");
                currentAttackTimeout = attackTimeout;
                targetCharacter.TakeDamage(baseDamage);
                charAnimator.SetTrigger("Attack");
            }
        }
        else
        {
            currentAttackTimeout = attackTimeout;
        }
    }

    protected override void Update()
    {
        base.Update();
        GiveDamage();
    }
    
    void FindTarget()
    {
        if (targetCharacter != null && !targetCharacter.isDead) return;
        targetCharacter = GameObject.FindObjectOfType<PlayerCharacter>();

        if (targetCharacter != null && targetCharacter.isDead) targetCharacter = null;
    }

    public override void OnDead()
    {
        this.enabled = false;
        charAnimator.SetTrigger("Dead");
        // Destroy(gameObject, 2f);
        Invoke("ZombieDead", 2f);
    }

    public void ZombieDead()
    {
        gameObject.SetActive(false);
    }
}
