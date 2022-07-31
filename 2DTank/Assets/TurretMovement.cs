using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{


    Vector2 mousePos;
    public float rotationSpeed;

    private void Start()
    {
        rotationSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition - transform.position;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
