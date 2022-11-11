using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotating : MonoBehaviour
{
    public float speed;

    public void Update()
    {
        transform.Rotate(new Vector3(-speed, speed, speed) * Time.deltaTime);
    }
}
