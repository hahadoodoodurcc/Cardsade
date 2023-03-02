using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _length, _startPosition;
    public GameObject Cam;
    public float parallaxEffect;

    void Start()
    {
        _startPosition = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = (Cam.transform.position.x * (1 - parallaxEffect));
        float dist = (Cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(_startPosition + dist, transform.position.y, transform.position.z);

        if (temp > _startPosition + _length)
        {
            _startPosition += _length;
        }
        else if (temp < _startPosition - _length)
        {
            _startPosition -= _length;
        }
    }
}
