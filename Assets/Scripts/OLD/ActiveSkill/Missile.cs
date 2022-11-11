using System;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Missile : ActiveSkill
{
    public HomingProjectile projectile;
    public AreaSpawner enemyList;
    public EnemyCharacter targetEnemy;
    public Transform poolPos;

    public int sizePool = 30;
    public List<HomingProjectile> projList = new List<HomingProjectile>();

    public override void Action()
    {
        base.Action();

        if (targetEnemy == null) return;

        var prj = GetPooledProjectile();

        if (prj != null)
        {
            prj.transform.position = transform.position;
            prj.gameObject.SetActive(true);
        }
        
        prj.target = targetEnemy;
    }

    public void FindTarget()
    {
        float closestDistance = Mathf.Infinity;
        EnemyCharacter closestEnemy = null;
        Debug.Log("Find Target");
        
        foreach (EnemyCharacter en in enemyList.enemyList)
        {
            if (en.isDead || !en.gameObject.activeInHierarchy) continue;

            Vector3 offset = en.transform.position - transform.position;
            Debug.Log("Magnitude Target" + offset.sqrMagnitude + " ===" + en.name);

            if (offset.sqrMagnitude < closestDistance)
            {
                closestDistance = offset.sqrMagnitude;
                closestEnemy = en;
            }
        }

        targetEnemy = closestEnemy;
    }

    public override void Update()
    {
        base.Update();
        FindTarget();
        // Debug.Log("Update");
    }

    public override void OnLevelUp()
    {
        base.OnLevelUp();
        cooldown -= .25f;
        if (cooldown <= 0) cooldown = .1f;
    }

    public void Start()
    {
        for (int i = 0; i < sizePool; i++)
        {
            HomingProjectile obj = Instantiate(projectile, poolPos.transform);
            obj.gameObject.SetActive(false);
            projList.Add(obj);
        }
    }

    public HomingProjectile GetPooledProjectile()
    {
        for (int i = 0; i < projList.Count; i++)
        {
            if (!projList[i].gameObject.activeInHierarchy)
            {
                return projList[i];
            }
        }

        return null;
    }
}