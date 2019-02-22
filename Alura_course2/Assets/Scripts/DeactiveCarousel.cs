using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveCarousel : MonoBehaviour
{
    private Carousel[] _carousel;
    private SpawnObstacles _obstacle;
    void Start()
    {
        this._carousel = this.GetComponentsInChildren<Carousel>();
        this._obstacle = this.GetComponentInChildren<SpawnObstacles>();
    }
    public void Deactive()
    {
        foreach (var carousel in _carousel)
        {
            carousel.enabled = false;
        }
        _obstacle.StopObstacles();
    }
}
