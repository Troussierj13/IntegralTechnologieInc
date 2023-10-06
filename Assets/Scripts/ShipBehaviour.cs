using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipBehaviour : MonoBehaviour
{
    public bool inMovement = false;
    
    public void SnapToStation(StationBehaviour station)
    {
        transform.parent = station.transform;
    }
    
    public void UnsnapToStation(StationBehaviour station)
    {
        transform.parent = null;
    }

    public void Movements(InputAction.CallbackContext cc)
    {
        inMovement = cc.started || !cc.canceled;
        
        if (inMovement)
        {

            Debug.Log(cc.control);
        }
    }
    
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePosition.z = transform.position.z;
        Vector3 _direction = (mousePosition - transform.position).normalized;
        Quaternion _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * 150.0f);
    }
}
