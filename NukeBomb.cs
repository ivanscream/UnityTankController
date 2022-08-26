using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeBomb : MonoBehaviour
{
    // pick the nuke explosion
    public ParticleSystem nukeExpl;
    [Header ("Nuke preferences")]
    public float nukeRadius = 1000f;
    public int nukePower = 10000000;


    // destroying bomb as it collides with a target + adding explosion force
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Target") || other.CompareTag("Player")) {
            // creates the explosion at the bomb's position
            Instantiate(nukeExpl, gameObject.transform.position, Quaternion.identity);

            // explison will affect all objects on the scene with both colliders and rigidbody
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, nukeRadius);

            foreach (Collider hit in colliders) {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(nukePower, explosionPos, nukeRadius, 10f);
            }
            
            Destroy(gameObject);
        }
    }
}
