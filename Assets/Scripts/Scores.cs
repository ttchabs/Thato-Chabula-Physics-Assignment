using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Scores : MonoBehaviour
{
   
   public enum Score

   {
      AiScore, PlayerScore
   }

   public UIManager uiManager;
   public Text AiScoreTxt, PlayerScoreTxt;

   public int MaxScore = 5;

   #region scores

   private int aiScore, playerScore;

   private int AiScore
   {
      get { return aiScore; }
      set
      {
         aiScore = value;
         if (value == MaxScore)
         {uiManager.ShowRestartCanvas(true);}
            
         
      }
   }
   
   private int PlayerScore
   {
      get { return playerScore; }
      set
      {
         playerScore = value;
         if (value == MaxScore)
         { uiManager.ShowRestartCanvas(false);}
            
         
      }
   }
   #endregion
   
   public void Increment(Score whichScore)
   {
      if (whichScore == Score.AiScore)
         AiScoreTxt.text = (++AiScore).ToString();
      else
         PlayerScoreTxt.text = (++PlayerScore).ToString();
   }

   public void ResetScores()
   {
      AiScore = PlayerScore = 0;
      AiScoreTxt.text = PlayerScoreTxt.text = "0";
   }

  
}
 