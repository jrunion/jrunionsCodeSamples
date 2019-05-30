using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour {

    Vector2 mouseView;                      //keeps track mouselook total
    Vector2 smoothV;                        //2D Vector, smoothes movement
    public static float sensitivity = 1.0f;        //changeable sensitivty in camera movement
    public float smoothing = 2.0f;          //how much smoothing you want

    GameObject player;                      //gameobject

	void Start ()
    {
        player = this.transform.parent.gameObject;      //sets to parent        	
	}
	
	void Update ()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")); //sets up mouse direction variables

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));      //changes value dpending on smoothing/ sensitivity settings
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);                                    // Look values on the x axis (left to right), smooths between two points with LERP
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);                                    // Look values on the y axis (up and down), samae as above. LERP prevents quick snapping
        mouseView += smoothV;
        mouseView.y = Mathf.Clamp(mouseView.y, -90f, 90f);                                          //locks camera from doing spins yo

        transform.localRotation = Quaternion.AngleAxis(-mouseView.y, Vector3.right);                //applies values to camera rotation up and down
        player.transform.localRotation = Quaternion.AngleAxis(mouseView.x, player.transform.up);    //applies values to move player left and Right	
	}

    public void changeFast()
    {
        sensitivity = 5.0f;
    }

    public void changeMedium()
    {
        sensitivity = 3.0f;
    }

    public void changeSlow()
    {
        sensitivity = 1.0f;
    }
}
