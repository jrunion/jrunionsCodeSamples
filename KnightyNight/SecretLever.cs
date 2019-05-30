    void Update()
    {
        if (_activated && !_rotated)
            activateSwitch();    
        if (falling)
            Fall();
        else if (staying)
            Stay();
    }
    public void Stay()
    {
        if (_door.transform.position.y >= _endDoor.y)
        {
            staying = false;
            _myColor.a = 1;
            _myMaterial.color = _myColor;
            _myRenderer.material = _myMaterial;
        }
        _myColor.a += _fadeInc;
        _myMaterial.color = _myColor;
        _myRenderer.material = _myMaterial;
        _door.transform.position += Vector3.up * _doorSpeed * Time.deltaTime;
    }
    public void Fall()
    {
        if (_door.transform.position.y <= _endDoor.y-_raycastDist)
        {
            falling = false;
            _myColor.a = 0;
            _myMaterial.color = _myColor;
            _myRenderer.material = _myMaterial;
            _myRenderer.enabled = false;
        }
        else
        {
            _myColor.a -= _fadeInc;
            _myMaterial.color = _myColor;
            _myRenderer.material = _myMaterial;
            _door.transform.position += Vector3.down * _doorSpeed * Time.deltaTime;
        }
    }