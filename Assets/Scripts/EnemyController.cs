using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enenmy controller script  - For Birds*
public class EnemyController : MonoBehaviour
{

    [SerializeField]
    float minXSpeed = 2f;
    [SerializeField]
    float maxXSpeed = 5f;
    [SerializeField]
    float minYSpeed = -2f;
    [SerializeField]
    float maxYSpeed = 2f;

    private Transform _transform;
    private Vector2 _currentSpeed;
    private Vector2 _currentPosition;

    // Use this for initialization
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
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

    IEnumerator StartDifficultLevel()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length < 10)
        {
            int time = Random.Range(10, 20);

            yield return new WaitForSeconds((float)time);
            Instantiate(gameObject);
            StartCoroutine(StartDifficultLevel());
        }
        
    }
}