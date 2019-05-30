public float speed;
public float rotationSpeed;
public float lift;
float startPos;
bool goUp = true;

void Start()
{
    startPos = transform.localPosition.y;
}

void Update()
{
    transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);                   //spins

    if (transform.localPosition.y >= lift + startPos)               
    {
        goUp = false;
    }
    else if (transform.localPosition.y <= startPos - lift)
    {
        goUp = true;
    }

    if (goUp == true)
        transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);              //moves up
    else if (goUp == false)
        transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);            //moves down
}