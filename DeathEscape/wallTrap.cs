using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallTrap : MonoBehaviour {

    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform lWall;
    [SerializeField]
    private Transform rWall;
    [SerializeField]
    private Transform rWallStart;
    [SerializeField]
    private Transform lWallStart;
    [SerializeField]
    private Transform wallEnd;
    public float speed = 1.5f;
    private bool activate = false;
    private bool end = false;
    private bool back = false;

    private void OnTriggerEnter(Collider other)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        if (activate == false)
        {
            activate = true;
        }
    }

    private void Update()
    {
        if (activate == true && back == true && end == false)
        {
            rWall.transform.position = Vector3.MoveTowards(rWall.transform.position, rWallStart.transform.position, speed);
            lWall.transform.position = Vector3.MoveTowards(lWall.transform.position, lWallStart.transform.position, speed);
        }

        if (activate == true && back == false)
        {
            rWall.transform.position = Vector3.MoveTowards(rWall.transform.position, wallEnd.transform.position, speed);
            lWall.transform.position = Vector3.MoveTowards(lWall.transform.position, wallEnd.transform.position, speed);
        }

        if (activate == true && rWall.transform.position == wallEnd.transform.position)
            back = true;

        if(activate == true && back == true && rWall.transform.position == rWallStart.transform.position)
            end = true;

        if (activate == true && end == true && back == true)
        {
            rWall.transform.position = rWallStart.transform.position;
            lWall.transform.position = lWallStart.transform.position;
        }
    }
}
