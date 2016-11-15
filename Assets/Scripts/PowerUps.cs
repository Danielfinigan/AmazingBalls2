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
            //int rnd = Random.Range(2, 4);
            int rnd = Ball.Instance.demo;
            Debug.Log("Random : " + rnd);
			if (rnd == 0) {
				BonusPoints();
			} else if (rnd < 2 && !PaddleController.Instance.isBiggerPaddle) {
				BiggerPaddle ();
			}
            else if(rnd < 4 && !Ball.Instance.isBiggerBall)
            {
                BiggerBall();
            }
            else 
            {
				Missile();
            }
            powerUpText = ("Power Up: " + _whichPowerUp);
            gotPowerUp = true;

            Ball.Instance.demo = (Ball.Instance.demo + 1) % 5;

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

    public void BonusPoints()
    {
        _whichPowerUp = "Bonus Points! +100";
        GameManager.Instance.score += 100;
    }
    
	public void BiggerPaddle()
	{
		_whichPowerUp = "Bigger Paddle!";
		PaddleController.Instance.transform.localScale = new Vector3(20f, 10f, 1f);
		PaddleController.Instance.isBiggerPaddle = true;
		PaddleController.Instance.ResetPaddle();
	}

	public void Missile()
	{
		_whichPowerUp = "Missile!";
		PaddleController.Instance.firingMissiles = true;
		//PaddleController.Instance.ResetMissiles ();
	}
}
