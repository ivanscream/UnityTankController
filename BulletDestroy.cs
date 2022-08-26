using UnityEngine;
using System.Collections;

public class BulletDestroy : MonoBehaviour // this script should be directly on a bullet
{
    // pick an explosion you like
    public ParticleSystem explosion;
    [Header ("Adjust explosion criteria")]
    public float explosionRadius = 5f;
    public float explosionPower = 4000f;


    void Start()
    {
        if (gameObject != null)
            StartCoroutine(AirExplosion());
    }
    
    // destroying missile as it collides with a target + adding explosion force
    private void OnTriggerEnter(Collider other) { 

        if(other.CompareTag("Target") && gameObject != null) {
            // sets the velocity to zero so it is destroyed at the very moment of collision
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; 
            // creates the explosion at the missile's position
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);

            // explosion will affect all objects on the scene with both colliders and rigidbody
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);

            foreach (Collider hit in colliders) {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(explosionPower, explosionPos, explosionRadius, 3f);
            }

            Destroy(gameObject);
        }
    }

    // this one is for destroying missile and making an explosion at it's position
    // if it doesn't hit any target
    IEnumerator AirExplosion() { 

        yield return new WaitForSeconds (2f);
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
