using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEditor.UI;
public class AreaSpawner : MonoBehaviour
{
    // public GameObject enemyPrefab;
    // public GameObject groupEnemy;
    // public int maxEnemyGroup;
    // public int rate;
    public Collider colliderArea;
    public float timeBetweenSpawn = .5f;
    
    private float timeSpawn = 1f;
    private void Update()
    {
        if (timeSpawn > 0)
        {
            timeSpawn -= Time.deltaTime;
        }
        else
        {
            float dirX = Random.Range(colliderArea.bounds.min.x, colliderArea.bounds.max.x);
            float dirZ = Random.Range(colliderArea.bounds.min.z, colliderArea.bounds.max.z);

            Vector3 spawnPos = new Vector3(dirX, transform.position.y, dirZ);
            
            Spawn(spawnPos);
            //bool change = Random.Range(1, 100) < rate;
    
            // if (change) Spawn(groupEnemy, spawnPos);
            // else Spawn(enemy, spawnPos);
            
            
            timeSpawn = timeBetweenSpawn;
        }
    }
    
    void Spawn (Vector3 pos)
    {
        EnemyCharacter obj = GetPooledEnemy();

        if (obj != null)
        {
            obj.transform.position = pos;
            obj.gameObject.SetActive(true);
            obj.enabled = true;
        }
    }

    #region OBJECT POOLING

    public EnemyCharacter enemy;
    public List<EnemyCharacter> enemyList = new List<EnemyCharacter>();

    public int sizePool;

    private void Start()
    {
        for (int i = 0; i < sizePool; i++)
        {
            EnemyCharacter en = Instantiate(enemy, transform);
            en.gameObject.SetActive(false);
            enemyList.Add(en);
        }
    }

    public EnemyCharacter GetPooledEnemy()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (!enemyList[i].gameObject.activeInHierarchy)
            {
                return enemyList[i];
            }
        }

        return null;
    }

    #endregion
    
}
