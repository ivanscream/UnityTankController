using UnityEngine;
using UnityEngine.SceneManagement;
public class ReloadScene : MonoBehaviour 
// placed on any GameObject that is always on the scene, f.e. plain or an empty GameController
{
    // place a panel with info here
    public GameObject panel;
    void Update() {
        if(Input.GetKeyDown(KeyCode.R)) {
            // finds the current scene and reloads it
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        if(Input.GetKey(KeyCode.Tab)) 
            panel.SetActive(true);
        else panel.SetActive(false);
    }

}
