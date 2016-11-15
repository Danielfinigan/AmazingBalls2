using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.tag == "Ball")
        {
            BrickGenerator.Instance.DeleteBrick(this.GetComponent<Collision2D>());
			Debug.Log ("ball hit brick");
        }

		if (other.tag == "Missile") {
			Debug.Log ("collided with missile");
		}
    }
}
