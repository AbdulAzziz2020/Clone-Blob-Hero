using System;
using UnityEngine;

public class PlayerCharacter : BaseCharacter
{

    public override void Move()
    {
        float _horizInput = Input.GetAxis("Horizontal");
        float _vertiInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(_horizInput, 0, _vertiInput);
        characterController.Move(movementSpeed * moveDirection.normalized * Time.deltaTime);

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime); 
            
            charAnimator.SetBool("isRun", true);
        }
        else
        {
            charAnimator.SetBool("isRun", false);
        }
    }

    public override void OnDead()
    {
        this.enabled = false;
        charAnimator.SetTrigger("Dead");
    }
}