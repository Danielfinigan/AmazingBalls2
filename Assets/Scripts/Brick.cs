using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            BrickGenerator.Instance.DeleteBrick(this.GetComponent<Collision2D>());
        }
    }
}
