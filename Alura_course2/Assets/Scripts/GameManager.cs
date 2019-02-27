using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uIManager;
    private Player _player;
    public int score, scoreSinceDeath;
    private int _maxScore;
    public ClickHand clickHand;
    public AudioClip scoreAudio;
    private AudioSource _audioSource;
    private float _gameTime;
    public float difficulty { get; private set; }
    [SerializeField]
    private float _changeDifficultTime;
    public bool someoneDead;
    public int deadPlayer;
    private Player[] _resPlayer;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _player = FindObjectOfType<Player>();
    }
    void Start()
    {
        score = 0;
        uIManager.SetScore(score);
        _maxScore = PlayerPrefs.GetInt("Record", _maxScore);
        uIManager.SetRecord(_maxScore);
        Time.timeScale = 1;
        _resPlayer = FindObjectsOfType<Player>();
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
    public void ImDead(string player)
    {
        this.scoreSinceDeath = 0;
        someoneDead = true;
        deadPlayer = player == "Player1Plane" ? 1 : 2;
        Debug.Log("I'm dead " + deadPlayer + "  " + player);
    }
    public void Revive()
    {
        if (someoneDead == true)
        {
            this.scoreSinceDeath++;
            if (this.scoreSinceDeath >= 2 || Input.GetKeyDown(KeyCode.R))
            {
                this.RevivePlayer();
            }
        }
    }
    private void RevivePlayer()
    {
        foreach (var resPlayer in this._resPlayer)
        {
            if (resPlayer.destroyed)
            {
                resPlayer.Revive();
            }
        }
    }
}
