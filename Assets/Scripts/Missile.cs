using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	public float speed = 1.5f;
	public Rigidbody2D rigidBody;
	public GameObject pUp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			rigidBody.velocity = new Vector3 (0, speed);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//Spawns a powerUp
		if ( col.gameObject.tag == "Brick" ) {
			
			BrickGenerator.Instance.DeleteBrick(col);
			int rnd = Random.Range (0, 4);
			if (rnd == 0 && PowerUps.instance == null) {
				Vector3 newSpawnPosition = new Vector3 (Ball.Instance.transform.position.x, Ball.Instance.transform.position.y, -8);
				Instantiate (pUp, newSpawnPosition, Quaternion.identity);
			}
		}
	}
}
