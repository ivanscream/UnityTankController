using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour // place this script on a cam behind the tank
{
    private Vector2 turn;
    [Header ("Mouse sensitivity")]
    private float sense = 0.15f;
    private float xMax = -20f, xMin = 8f;

    void Update() {
        turn.x += Input.GetAxis("Mouse X") * sense;
        turn.y += Input.GetAxis("Mouse Y") * sense;
        
        // it doesn't matter how you set the data types
        turn.y = Mathf.Clamp(turn.y, xMax, xMin);
        turn.x = Mathf.Clamp(turn.x, -15f, 15f);


        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
