using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    public GameObject prefabBullet;
    public float speedBullet = 5.0f;
    public float lifetimeBullet = 1.0f;

    public void Shoot(InputAction.CallbackContext cc)
    {
        if (cc.started)
        {
            GameObject inst = Instantiate(prefabBullet, transform);
            Bullet bComp = inst.GetComponent<Bullet>();
            bComp.speed = speedBullet;
            bComp.lifetime = lifetimeBullet;

            inst.transform.parent = null;
        }
    }
}
