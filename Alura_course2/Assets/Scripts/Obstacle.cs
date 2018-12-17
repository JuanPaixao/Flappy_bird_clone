using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 _playerPosition;
    private GameManager _gameManager;
    private bool _scored;
    void Start()
    {
        Destroy(this.gameObject, 7.5f);
        this._playerPosition = GameObject.FindObjectOfType<Player>().transform.position;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (!_scored && this.transform.position.x <= _playerPosition.x)
        {
            _gameManager.AddPoints();
            this._scored = true;
        }
        this.transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
    public void DestoyMe()
    {
        Destroy(this.gameObject);
    }
}
