using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	public float speed = 1.5f;
	public Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			rigidBody.velocity = new Vector3 (0, speed, 0);
	}
}
