using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uIManager;
    private Player _player;
    public int score;
    private int _maxScore;
    public ClickHand clickHand;
    public AudioClip scoreAudio;
    private AudioSource _audioSource;
    private float _gameTime;
    public float difficulty { get; private set; }
    [SerializeField]
    private float _changeDifficultTime;
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        this._gameTime += Time.deltaTime;
        this.difficulty = this._gameTime / _changeDifficultTime;
        this.difficulty = Mathf.Min(2, this.difficulty);
  
    }
    public void GameOver()
    {
        if (score > _maxScore)
        {
            SaveScore();
        }
        uIManager.Medal(score);
        uIManager.SetGameOver(true);
        Time.timeScale = 0;
    }
    void Start()
    {
        score = 0;
        uIManager.SetScore(score);
        _maxScore = PlayerPrefs.GetInt("Record", _maxScore);
        uIManager.SetRecord(_maxScore);
        Time.timeScale = 1;
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
        Time.timeScale = 1;
        uIManager.SetGameOver(false);
        score = 0;
        uIManager.SetScore(score);
        uIManager.SetRecord(_maxScore);
        _player.ResetPosition();
        if (clickHand != null)
        {
            clickHand.TurnImageOn();
        }
    }
    public void SaveScore()
    {
        _maxScore = score;
        PlayerPrefs.SetInt("Record", _maxScore);
        uIManager.SetRecord(_maxScore);
    }
}
