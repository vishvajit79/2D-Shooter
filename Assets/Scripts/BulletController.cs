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

//Bullet controller script for collision and movement 
public class BulletController : MonoBehaviour {

    //variables
    [SerializeField]
    float xSpeed = 2f;
    [SerializeField]
    float yPos;

    //some private variables
    private AudioSource _birdKillSound;
    private Transform _transform;
    private Vector2 _currentSpeed;
    private Vector2 _currentPosition;

    // Use this for initialization
    void Start()
    {
        _birdKillSound = gameObject.GetComponent<AudioSource>();
        _transform = gameObject.GetComponent<Transform>();
        Reset();
    }

    //resets the position of bullet
    public void Reset()
    {
        _currentSpeed = new Vector2(xSpeed, 0);
    }


    // Update is called once per frame
    void Update()
    {
        _currentPosition = _transform.position;
        _currentPosition += _currentSpeed;
        _transform.position = _currentPosition;

        //if the bullet goes out of bounds, then it will destroy the object
        if (_currentPosition.x >= 120)
        {
            Destroy(gameObject);
        }
    }

    //collision method is invoked when it collides
    public void OnTriggerEnter2D(Collider2D collider)
    {
        //it it collides with enemy, player gets extra 100 score and enemy is destroyed as well as bullet
        if (collider.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("Bullet collision\n");
            if (_birdKillSound != null)
            {
                _birdKillSound.Play();
            }
            Player.Instance.Score += 100;
            collider.gameObject.GetComponent<EnemyController>().Reset();
            Destroy(gameObject);
        }
    }
}
