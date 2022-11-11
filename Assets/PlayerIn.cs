using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIn : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("OnDestroyed", 2f);
    }

    void OnDestroyed()
    {
        gameObject.SetActive(false);
    }
}
