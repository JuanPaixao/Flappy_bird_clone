using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public SharedVariable moveSpeed;
    [SerializeField] public bool scored;

    void Start()
    {
        Destroy(this.gameObject, 20.5f);

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
