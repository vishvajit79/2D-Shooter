using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    [SerializeField]
    GameController gameController;
    [SerializeField]
    GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("Enemy collision\n");
            Instantiate (explosion).GetComponent<Transform>().position = collision.gameObject.GetComponent<Transform>().position;
            collision.gameObject.GetComponent<EnemyController>().Reset();
            Player.Instance.Health -= 10;
            StartCoroutine("Blink");
        }
    }
}
