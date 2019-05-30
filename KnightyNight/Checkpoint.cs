bool reachCheckpoint;
Vector3 checkpointPos;
float currentCheckpoint;

private void ResetPlayer()
{
    if (reachCheckpoint == true)        //if the player has reached a checkpoint
    {
        transform.position = checkpointPos;             //spawn player at checkpoint
        //rooms are reset in another script
    }
}


private void CheckForMovement()
{
    if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hit, _collisionDetectDist))      //creates a raycast infront of the player
    {
        GameObject thingHit = hit.collider.gameObject;                                                      //thing his is whatever the player hit

        if (thingHit.GetComponent<HealingGrace>())                                                          //if the player hit a healing spot
        {
            if (thingHit.GetComponent<HealingGrace>().isCheckpoint)                                          //if this healing grace is a checkpoint
            {
                reachCheckpoint = true;                                                                     //the player has reached a checkpoint
                currentCheckpoint = thingHit.GetComponent<HealingGrace>().checkpointNumber;
                checkpointPos.x = thingHit.GetComponent<HealingGrace>().transform.position.x;               //the checkpoint's x position is whatever the healing graces is
                checkpointPos.z = thingHit.GetComponent<HealingGrace>().transform.position.z;               //the checkpoint's y position is whatever the healing graces is

            }
        }
    }
}