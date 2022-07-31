using UnityEngine;

public class MoveScript : MonoBehaviour
{
    // Start is called before the first frame update


    public float movementSpeed;
    public float rotationSpeed;
    public float move;
    public ParticleSystem tankTrail;
    public Rigidbody2D rb;

    Vector2 movement;
    public float rotation;

    // Update is called once per frame

    private void Start()
    {
        movementSpeed = 450f;
        rotationSpeed = 60f;
    }


    private void Update()
    {
        // move = Input.GetAxisRaw("Vertical") * movementSpeed * Time.fixedDeltaTime;
        //  rotation  += Input.GetAxisRaw("Horizontal") * -rotationSpeed * Time.deltaTime;
        //
        //movement.x = Input.GetAxisRaw("Horizontal");
        //move = Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;
        movement.y = Input.GetAxisRaw("Vertical");
        movement.x = Input.GetAxisRaw("Horizontal");
       
       
        //movement.x = rotation;

    }



    //Fixed for movement (physics)
    void FixedUpdate()       
    {   
        
        //rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
        //rb.MovePosition(transform.forward + move);
        //rb.AddForce(transform.up * move, ForceMode2D.Force);
        //rb.rotation = rotation;


        //Transform should not be used with any physics object
        //transform.Translate(0f, move, 0f);
        //transform.Rotate(0f, 0f, rotation);



        rb.velocity = (Vector2)transform.up * movement.y * movementSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movement.x * rotationSpeed * Time.fixedDeltaTime));
    }
}
