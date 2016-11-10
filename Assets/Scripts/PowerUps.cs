using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PowerUps : MonoBehaviour {

    private string _powerUpText = "";
    //public Text powerUp; 

	// Update is called once per frame    
	void Update () {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * 10f;

        //powerUp.text = ("Power Up: " + powerUpText);
    }

    void OnTriggerEnter2D(Collider2D paddle)
    {
        if(paddle.tag == "paddle")
        {
			AudioSource powerup = GetComponent<AudioSource> ();
			powerup.Play ();
            Destroy(this.gameObject);
            int rnd = Random.Range(0, 0);
			if (rnd == 0) {
				TimeSaver();
			}

        }
    }
    public void BiggerBall()
    {
        _powerUpText = "Bigger Ball!";
        Ball.Instance.transform.localScale = new Vector3(30f, 30f, 1f);
        Destroy(this.gameObject);
    }

    public void TimeSaver()
    {
        _powerUpText = "Time Saver!";
        GameManager.Instance.timer -= 10;
    }
}
