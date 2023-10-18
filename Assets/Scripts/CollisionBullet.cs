using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionBullet : MonoBehaviour
{
    public UnityEvent<Bullet> callBackHit;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag != "EnnemiBullet")
        {
            callBackHit.Invoke(other.GetComponent<Bullet>());
        }
    }
}
