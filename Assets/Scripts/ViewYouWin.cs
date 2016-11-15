using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewYouWin : MonoBehaviour {

    public Text timerLabel;

    void Update()
    {
        if (GameManager.Instance.currentGameState == GameState.youWin)
        {
            timerLabel.text = ("Score: " + GameManager.Instance.seconds + " seconds");
        }
    }
}
