GameObject player;
public GameObject spawn;
GameObject camera;

void Start()
{
    camera = GameObject.Find("Main Camera");
    player = GameObject.FindGameObjectWithTag("Player");
}

private void OnTriggerEnter(Collider other)
{
    if (other.tag == "Player")
    {
        player.transform.position = spawn.transform.position;           //moves player to the designated spawn
        camera.transform.position = spawn.transform.position;
        player.GetComponent<Rigidbody>().Sleep();
    }
}