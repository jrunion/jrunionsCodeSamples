using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraStop = 1.0f;
    public Transform playerToFollow;
    public Transform Firstwall; 
    public Transform Lastwall;
      
    void Update()
    {
        var min = Firstwall.position.x + cameraStop;
        var max = Lastwall.position.x - cameraStop;
        // if players position > min and player position < max
        if (playerToFollow.position.x > min && playerToFollow.position.x < max)
        {
            // change camera's position = players position.x height.y zoom.z
            transform.position = new Vector3(playerToFollow.position.x, playerToFollow.position.y - 4, -33);
        }
    }
}
