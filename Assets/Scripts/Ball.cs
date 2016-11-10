using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ball : MonoBehaviour {
	public static Ball Instance;
    //public static Ball Instance2;
	public float speed = 10f;
    public Rigidbody2D rb;
	public GameObject pUp;

    public Ball()
    {

    }
    void Awake()
    {
        Instance = this;
    }
	// Use this for initialization
	public void StartGame () {
		GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
	}

	float hitFactor(Vector2 ballPos, Vector2 hitPos,
		float paddlePos) {
		return (ballPos.x - hitPos.x) / paddlePos;
	}

	void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Paddle") {
            AudioSource ballHit = GetComponent<AudioSource>();
            ballHit.Play();
            // Calculate hit Factor
            float x = hitFactor (transform.position,
				          col.transform.position,
				          col.collider.bounds.size.x) * 2f;

			// Calculate direction, make length=1 via .normalized
			Vector2 dir = new Vector2 (x, 1).normalized;

			// Set Velocity with dir * speed
			GetComponent<Rigidbody2D> ().velocity = dir * speed;
		}

        //Spawns a powerUp
		if ( col.gameObject.tag == "Brick" ) {
            AudioSource ballHit = GetComponent<AudioSource>();
            ballHit.Play();
            BrickGenerator.Instance.DeleteBrick(col);

			int rnd = Random.Range (0, 4);
            if (rnd == 0 && PowerUps.instance == null) {
				Vector3 newSpawnPosition = new Vector3 (Ball.Instance.transform.position.x, Ball.Instance.transform.position.y, 0);
				Instantiate (pUp, newSpawnPosition, Quaternion.identity);
			}
		}
	}

    public void ResetBall()
    {
        StartCoroutine(Resetb());
    }
    public IEnumerator Resetb()
    {
        yield return new WaitForSeconds(20f);
        this.transform.localScale = new Vector3(10f, 10f, 1f);
    }
}


