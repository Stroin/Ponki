using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int playerLeftScore = 0;
    private int playerRightScore = 0;

    public TextMeshProUGUI playerLeftScoreText;
    public TextMeshProUGUI playerRightScoreText;

    public void PlayerLeftScore()
    {
        playerLeftScore++;
        playerLeftScoreText.text = playerLeftScore.ToString();
    }

    public void PlayerRightScore()
    {
        playerRightScore++;
        playerRightScoreText.text = playerRightScore.ToString();
    }

}
