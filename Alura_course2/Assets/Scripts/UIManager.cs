using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject gameOverImage;
    public Text score;

    public void SetGameOver(bool gameOver)
    {
        gameOverImage.SetActive(gameOver);
    }
    public void SetScore(int score)
    {
        this.score.text = score.ToString();
    }
}
