using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUps : MonoBehaviour {	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * 10f;
    }

    void OnTriggerEnter2D(Collider2D paddle)
    {
        if(paddle.tag == "paddle")
        {
			AudioSource powerup = GetComponent<AudioSource> ();
			powerup.Play ();
			int rnd = Random.Range(0, 0);
			if (rnd == 0) {
				BiggerBall();
			}

        }
    }
    public void BiggerBall()
    {
        Ball.Instance.transform.localScale = new Vector3(30f, 30f, 1f);
    }
}
