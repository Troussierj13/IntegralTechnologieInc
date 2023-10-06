using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddEventOnClick : MonoBehaviour
{

    public UnityEvent onClickEvents;
        
    void OnMouseDown()
    {
        onClickEvents.Invoke();
    }
}
