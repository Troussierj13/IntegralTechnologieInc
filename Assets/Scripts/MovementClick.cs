using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementClick : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main!.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePosition.z = transform.position.z;
        
        Vector3 direction = (mousePosition - transform.position).normalized;
        
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        
        
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 150.0f);
    }
}
