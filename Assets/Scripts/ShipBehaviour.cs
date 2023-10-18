using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipBehaviour : MonoBehaviour
{
    
    public float _speedRotate = 15.0f;
    public float maxSpeed = 30.0f;
    public bool inMovement = false;
    public float movement = 0.0f;
    private PlayerInput _playerInput;
    private float direction;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    public void Movements(InputAction.CallbackContext cc)
    {
        inMovement = cc.started || !cc.canceled;
    }
    
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePosition.z = transform.position.z;
        Vector3 _direction = (mousePosition - transform.position).normalized;
        Quaternion _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * 150.0f);

        if (inMovement && transform.parent)
        {
            direction = _playerInput.actions["Move"].ReadValue<Vector2>().x;
            if(Math.Abs(movement) < maxSpeed * Time.deltaTime)
                movement += direction * (float)Math.Log(_speedRotate) * Time.deltaTime;
            else
                movement = direction * maxSpeed * Time.deltaTime;

            transform.parent.Rotate(0.0f, 0.0f, movement);
        }
        else if (Math.Abs(movement) > _speedRotate * Time.deltaTime)
        {
            movement -= direction * (float)Math.Log(_speedRotate)/2 * Time.deltaTime;
            transform.parent.Rotate(0.0f, 0.0f, movement);
        }
        else
        {
            movement = 0.0f;
        }
    }
}
