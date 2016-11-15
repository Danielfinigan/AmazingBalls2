using UnityEngine;
using System.Collections;

public class KillTrigger : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		if (GameManager.Instance.currentGameState == GameState.inGame && other.tag == "Ball")
		{
			GameManager.Instance.GameOver();
			Ball.Instance.rb.constraints = RigidbodyConstraints2D.FreezePosition;
		}

        if (GameManager.Instance.currentGameState == GameState.inGame && other.tag == "PowerUp")
        {
            Destroy(PowerUps.instance.gameObject);
        }
    }
}
