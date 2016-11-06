using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {
	public float speed = 30;

	void FixedUpdate () {
		float v = Input.GetAxisRaw("Horizontal");
		GetComponent<Rigidbody>().velocity = new Vector3(v,0,0) * speed;
	}
}