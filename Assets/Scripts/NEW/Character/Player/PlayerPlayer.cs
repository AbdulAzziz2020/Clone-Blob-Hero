using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPlayer : CharacterBased
{
    private Vector2 _dirVector2 = Vector2.zero;
    
    public override void Move()
    {
        Vector3 moveDirection = new Vector3(_dirVector2.x, 0f, _dirVector2.y);
        controller.Move(_currentSpeed * moveDirection * Time.deltaTime);
        
        RotateBody(moveDirection);
        
        Debug.Log("Speed = " + _currentSpeed);
    }

    public void OnMoveInput(InputAction.CallbackContext callbackContext)
    {
        _dirVector2 = callbackContext.ReadValue<Vector2>();
    }

    private void RotateBody(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, characterData.baseRotate * Time.deltaTime);
            
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }

    public override void OnDead()
    {
        throw new System.NotImplementedException();
    }
}
