using System;
using UnityEngine;

public class DebuggingCharacter : MonoBehaviour
{
    public CharacterController charController;
    public Animator anim;
    public float speed = 5f;

    public Vector3 charDir = Vector3.zero;

    public void Update()
    {
        charDir.y = 0;
        Debug.Log($"isGround = {charController.isGrounded}!");

        if (charController.isGrounded)
        {
            charController.Move(charDir * Time.deltaTime * speed);
        }
       
    }
}