using UnityEngine;
using System.Collections;

public class TurretControl : MonoBehaviour
{
    private Vector2 turn;
    [Header ("Sensitivity")]
    public float sense = 1f;
    // max and min turret rotation
    private float xMax = -7f, xMin = 40f;
    public Rigidbody tank;
    [Header ("Forces applied at shot")]
    // Note that the tank rigidbody mass should be around 5000 for this setup
    public float backForce = 3f, downForce = 10000f;
    [Header ("Barrel end effects at shot")]
    public ParticleSystem explosion, shot;
    public Rigidbody bullet;
    // empty game object at the end of a barrel, where you want to create a missile
    public Transform barrelEnd;
    public static bool bulletIsShot;
    [Header ("Tank cameras")]
    public GameObject mainCam, turretCam;


    private void Awake() {
        // lock the cursor and make it invisible while playing
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    void Update() {

        // setting the turret control by mouse
        turn.x += Input.GetAxis("Mouse X") * sense;
        turn.y += Input.GetAxis("Mouse Y") * sense;

        // it doesn't matter how you set the data types
        turn.y = Mathf.Clamp(turn.y, xMax, xMin);
        turn.x = Mathf.Clamp(turn.x, -40f, 40f);


        transform.localRotation = Quaternion.Euler(-turn.y, 0, turn.x);

        // call the methods
        Shoot();
        SwitchCams();
    }

    void Shoot() {
        if(Input.GetMouseButtonDown(0) && !bulletIsShot) {

            explosion.Play();
            shot.Play();

            // adding the recoil effect to a tank while shooting
            tank.AddRelativeForce(Vector3.back* backForce, ForceMode.VelocityChange);
            tank.AddForce(Vector3.down * downForce, ForceMode.Impulse);

            // creating a missile/bullet at the end of the barrel at the momment of shot
            Rigidbody instaBullet = Instantiate(bullet, barrelEnd.position, barrelEnd.rotation);
            instaBullet.velocity = transform.TransformDirection(Vector3.down * 100);
            bulletIsShot = true;

            StartCoroutine(WaitTillShot());
            
        } 
    }

    IEnumerator WaitTillShot() {
        // waiting one second before you can shoot again
        yield return new WaitForSeconds (1f);
        bulletIsShot = false;
    }
    void SwitchCams() {
        // switching cams
        if(Input.GetMouseButton(1)){
            turretCam.SetActive(true);
            mainCam.SetActive(false);
        } else {
            turretCam.SetActive(false);
            mainCam.SetActive(true);
        }
    }


}
