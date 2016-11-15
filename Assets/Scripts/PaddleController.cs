using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {
	//public float speed = 30;
	public static PaddleController Instance;
	public bool isBiggerPaddle;
	public int biggerPaddleTime;
	public bool firingMissiles = false;
	public Missile miss;
	public int missileTime;

	void Awake () {
		Instance = this;
	}

	void FixedUpdate () {
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, -20);
		this.transform.position = mousePosition;
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && firingMissiles == true)
			fireMissile ();
	}

	public void fireMissile() {
        Missile missileClone;
        Vector2 missileSpawn = new Vector2(this.transform.position.x, this.transform.position.y + 1);
        missileClone = (Missile) Instantiate(miss, missileSpawn, Quaternion.identity);
	}

	public void ResetMissiles()
	{
		StartCoroutine(Resetm());
	}

	public IEnumerator Resetm()
	{
		for(int i = 4; i > 0; i--)
		{
			missileTime = i;
			yield return new WaitForSeconds(1f);
		}
		firingMissiles = false;
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