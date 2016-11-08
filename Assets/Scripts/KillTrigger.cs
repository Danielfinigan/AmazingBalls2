using UnityEngine;
using System.Collections;

public class KillTrigger : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
        if (other.tag == "Ball")
		{
			GameManager.Instance.GameOver();
			Ball2.Instance.rb.constraints = RigidbodyConstraints2D.FreezePosition;
		}
	}
}
