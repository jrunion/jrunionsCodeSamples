protected GameObject _Audio;
protected AudioManager _audioManager;
protected float volSFX;
protected AudioSource _speaker;

[SerializedField]
AudioClip ghostDeath;

public virtual void Init(DungeonMechanic _spawner, Mechanic _incomingMech)
{
    _Audio = GameObject.Find("AudioManager");
    _audioManager = _Audio.GetComponent<AudioManager>();
    _speaker = GetComponent<AudioSource>();
    volSFX = _audioManager.volSFX;
}

protected virtual void Dead()
{
    _speaker.Stop();
    if (!_speaker.isPlaying)
    {
        _speaker.PlayOneShot(ghostDeath, volSFX);
    }
}