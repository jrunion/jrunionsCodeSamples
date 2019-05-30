CollectibleManager collectibleAdd;                                      //calls the collectible 
Scene scene;
string scenename;
public int colNum;
float speed = 50;
bool active = true;
public bool collected = false;

void Start()
{
    collectibleAdd = FindObjectOfType<CollectibleManager>();
    scene = SceneManager.GetActiveScene();
    scenename = scene.name;
    if (collected)                                                  //destroy if object is already collected
        Destroy(this.gameObject);
}

void Update()
{
    transform.Rotate(Vector3.up, speed * Time.deltaTime);           //collectible is spinning
}

private void OnTriggerEnter(Collider other)
{
    if (other.tag == "Player")
    {
        if (scenename == "Level_2")
            collectibleAdd.addCollectible(2, colNum);               //add to level 2 collectible count
        if (scenename == "Level_1")
            collectibleAdd.addCollectible(1, colNum);               //add to level 1 collectible count

        LoadAndSaveTool.Save();
        Destroy(this.gameObject);
    }
}