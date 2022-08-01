using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform tank;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(tank.position.x + offset.x,tank.position.y + offset.y, tank.position.z +offset.y);
    }
}
