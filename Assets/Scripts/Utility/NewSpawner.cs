using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class NewSpawner : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private ObjectPooling pooling;

    [Header("Area Spawn")] 
    [SerializeField] private Color areaColor;
    [SerializeField] private Vector3 areaSpawn = Vector3.zero;
    //[SerializeField] private Collider areaSpawn;
    
    [Header("Spawn Setting")] 
    public bool isActive = false;
    [SerializeField] private float timeBetweenSpawn = 1f;
    private float _timeSpawn = 1f;
    
    [Header("Pool Setting")]
    [SerializeField] private EnemyEnemy prefab;
    [SerializeField] private int poolSize = 10;
    private List<EnemyEnemy> _listGameObject = new List<EnemyEnemy>();

    public void Start()
    {
        pooling.InitPool<EnemyEnemy>(poolSize, prefab, _listGameObject);
    }

    private void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if (isActive)
        {
            if (_timeSpawn > 0)
            {
                _timeSpawn -= Time.deltaTime;
            }
            else
            {
                pooling.SetActiveObject<EnemyEnemy>(InitAreaSpawn(), _listGameObject);

                _timeSpawn = timeBetweenSpawn;
            }
        }
    }

    public Vector3 InitAreaSpawn()
    {
        // float _areaX = Random.Range(areaSpawn.bounds.min.x, areaSpawn.bounds.max.x);
        // float _areaY = areaSpawn.bounds.max.y;
        // float _areaZ = Random.Range(areaSpawn.bounds.min.z, areaSpawn.bounds.max.z);
        
        float _areaX = transform.position.x + (Random.Range(-areaSpawn.x, areaSpawn.x) / 2f);
        float _areaY = transform.position.y;
        float _areaZ = transform.position.z + (Random.Range(-areaSpawn.z, areaSpawn.z) / 2f);
        
        return new Vector3(_areaX, _areaY, _areaZ);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = areaColor;
        // Gizmos.DrawWireCube(transform.position, areaSpawn.bounds.size);
        Gizmos.DrawWireCube(transform.position, areaSpawn);
    }
}