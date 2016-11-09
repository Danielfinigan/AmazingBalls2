using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * 10f;
    }

    void OnTriggerEnter2D(Collider2D paddle)
    {
        if(paddle.tag == "paddle")
        {
            BiggerBall();
        }
    }
    public void BiggerBall()
    {
        Ball.Instance.transform.localScale = new Vector3(30f, 30f, 1f);
    }
}
