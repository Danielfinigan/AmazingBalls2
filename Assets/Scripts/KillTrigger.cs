using UnityEngine;
using System.Collections;

public class KillTrigger : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Ball")
		{
			GameManager.Instance.GameOver();
			Ball.Instance.rb.constraints = RigidbodyConstraints.FreezePosition;
			Debug.Log("Freeze Constraints");
		}
	}
}
