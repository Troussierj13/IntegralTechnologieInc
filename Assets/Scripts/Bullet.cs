using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;
    public float lifetime = 1.0f;
    public float damage = 25.0f;

    private void Start()
    {
        StartCoroutine(SelfDestroy(lifetime));
    }

    void Update()
    {
        transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);
    }

    public void DestroyHimself()
    {
        Destroy(gameObject);
    }

    IEnumerator SelfDestroy(float lt)
    {
        yield return new WaitForSeconds(lt);
        Destroy(gameObject);
    }
}
