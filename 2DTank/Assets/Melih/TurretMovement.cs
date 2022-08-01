using UnityEngine;
//using UnityEngine.Inp;

public class TurretMovement : MonoBehaviour
{

    public Transform tank;
    public Camera mainCamera;
    public float offset = 90f;
    public float rotationSpeed;

    private void Start()
    {
        rotationSpeed = 70f;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);


        //Getting the direction needed to turn   (Mouse position - turret position)
        var turretDirection = (Vector3)mouseWorldPosition - transform.position;

        // Atan2 => radian between x,y converted to degree
        var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;

        //Multiplying with deltatime
        var rotationStep = rotationSpeed * Time.deltaTime;

        //Rotating the turret with rotation speed
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desiredAngle - offset), rotationStep);
    }
    private void FixedUpdate()
    {
        //transform.rotation = Quaternion.Euler(0f, 0f, rotation_z - offset);
        transform.position = tank.position;
    }
}
