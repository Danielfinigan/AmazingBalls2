using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public static Ball Instance;
	public Rigidbody rb = new Rigidbody ();

	public void Awake () {
		Instance = this;
	}
}
