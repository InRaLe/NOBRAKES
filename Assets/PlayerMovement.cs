using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    float Steering;
    public int steeringFactor; //wie schnell man sich seitwärts bewegt
    public int mvmtFactor;
    Vector3 playerLookVector;
    float accel;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Steering = Input.GetAxis("Horizontal");
        accel = Input.GetAxis("Vertical");
        playerLookVector = transform.forward;
    }

    void FixedUpdate() {
        //rb.AddForce(playerLookVector*mvmtFactor*accel);
        //rb.AddForce(sidewaysMvmt * steeringFactor, 0, 0);
        //rb.AddTorque(new Vector3(0,Steering*steeringFactor,0));
        if (Input.GetKey("d"))
        {
            rb.AddForce(10, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-10, 0, 0);
        }
        rb.AddForce(0, 0, 10);
    }
}
