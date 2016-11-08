using UnityEngine;
using System.Collections;

public class KillTrigger : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
        Debug.Log("Killed");
        if (other.tag == "Ball")
		{
            Debug.Log("Ball tag");
			GameManager.Instance.GameOver();
			Ball2.Instance.rb.constraints = RigidbodyConstraints2D.FreezePosition;
			Debug.Log("Freeze Constraints");
		}
	}
}
