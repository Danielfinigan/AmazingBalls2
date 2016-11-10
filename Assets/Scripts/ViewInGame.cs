using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewInGame : MonoBehaviour {
    
    public Text timerLabel;

    void Update()
    {
        if (GameManager.Instance.currentGameState == GameState.inGame)
        {            
            timerLabel.text = ("Score: " + GameManager.Instance.seconds);
        }
        //Power Up text controlled from PowerUps.cs
    }
}
