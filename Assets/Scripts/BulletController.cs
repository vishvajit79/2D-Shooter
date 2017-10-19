using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    [SerializeField]
    float xSpeed = 2f;
    [SerializeField]
    float yPos;

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

        if (_currentPosition.x >= 120)
        {
            Destroy(gameObject);
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
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
