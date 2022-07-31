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
        //
        //movement.x = Input.GetAxisRaw("Horizontal");
        //move = Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;
        movement.y = Input.GetAxisRaw("Vertical");
        move = Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;
        rotation  += Input.GetAxisRaw("Horizontal") * -rotationSpeed * Time.deltaTime;
        movement.x = rotation;

    }



    //Fixed for movement (physics)
    void FixedUpdate()       
    {
        //rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
        //rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
        rb.AddForce(transform.up * move, ForceMode2D.Force);
        rb.rotation = rotation;
        //transform.Translate(0f, move, 0f);
        //transform.Rotate(0f, 0f, rotation);
    }
}
