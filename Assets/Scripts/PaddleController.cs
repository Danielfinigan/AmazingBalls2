using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {
	//public float speed = 30;
	public static PaddleController Instance;
	public bool isBiggerPaddle;
	public int biggerPaddleTime;

	void Awake () {
		Instance = this;
	}
	void FixedUpdate () {
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, -20);
		this.transform.position = mousePosition;
	}

	public void ResetPaddle()
	{
		StartCoroutine(Resetb());
	}
	public IEnumerator Resetb()
	{
		for(int i = 10; i > 0; i--)
		{
			biggerPaddleTime = i;
			yield return new WaitForSeconds(1f);
		}
		this.transform.localScale = new Vector3(10f, 10f, 1f);
		isBiggerPaddle = false;
	}
}