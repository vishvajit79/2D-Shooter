using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////////////////////////////////////// 
//                    COMP3064 CRN13899 Assignment 1                  //
//                       Friday, October 20, 2016                     //
//                    Instructor: Przemyslaw Pawluk                   //
//                     Vishvajit Kher  - 101015270                    //
//                    vishvajit.kher@georgebrown.ca                   //
////////////////////////////////////////////////////////////////////////

//Player controller script  - For Rocket*
public class PlayerController : MonoBehaviour
{
    //private variables
    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private float leftX;
    [SerializeField]
    private float rightX;
    [SerializeField]
    private float leftY;
    [SerializeField]
    private float rightY;
    [SerializeField]
    GameObject bulletObject;

    //some other variables
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
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal < 0)
        {
            //if left arrow is pressed move left = A
            _currentPos -= new Vector2(speed, 0);
        }

        if (moveHorizontal > 0)
        {
            //if right arrow is pressed move right = D
            _currentPos += new Vector2(speed, 0);
        }

        if (moveVertical < 0)
        {
            //if up arrow is pressed move up = W
            _currentPos -= new Vector2(0, speed);
        }

        if (moveVertical > 0)
        {
            //if down arrow is pressed move down = S
            _currentPos += new Vector2(0, speed);
        }

        //player shoots when space or left mouse click is triggered
        if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Shoot");
            Instantiate(bulletObject)
                .GetComponent<Transform>()
                .position = new Vector2(_currentPos.x + 15, _currentPos.y - 3);
        }


        //Checking boundaries of the player
        CheckBounds();

        _transform.position = _currentPos;

    }

    //Validating boundaries for player. Player muyst stay within the game boundaries
    private void CheckBounds()
    {
        //Checks X axis
        if (_currentPos.x < leftX)
        {
            _currentPos.x = leftX;
        }

        if (_currentPos.x > rightX)
        {
            _currentPos.x = rightX;
        }

        //Checks Y axis
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
