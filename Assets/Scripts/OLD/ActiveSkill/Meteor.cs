using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class Meteor : ActiveSkill
{

    public MeteorProjectile projectile;
    public AreaSpawner enemyList;
    public EnemyCharacter targetEnemy;
    public Transform poolPos;
    public float scaleUp = 2f;

    public int sizePool = 30;
    public List<MeteorProjectile> projList = new List<MeteorProjectile>();

    #region Object Pooling

    public void Start()
    {
        for (int i = 0; i < sizePool; i++)
        {
            MeteorProjectile obj = Instantiate(projectile, poolPos.transform);
            obj.gameObject.SetActive(false);
            projList.Add(obj);
        }
    }

    public MeteorProjectile GetPooledProjectile()
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

    #endregion
    
    public override void Action()
    {
        base.Action();
        
        if(targetEnemy == null) return;

        var prj = GetPooledProjectile();

        if (prj != null)
        {
            prj.transform.position = transform.position;
            prj.transform.localScale = new Vector3(transform.localScale.x * scaleUp, transform.localScale.y * scaleUp,
                transform.localScale.z * scaleUp);
            prj.gameObject.SetActive(true);
        }
        
        prj.target = targetEnemy;
    }

    public override void OnLevelUp()
    {
        base.OnLevelUp();
        scaleUp += .2f;
    }

    void FindTarget()
    {
        float closestDistance = Mathf.Infinity;
        EnemyCharacter closestEnemy = null;

        foreach (EnemyCharacter en in enemyList.enemyList)
        {
            if(en.isDead || !en.gameObject.activeInHierarchy) continue;

            Vector3 offset = en.transform.position - transform.position;

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
    }
}