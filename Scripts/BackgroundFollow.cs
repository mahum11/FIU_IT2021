using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform target;

    private float startY, startZ;

    void Start()
    {
        if (!target) return;
        startY = transform.position.y;
        startZ = transform.position.z;
    }

    void Update()
    {
        if(!target) return;
        transform.position = new Vector3(target.position.x, startY, startZ);
    }
}
