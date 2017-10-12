using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float leftX;
    [SerializeField]
    private float rightX;
    [SerializeField]
    private float leftY;
    [SerializeField]
    private float rightY;

    private Transform _transform;
    private Vector2 _currentPos;


    // Use this for initialization
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
        _currentPos = _transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed;
        CheckBounds();
        transform.position = transform.position;
    }

    private void CheckBounds()
    {

        if (_currentPos.x < leftX)
        {
            _currentPos.x = leftX;
        }

        if (_currentPos.x > rightX)
        {
            _currentPos.x = rightX;
        }

        if (_currentPos.y < leftY)
        {
            _currentPos.y = leftY;
        }

        if (_currentPos.y > rightY)
        {
            _currentPos.y = rightY;
        }

    }
}
