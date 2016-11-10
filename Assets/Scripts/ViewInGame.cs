using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewInGame : MonoBehaviour {
    
    public Text timerLabel;
    public Text powerUpLabel;
    public Image im;

    void Update()
    {
        if (GameManager.Instance.currentGameState == GameState.inGame)
        {            
            timerLabel.text = ("Score: " + GameManager.Instance.seconds);
        }

        if (PowerUps.instance != null)
        {
            if(PowerUps.instance.isPowerUp)
            {
                powerUpLabel.text = PowerUps.instance.powerUpText;
                StartCoroutine(Fade(powerUpLabel.text));
            }
        }
    }

    IEnumerator Fade(string text)
    {        
        yield return new WaitForSeconds(3f);
        powerUpLabel.text = "";
        PowerUps.instance.isPowerUp = false;
    }
}
