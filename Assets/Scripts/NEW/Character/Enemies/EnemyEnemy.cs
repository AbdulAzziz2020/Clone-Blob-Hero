using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEnemy : CharacterBased
{
    public PlayerPlayer player;
    public float timeBetweenAttack = 1f;
    public float attackDistance = 3f;

    private float timeAttack;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerPlayer>();
    }

    public override void Move()
    {
        if (controller.isGrounded)
        {
            if (player != null && !player.isDead)
            {
                Vector3 _goTarget = player.transform.position - transform.position;
                Quaternion _bodyRotate = Quaternion.LookRotation(_goTarget.normalized, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, _bodyRotate, characterData.baseRotate * Time.deltaTime);
            
                if (Vector3.Distance(transform.position, player.transform.position) >= attackDistance)
                {
                    // Move

                    controller.Move(_goTarget.normalized * _currentSpeed * Time.deltaTime);
                    animator.SetBool("isRun", true);
                }
                else
                {
                
                    // Attack
                    animator.SetBool("isRun", false);
                
                    Attack();
                }
            }
            else
            {
                animator.SetBool("isRun", false);
            }
        }
    }

    public override void OnDead()
    {
        throw new System.NotImplementedException();
    }

    
    void Attack()
    {
        if (timeAttack > 0)
        {
            timeAttack -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Attack!!!");
            animator.SetTrigger("Attack");
            
            // Spawn Bullet or DirectAttack

            timeAttack = timeBetweenAttack;
        }
    }
}
