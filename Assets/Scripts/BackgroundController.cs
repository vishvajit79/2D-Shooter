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

//Background script for moving background in horizontal aixs
//Background moves from right to left
public class BackgroundController : MonoBehaviour {

    //variables
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float startX;
    [SerializeField]
    private float endX;

    //background audio source
    public AudioSource _backgroundSound;

    //some more private variables
    private Transform _transform;
    private Vector2 _currentPos;

    // Use this for initialization
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
        _currentPos = _transform.position;
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        _currentPos = _transform.position;
        //move ocean down
        _currentPos -= new Vector2(speed, 0);

        //check if we need to reset
        if (_currentPos.x < endX)
        {
            //reset
            Reset();
        }
        //apply changes
        _transform.position = _currentPos;

    }

    //Resets the current position of the background
    private void Reset()
    {
        _currentPos = new Vector2(startX, 0);
    }
}
