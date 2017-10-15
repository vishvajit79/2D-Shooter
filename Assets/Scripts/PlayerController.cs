using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player controller script  - For Rocket*
public class PlayerController : MonoBehaviour
{
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
	private Transform _shoot;

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
		Shoot ();

 
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

        if(moveVertical < 0)
        {
            //if up arrow is pressed move up = W
            _currentPos -= new Vector2(0, speed);
        }

        if(moveVertical > 0)
        {
            //if down arrow is pressed move down = S
            _currentPos += new Vector2(0, speed);
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

	private void Shoot ()
	{
		if (Input.GetKeyDown("space")) {
			Debug.Log ("Shoot");
		}
	}
}
