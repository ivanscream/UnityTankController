using UnityEngine;

public class TrackOffset : MonoBehaviour // placed on tracks
{
    // this here is an aesy and quite lazy way to make your track look like they are spinning,
    // it's always better to make them animated normally with physics
    public float scrollSpeed = 0.05f;
    private Renderer render;

     void Start() {
        // to get the path to a renderer with a material
        render = GetComponent<Renderer>();
    }

    void Update() {

        if(Input.GetKey("w")){
            render.material.mainTextureOffset = new Vector2(-scrollSpeed * Time.time, 0);
        }
        
        if(Input.GetKey("s")) {
            render.material.mainTextureOffset = new Vector2(scrollSpeed * Time.time, 0);
        }
    }

}
