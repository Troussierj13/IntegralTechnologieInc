using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionBehaviour : MonoBehaviour
{
    public GameObject instance;
    public GameObject stationAnim;

    public void SpawnStation()
    {
        Transform transform = stationAnim.transform;
        GameObject inst = Instantiate(instance, transform);
        inst.transform.parent = null;
        
        Destroy(gameObject);
    }
}
