using UnityEngine;

public class MoveScript : MonoBehaviour
{
    // Start is called before the first frame update


    public float movementSpeed;
    public float rotationSpeed;
    public float move;

    public Rigidbody2D rb;
    public float rotation;
    Vector2 movement;

    // Update is called once per frame

    private void Start()
    {
        movementSpeed = 50f;
        rotationSpeed = 250f;
    }


    private void Update()
    {
        //
        //movement.x = Input.GetAxisRaw("Horizontal");
        move = Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;
        rotation  = Input.GetAxisRaw("Horizontal") * - rotationSpeed * Time.deltaTime;
           
    }



    //Fixed for movement (physics)
    void FixedUpdate()       
    {
        //rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
        transform.Translate(0f, move, 0f);
        transform.Rotate(0f, 0f, rotation);
    }
}
