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

//player collision script for explosion animation and player losing health
public class PlayerCollision : MonoBehaviour {

    //variables
    [SerializeField]
    GameController gameController;
    [SerializeField]
    GameObject explosion;

    public AudioSource[] sounds;
    //explosion audio source
    public AudioSource _explosionSound;
    //balloon audio source
    public AudioSource _balloonSound;

    // Use this for initialization
    void Start () {
        sounds = GetComponents<AudioSource>();
        _explosionSound = sounds[0];
        _balloonSound = sounds[1];
	}

    //flashes player after collision for 3 times
    private IEnumerator Blink()
    {
        Color c;
        Renderer renderer = gameObject.GetComponent<Renderer>();
        for (int i = 0; i < 3; i++)
        {
            for (float f = 1f; f >= 0; f -= 0.1f)
            {
                c = renderer.material.color;
                c.a = f;
                renderer.material.color = c;
                yield return new WaitForSeconds(0.1f);
            }
            for (float f = 0f; f <= 1; f += 0.1f)
            {
                c = renderer.material.color;
                c.a = f;
                renderer.material.color = c;
                yield return new WaitForSeconds(0.1f);
            }
        }

    }

    //when player collides with another collider, this method is called
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if player collides with enemy, it loses 10% of its current health
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("Enemy collision\n");
            //plays explosion sound if it's not null
            if(_explosionSound != null)
            {
                _explosionSound.Play();
            }
            //plays explosion animation
            Instantiate (explosion).GetComponent<Transform>().position = collision.gameObject.GetComponent<Transform>().position;
            //resets the position of enemy
            collision.gameObject.GetComponent<EnemyController>().Reset();
            //player loses its 10% health
            Player.Instance.Health -= 10;
            //calls blink coroutine to flash player when it collides with enemy
            StartCoroutine("Blink");
        }

        //if player collides with balloon, it gets 200 score
        if (collision.gameObject.tag.Equals("Balloon"))
        {
            Debug.Log("Bonus Points\n");
            //plays explosion sound if it's not null
            if (_balloonSound != null)
            {
                _balloonSound.Play();
            }
            //resets the position of balloon
            collision.gameObject.GetComponent<BalloonController>().Reset();
            //player scores 200 points
            Player.Instance.Score += 200;
        }
    }
}
