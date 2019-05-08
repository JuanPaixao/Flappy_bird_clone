using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float force;
    public bool destroyed, impulse;
    [SerializeField] private UnityEvent onHit, onRevive;
    private Vector2 _initialPos;
    private Animator _animator;
    private GameManager _gameManager;
    private ActiveCanvasInterface inactiveCanvas;
    public Camera[] playerCamera;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _initialPos = this.transform.position;
        _gameManager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        this.inactiveCanvas = GameObject.FindObjectOfType<ActiveCanvasInterface>();

    }
    void Update()
    {
        // if (!destroyed)
        // {
        //  if (Input.GetButtonDown("Fire1"))
        // {
        //     impulse = true;
        // }
        //  }
        this._animator.SetFloat("Speed_Y", this._rb.velocity.y);
    }
    void FixedUpdate()
    {
        if (impulse == true)
        {
            Impulse(force);
        }
    }
    public void SetImpulse()
    {
        if (!destroyed)
        {
            impulse = true;
        }
    }
    public void Impulse(float flyingForce)
    {
        _rb.velocity = Vector2.zero;
        _rb.AddForce(Vector2.up * flyingForce, ForceMode2D.Impulse);
        impulse = false;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name != "Wall")
        {
            _rb.simulated = false;
            this.onHit.Invoke();
            this.destroyed = true;
            if (this.gameObject.name == "Player1Plane")
            {
                _gameManager.ImDead(this.gameObject.name, playerCamera[0]);
            }
            else
            {
                _gameManager.ImDead(this.gameObject.name, playerCamera[1]);
            }
        }
    }
    public void ResetPosition()
    {
        this.transform.position = _initialPos;
        _rb.simulated = true;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("scored");
        _gameManager.AddPoints();
    }
    public void Revive()
    {
        this.onRevive.Invoke();
        this.destroyed = false;
        ResetPosition();
        Debug.Log("Revived " + this.transform.gameObject.name);
    }
}
