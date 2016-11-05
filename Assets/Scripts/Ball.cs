using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public static Ball Instance;
	public RigidBody rb = new RigidBody ();

	public void Awake () {
		Instance = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
