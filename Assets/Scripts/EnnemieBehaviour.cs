using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnnemieBehaviour : MonoBehaviour
{
    public float _speedRotate = 105.0f;
    public float _speedMovement = 15.0f;
    public Vector3 goToPos = new(0.0f, 0.0f, 0.0f);

    public float m_fireRate = 1.2f;
    public float m_life = 100;

    public Transform m_station;
    public Shooter m_shooter;

    private void Start()
    {
        FindStation();
        m_shooter = GetComponentInChildren<Shooter>();
        
        StartCoroutine(RotateToTarget(goToPos, 100.0f, () =>
        {
            GoToPos(() =>
            {
                var playerT = FindObjectOfType<ShipBehaviour>().transform;
                if (playerT.parent != null) // player is snapped to Station
                {
                    var orbit = playerT.parent.parent.GetComponentInChildren<AutoRotate>().transform;
                    transform.parent = orbit;
                }

                StartCoroutine(BehaviourShoot());
            });
        }));
    }

    public void HitByBullet(Bullet bullet)
    {
        m_life -= bullet.damage;
        bullet.DestroyHimself();

        if (m_life <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
    
    public void GoToPos(Action cb)
    {
        StartCoroutine(GoToTarget(goToPos, _speedMovement, cb));
    }

    private void FindStation()
    {
        m_station = FindObjectOfType<ShipBehaviour>().transform;

        if (m_station.parent != null) // is Snapped to Station
        {
            m_station = m_station.parent.parent;
        }
    }
    
    public void LookStation(Action cb)
    {
        Vector3 target = m_station.position;
        target.z = transform.position.z;
        
        StartCoroutine(RotateToTarget(target, _speedRotate, cb));
    }

    IEnumerator BehaviourShoot()
    {
        yield return new WaitForSeconds(m_fireRate);
        
        while (true)
        {
            yield return new WaitForSeconds(m_fireRate);
            
            LookStation(() =>
            {
                m_shooter.Shoot();
            });
        }
    }
    
    IEnumerator GoToTarget(Vector3 target, float speed, Action cb)
    {
        while(Vector3.Distance(transform.position, target) > 0.1)
        {
            transform.position = Vector3.Slerp(transform.position, target, Time.deltaTime * speed);

            yield return new WaitForEndOfFrame();
        }
        
        cb();
    }
    
    IEnumerator RotateToTarget(Vector3 target, float speed, Action cb)
    {
        Quaternion rotation = Quaternion.LookRotation
            (target - transform.position, transform.TransformDirection(Vector3.back));
        
        while(Quaternion.Angle(transform.rotation, new Quaternion(0, 0, rotation.z, rotation.w)) > 90.01)
        {
            transform.rotation = Quaternion.Slerp
                (transform.rotation, new Quaternion(0, 0, rotation.z, rotation.w), Time.deltaTime * speed);

            yield return new WaitForEndOfFrame();
        }
        
        cb();
    }
}
