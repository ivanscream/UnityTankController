using UnityEngine;

public class TankWheelControl : MonoBehaviour // place directly on a tank
{
 // create wheel colliders, usually 4 is enough, you can always make more
 [Header ("Wheel Colliders")]
 [SerializeField] WheelCollider frontRight;
 [SerializeField] WheelCollider frontLeft;
 [SerializeField] WheelCollider rearRight;
 [SerializeField] WheelCollider rearLeft;

 [Header ("All other")]

 public float acceleration = 600f;
 public float brakingForce = 600f;
 private float currentAcceleration = 0f;
 private float currentBreakForce = 0f;
 [Header ("Tank rotation speed")]
 public float rotationSpeed = 0.6f;
//  you can add here "public Vector3 tankMassCenter;" to get control of it from Unity editor
 private Rigidbody rb;
 private float maxSpeed = 10f;

    private void Awake() {
        rb = GetComponent<Rigidbody>();   
    }
    private void FixedUpdate() {

        // this applies torque to the wheels so it can move
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        rearRight.motorTorque = currentAcceleration;
        rearLeft.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;
        frontRight.motorTorque = currentAcceleration; 

        // restricts top speed, set any you like
        if(rb.velocity.magnitude > maxSpeed){
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
        

        if(Input.GetKey(KeyCode.Space))
            currentBreakForce = brakingForce;
        else currentBreakForce = 0f;

        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        rearRight.brakeTorque = currentBreakForce;
        rearLeft.brakeTorque = currentBreakForce;

        // rotates the tank around his center
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);
    }
    // this down here is to control the center of mass and anjust it, in my case I didn't used it
    // private void Start() {
    //     rb = GetComponent<Rigidbody>();
    //     rb.centerOfMass = massCenter;
    // }

}
