using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public SharedVariable moveSpeed;
    private GameManager _gameManager;
    [SerializeField] public bool scored;

    void Start()
    {
        Destroy(this.gameObject, 20.5f);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        this.transform.Translate(Vector2.left * moveSpeed.value * Time.deltaTime);
    }
    public void DestoyMe()
    {
        Destroy(this.gameObject);
    }
}
