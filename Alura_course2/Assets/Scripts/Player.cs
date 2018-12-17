using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D _rb;
    public float force;
    public bool destroyed;
    private GameManager _gameManager;
    private Vector2 _initialPos;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _initialPos = this.transform.position;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (!destroyed)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Impulse(force);
            }
        }
    }
    private void Impulse(float flyingForce)
    {
        _rb.velocity = Vector2.zero;
        _rb.AddForce(Vector2.up * flyingForce, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name!="Wall"){
            _rb.simulated = false;
        _gameManager.GameOver();
        }
    }
    public void ResetPosition()
    {
        this.transform.position = _initialPos; 
        _rb.simulated = true;
        
    }
}
