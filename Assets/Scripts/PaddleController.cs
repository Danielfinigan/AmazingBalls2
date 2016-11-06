using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {
	//public float speed = 30;

	void FixedUpdate () {
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, -20);
		this.transform.position = mousePosition;
	}
}