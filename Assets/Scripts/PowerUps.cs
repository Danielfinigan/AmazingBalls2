using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUps : MonoBehaviour {

    public static PowerUps instance;
    public bool gotPowerUp = false;
    public string powerUpText;
    private string _whichPowerUp = "";
    private IEnumerator coroutine;

    void Awake()
    {
        instance = this;
    }
	// Update is called once per frame    
	void Update () {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * 10f;
    }

    void OnTriggerEnter2D(Collider2D paddle)
    {
        if(paddle.tag == "Paddle")
        {
			AudioSource powerup = GetComponent<AudioSource> ();
			powerup.Play ();

            int rnd = Random.Range(0, 4);
			if (rnd == 0)
            {
				TimeSaver();
			}
            else if (rnd > 0)
            {
                BiggerBall();
            }
            powerUpText = ("Power Up: " + _whichPowerUp);
            gotPowerUp = true;

            //Disables the sprite, object is destroyed in KillTrigger.cs
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    public void BiggerBall()
    {
        _whichPowerUp = "Amazing Ball!";
        //BrickGenerator.Instance.BreakthroughBricks();
        Ball.Instance.transform.localScale = new Vector3(30f, 30f, 1f);
        Ball.Instance.isBiggerBall = true;
        Ball.Instance.ResetBall();
    }

    public void TimeSaver()
    {
        _whichPowerUp = "Time Saver!";
        GameManager.Instance.timer -= 10;
    }
    
    //spawns a second ball
    /*public void AmazingBalls()
    {
        _whichPowerUp = "AMAZING BALLS!!";
        Ball.Instance2.enabled = true;
        Vector3 spawnposition = new Vector3(Ball.Instance.transform.position.x, Ball.Instance.transform.position.y, 0);
        Ball.Instance2.transform.position = spawnposition;
        Ball.Instance2.GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;
    }*/
}
