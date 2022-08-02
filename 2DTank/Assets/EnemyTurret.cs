using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{


    public Transform tank;
    public Transform player;
    public float offset = 90f;
    public float rotationSpeed;
    // Start is called before the first frame update

    [SerializeField] GameObject getSight;
    //EnemyTankMovement sight;

    void Update()
    {
        if (getSight.GetComponent<EnemyTankMovement>().isPlayerInSightRange())
        {
            Vector2 playerPosition = player.position;


            var turretDirection = (Vector3)playerPosition - transform.position;
            //Getting the direction needed to turn   (Mouse position - turret position)
            //var turretDirection = (Vector3)mouseWorldPosition - transform.position;
            var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;

            //Multiplying with deltatime
            var rotationStep = rotationSpeed * Time.deltaTime;

            //Rotating the turret with rotation speed
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desiredAngle - offset), rotationStep);
            //Quaternion.
        }
    }

    private void FixedUpdate()
    {
        //transform.rotation = Quaternion.Euler(0f, 0f, rotation_z - offset);
        transform.position = tank.position;
    }
}
