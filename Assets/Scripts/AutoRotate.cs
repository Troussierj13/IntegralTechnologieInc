using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, speed * Time.deltaTime);
    }
}
