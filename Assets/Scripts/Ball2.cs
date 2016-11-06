using UnityEngine;
using System.Collections;

public class Ball2 : MonoBehaviour {
	public static Ball2 Instance;
	public float speed = 10f;
	public void Awake () {
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;

	}

	float hitFactor(Vector2 ballPos, Vector2 hitPos,
		float paddlePos) {
		// ascii art:
		// ||  1 <- at the top of the racket
		// ||
		// ||  0 <- at the middle of the racket
		// ||
		// || -1 <- at the bottom of the racket
		return (ballPos.x - hitPos.x) / paddlePos;
	}
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D col) {
		// Note: 'col' holds the collision information. If the
		// Ball collided with a racket, then:
		//   col.gameObject is the racket
		//   col.transform.position is the racket's position
		//   col.collider is the racket's collider

		// Hit the left Racket?
		if (col.gameObject.name == "Paddle") {
			// Calculate hit Factor
			float x = hitFactor(transform.position,
				col.transform.position,
				col.collider.bounds.size.x);

			// Calculate direction, make length=1 via .normalized
			Vector2 dir = new Vector2(x, 1).normalized;

			// Set Velocity with dir * speed
			GetComponent<Rigidbody2D>().velocity = dir * speed;
		}

}
}
