using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] private float _timeToSpawnEasy, _timeToSpawnHard;
    private float _actualTime;
    public GameObject Obstacle;
    public GameManager gameManager;
    void Start()
    {
        _actualTime = _timeToSpawnEasy;
    }
    void Update()
    {
        this._actualTime -= Time.deltaTime;
        if (_actualTime <= 0)
        {
            float randomNumber = Random.Range(-0.54f, 0.82f);
            Instantiate(Obstacle, new Vector2(this.transform.position.x, this.transform.position.y + randomNumber), Quaternion.identity);
            _actualTime = Mathf.Lerp(this._timeToSpawnEasy, this._timeToSpawnHard, gameManager.difficulty);
        }
    }
}