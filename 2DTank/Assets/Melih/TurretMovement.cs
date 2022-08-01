using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Inp;

public class TurretMovement : MonoBehaviour
{

    public Transform tank;
    public Camera mainCamera;
    public float offset = 90f;
    public float rotation_z;
    //Vector2 mousePos;
    public float rotationSpeed;

    private void Start()
    {
        rotationSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        var turretDirection = (Vector3)mouseWorldPosition - transform.position;

        var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;

        var rotationStep = rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desiredAngle - offset), rotationStep);
    }
    private void FixedUpdate()
    {
        //transform.rotation = Quaternion.Euler(0f, 0f, rotation_z - offset);
        transform.position = tank.position;
    }
}
