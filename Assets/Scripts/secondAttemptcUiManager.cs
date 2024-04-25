using UnityEngine;

using UnityEngine;

public class UIManager : MonoBehaviour {

    [Header("Canvas")]
    public GameObject CanvasGame;
    public GameObject CanvasRestart;

    [Header("CanvasRestart")]
    public GameObject WinTxt;
    public GameObject LooseTxt;

    [Header("Other")]

    public Scores scoreScript;
    public Countdown countdown;

    public puck puckScript;
    public PlayerPaddleMovement playerMovement;
    public secondndAiMovement aiScript;

    public void ShowRestartCanvas(bool didAiWin)
    {
        Time.timeScale = 0;

        CanvasGame.SetActive(false);
        CanvasRestart.SetActive(true);

        if (didAiWin)
        {
           
            WinTxt.SetActive(false);
            LooseTxt.SetActive(true);
        }
        else
        {
           
            WinTxt.SetActive(true);
            LooseTxt.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        CanvasGame.SetActive(true);
        CanvasRestart.SetActive(false);

       scoreScript.ResetScores();
       puckScript.CenterPuck();
       playerMovement.ResetPosition();
       aiScript.ResetPosition();
       countdown.BeginCountdown();
    }
}