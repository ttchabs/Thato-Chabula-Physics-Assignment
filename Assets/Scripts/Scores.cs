using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Scores : MonoBehaviour
{
    public enum Score
    {
      AiScore,PlayerScore  
    }
    public Text AiScoreTxt, PlayerScoreTxt;
    private int aiScore, playerScore;
    
    

    public void Increment(Score whichScore)
    {
        if (whichScore == Score.AiScore)
          AiScoreTxt.text = (++aiScore).ToString();
        else if(whichScore==Score.PlayerScore)
          PlayerScoreTxt.text = (++playerScore).ToString();
    }

    public int AiScore
    {
        get
        {
            return aiScore;
        }
        set
        {
            aiScore = value;
        }
        
    }
    
    public int PlayerScore
    {
        get
        {
            return playerScore;
        }
        set
        {
            playerScore = value;
        }
        
    }
}
