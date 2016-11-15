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
		if ( col.gameObject.tag == "Brick" ) {
			
			BrickGenerator.Instance.DeleteBrick(col);
		}
        if (col.gameObject.tag == "LevelBox")
        {
            Destroy(this.gameObject);
        }
    }
}
