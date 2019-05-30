public void Update()
{ 
    if (bounce == true)                                                //if player is bouncing
    {
        KnockBackStart();
        float translation = Input.GetAxis("P1Horizontal") * (speed / 2);      //player1 Movement
        if (translation > 2 || translation < -2)                           //if movement is more than 2 or less than -2
            transform.Translate(translation, 0, 0);                         //move player

        if (translation < -2 && basic == false && upper == false)           //if player is moving left, basic attack is false, and upper attack is false
            transform.localScale = new Vector3(playerSize, playerSize, playerSize);                 //flip player horizontal to face left
        if (translation > 2 && basic == false && upper == false)            //if player is moving right, basic attack is false, and upper attack is false
            transform.localScale = new Vector3(-1 * playerSize, playerSize, -1 * playerSize);               //flip player horizontal to face right

        rb.AddForce(transform.forward * thrust);                           //adds force
    }
}

private void OnCollisionEnter(Collision collision)
{
    currentVelocitiy = rb.velocity;

    if (collision.other.tag == "hazard")
    {
        StartCoroutine(Respawn());

    }


    if (collision.other.tag == "wall")
    {
        if (bounce == true)
        {
            transform.localScale = new Vector3(-1 * playerSize, playerSize, -1 * playerSize);               //flip player horizontal to face right
            rb.velocity = new Vector3(bounceC * 10, bounceC * 10, 0);
            bounceC -= 20;
        }


    }

    else if (collision.other.tag == "wallr")
    {
        if (bounce == true)
        {
            transform.localScale = new Vector3(playerSize, playerSize, playerSize);                 //flip player horizontal to face left
            rb.velocity = new Vector3(bounceC * -10, bounceC * 10, 0);
            bounceC -= 20;
        }


    }

    else if (collision.other.tag == "floor" || collision.other.tag == "Belt" || collision.other.tag == "beltLeft" || collision.other.tag == "beltRight" || collision.other.tag == "Coil" || collision.other.tag == "Player2" || collision.other.tag == "Player3" || collision.other.tag == "Player4")                                                                                                                 //if player collides with floor
    {
        if (bounce == true)
        {

            rb.velocity = new Vector3((currentVelocitiy.x * bounceC) / 100, bounceC * 15, 0);
            bounceC -= 20;
        }
        else
            isGrounded = true;
    }

    else if (collision.other.tag == "roof")
    {
        if (bounce == true)
        {
            rb.velocity = new Vector3((currentVelocitiy.x * bounceC) / 100, bounceC * -15, 0);

            bounceC -= 20;
        }
        //pointless comment
    }

    else
        if (bounce == true)
        bounceC -= 20;

}


private void BounceStageDecide()                    //decides intensity of bounce
{
    if (health <= 30)
    {
        bounceStage = 10;
        GameManager.Instance.HealthStageP1 = 1;
    }

    else if (health > 30 && health <= 60)
    {
        bounceStage = 20;
        GameManager.Instance.HealthStageP1 = 2;
    }

    else if (health > 60 && health <= 90)
    {
        bounceStage = 30;
        GameManager.Instance.HealthStageP1 = 3;
    }

    else if (health > 90)
    {
        bounceStage = 35;
        GameManager.Instance.HealthStageP1 = 4;

    }
}

private void bouncePlayer()
{
    KnockBackStart();
    bounce = true;
    bounceC = bounceStage * 2;
}


public void KnockbackP1(float x, float y)
{

    if (block == false)
    {
        rb.velocity = new Vector3(x, y, 0);
        health += damage;
        GameManager.Instance.PlayersHealthReduced(damage, 1);
    }
    else
        isGrounded = true;
}
