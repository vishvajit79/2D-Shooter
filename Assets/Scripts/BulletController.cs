using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    [SerializeField]
    public float speed;
    private Transform _transform;
    private float _xBounds;
    private float _yBounds;

    // Methods //

    void Start()
    {

        _transform = GetComponent<Transform>();
    }

    // Translates the bullet forwards. Distroys them after leaving the Camera.
    void Update()
    {

        // Get bounds of the Camera.main
        _xBounds = Camera.main.orthographicSize * Camera.main.aspect;
        _yBounds = Camera.main.orthographicSize;

        _transform.Translate(Vector3.up * speed);

        if (Mathf.Abs(transform.position.x) > _xBounds ||
                Mathf.Abs(transform.position.y) > _yBounds)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Enemy")){
            Debug.Log("Bullet collision\n");
            Player.Instance.Score += 100;
        }
    }
}
