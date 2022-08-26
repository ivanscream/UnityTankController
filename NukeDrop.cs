using UnityEngine;

public class NukeDrop : MonoBehaviour // set an empty GameObject at the place where you want to spawn the bomb
{
    public Rigidbody nuke;
    // this bool here to be able to deploy it only once
    // if you want to launch nukes all the time
    // delete the bool and, maybe, set an IEnumerator so you cant
    // spawn them continuously (bullet script as an example)
    private bool deployed;
    
    private void Update() {
        if(Input.GetKeyDown("n") && !deployed) {
            Rigidbody nukeBomb = Instantiate(nuke, gameObject.transform.position, gameObject.transform.rotation);
            // setting the velocity of the bomb so it flies down, not just drops when created
            nukeBomb.velocity = transform.TransformDirection(Vector3.up * 60f);
            deployed = true;  }
            
    }
}
