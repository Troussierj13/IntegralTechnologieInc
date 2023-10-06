using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        float trY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float trX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(trX, trY, 0);

        if (trX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(trX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
