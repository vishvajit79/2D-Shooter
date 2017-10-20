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

//Enenmy controller script  - For Birds*
public class EnemyController : MonoBehaviour
{
    //some variables
    [SerializeField]
    float minXSpeed = 2f;
    [SerializeField]
    float maxXSpeed = 5f;
    [SerializeField]
    float minYSpeed = -2f;
    [SerializeField]
    float maxYSpeed = 2f;

    //private variables
    private Transform _transform;
    private Vector2 _currentSpeed;
    private Vector2 _currentPosition;

    // Use this for initialization
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
        //starts the difficult level by cloning bird object
        StartCoroutine(StartDifficultLevel());
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        _currentPosition = _transform.position;
        _currentPosition -= _currentSpeed;
        _transform.position = _currentPosition;

        //Destroys enemies when they go out of bounds.
        if (_currentPosition.x <= -113)
        {
            Reset();
        }
    }

    //Resets the position of enemy with a random speed
    public void Reset()
    {
        float xSpeed = Random.Range(minXSpeed, maxXSpeed);
        float ySpeed = Random.Range(minYSpeed, maxYSpeed);

        _currentSpeed = new Vector2(xSpeed, ySpeed);
        float y = Random.Range(72, -64);
        _transform.position = new Vector2(112 + Random.Range(0, 50), y);
    }

    //clones gameobject according to the time and increases the difficulty level for player
    IEnumerator StartDifficultLevel()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length < 10)
        {
            int time = Random.Range(10, 20);
            //waits for few seconds and then it will continue running the method
            yield return new WaitForSeconds((float)time);
            Instantiate(gameObject);
            StartCoroutine(StartDifficultLevel());
        }
        
    }
}