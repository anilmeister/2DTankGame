using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Inp;

public class TurretMovement : MonoBehaviour
{

    public Transform tank;

    public float offset = 90f;
    //Vector2 mousePos;
    public float rotationSpeed;

    private void Start()
    {
        rotationSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition); //- transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z - offset);
        transform.position = tank.position;
    }
}
