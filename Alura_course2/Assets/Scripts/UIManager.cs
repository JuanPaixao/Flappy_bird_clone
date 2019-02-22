using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{

    public GameObject gameOverImage;
    public Text score, record;
    public Sprite[] medalsImages;
    public Image medalObject;
    [SerializeField] private UnityEvent whenScored;


    public void SetGameOver(bool gameOver)
    {
        gameOverImage.SetActive(gameOver);
    }
    public void SetScore(int score)
    {
        this.whenScored.Invoke();
        this.score.text = score.ToString();
    }
    public void SetRecord(int record)
    {
        this.record.text = "Your max score is: " + record.ToString();
    }
    public void Medal(int score)
    {
        if (score <= 10)
        {
            medalObject.sprite = medalsImages[0];
        }
        else if (score > 10 && score <= 20)
        {
            medalObject.sprite = medalsImages[1];
        }
        else
        {
            medalObject.sprite = medalsImages[2];
        }
    }
}

