using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////////////////////////////////////// 
//                    COMP3064 CRN13899 Assignment 1                  //
//                       Friday, October 20, 2017                     //
//                    Instructor: Przemyslaw Pawluk                   //
//                     Vishvajit Kher  - 101015270                    //
//                    vishvajit.kher@georgebrown.ca                   //
////////////////////////////////////////////////////////////////////////

//Balloon script - for player scoring
public class BalloonController : MonoBehaviour {

    //some variables
    [SerializeField]
    float minXSpeed = 1f;
    [SerializeField]
    float maxXSpeed = 2f;
    [SerializeField]
    float minYSpeed = -0.5f;
    [SerializeField]
    float maxYSpeed = 0.5f;

    //private variables
    private Transform _transform;
    private Vector2 _currentSpeed;
    private Vector2 _currentPosition;

    // Use this for initialization
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
        //starts the cloning more balloon gameobjects
        StartCoroutine(MoreBalloons());
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        _currentPosition = _transform.position;
        _currentPosition -= _currentSpeed;
        _transform.position = _currentPosition;

        //Destroys balloon when they go out of bounds.
        if (_currentPosition.x <= -113)
        {
            Reset();
        }
    }

    //Resets the position of balloon with a random speed
    public void Reset()
    {
        float xSpeed = Random.Range(minXSpeed, maxXSpeed);
        float ySpeed = Random.Range(minYSpeed, maxYSpeed);

        _currentSpeed = new Vector2(xSpeed, ySpeed);
        float y = Random.Range(72, -64);
        _transform.position = new Vector2(112 + Random.Range(0, 50), y);
    }

    //clones gameobject according to the time and helps score more points
    IEnumerator MoreBalloons()
    {
        if (GameObject.FindGameObjectsWithTag("Balloon").Length < 10)
        {
            int time = Random.Range(10, 30);
            //waits for few seconds and then it will continue running the method
            yield return new WaitForSeconds((float)time);
            Instantiate(gameObject);
            StartCoroutine(MoreBalloons());
        }

    }
}
