using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;
    public GameObject target;
    public Quaternion rotation;
    
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void Update()
    {
        if (target == null) return;

        transform.position = target.transform.position + offset;
        transform.rotation = rotation;
    }
}
