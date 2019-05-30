public AudioClip ghostHit;
public AudioClip colorGhostCorrect;

public override void Init(DungeonMechanic _spawner, Mechanic _incomingMech)
{
    _speaker = this.transform.GetComponent<AudioSource>();
}

public override void GotHit(Vector3 _flyDir, float _knockBackForce)
{
    if (!_hit)
    {
        _speaker.PlayOneShot(ghostHit, volSFX);
    }
}