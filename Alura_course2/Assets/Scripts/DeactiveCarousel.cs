using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveCarousel : MonoBehaviour
{
    private Carousel[] _carousel;
    private SpawnObstacles _obstacle;
    private Player _player;
    void Start()
    {
        this._carousel = this.GetComponentsInChildren<Carousel>();
        this._obstacle = this.GetComponentInChildren<SpawnObstacles>();
        this._player = this.GetComponentInChildren<Player>();
    }
    public void Deactive()
    {
        foreach (var carousel in _carousel)
        {
            carousel.enabled = false;
        }
        _obstacle.StopObstacles();
    }
    public void Active()
    {
        this._player.ResetPosition();
        foreach (var carousel in _carousel)
        {
            carousel.enabled = true;
        }
        _obstacle.StartObstacles();
    }
}
