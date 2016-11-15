using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewInGame : MonoBehaviour {
    
    public Text timerLabel;
    public Text powerUpLabel;
    public Text biggerBallTimeRemaining;
    public Text biggerPaddleTimeRemaining;

    void Update()
    {
        if (GameManager.Instance.currentGameState == GameState.inGame)
        {            
            timerLabel.text = ("Score: " + GameManager.Instance.score.ToString("0000"));
        }

        //check that power up exists
        if(PowerUps.instance != null)
        {
            //check that player got the power up
            if (PowerUps.instance.gotPowerUp)
            {
                powerUpLabel.text = PowerUps.instance.powerUpText;
                //Have text pop up for 2 seconds the dissappear
                StartCoroutine(Fade(powerUpLabel.text));
            }
        }

        if (Ball.Instance.isBiggerBall)
        {
            biggerBallTimeRemaining.text = ("Bigger Ball: " + Ball.Instance.biggerBallTime.ToString());
        }
        else
        {
            biggerBallTimeRemaining.text = "";
        }

        if (PaddleController.Instance.isBiggerPaddle)
        {
            biggerPaddleTimeRemaining.text = ("Bigger Paddle: " + PaddleController.Instance.biggerPaddleTime.ToString());
        }
        else
        {
            biggerPaddleTimeRemaining.text = "";
        }
    }

    IEnumerator Fade(string text)
    {        
        yield return new WaitForSeconds(2f);
        powerUpLabel.text = "";
        PowerUps.instance.gotPowerUp = false;
    }
}
