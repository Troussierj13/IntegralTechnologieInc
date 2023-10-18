using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    public GameObject prefabBullet;
    public float speedBullet = 5.0f;
    public float lifetimeBullet = 1.0f;

    public void Shoot()
    {
        Debug.Log("Shoot");
        
        GameObject inst = Instantiate(prefabBullet, transform);
        Bullet bComp = inst.GetComponent<Bullet>();
        bComp.speed = speedBullet;
        bComp.lifetime = lifetimeBullet;

        inst.transform.parent = null;
    }
}