using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uIManager;
    private Player _player;
    public int score;
    public AudioClip scoreAudio;
    private AudioSource _audioSource;
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _player = FindObjectOfType<Player>();
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        uIManager.SetGameOver(true);
    }
    void Start()
    {
        score = 0;
        uIManager.SetScore(score);
    }
    public void AddPoints()
    {
        score++;
        uIManager.SetScore(score);
        _audioSource.PlayOneShot(scoreAudio, 1f);
    }
    public void RestartGame()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        foreach (var obstacle in obstacles)
        {
            obstacle.DestoyMe();
        }
        _player.ResetPosition();
        Time.timeScale = 1;
        uIManager.SetGameOver(false);
        score = 0;
        uIManager.SetScore(score);
    }
}
