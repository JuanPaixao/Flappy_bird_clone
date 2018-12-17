using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHand : MonoBehaviour
{
    private SpriteRenderer _sprite;
    public float timeToTurnOff;
    void Awake()
    {
        _sprite = this.GetComponent<SpriteRenderer>();
    }
    public void TurnImageOn()
    {
        this._sprite.enabled = true;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this._sprite.enabled = false;
        }
    }
}