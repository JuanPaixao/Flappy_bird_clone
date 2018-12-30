using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carousel : MonoBehaviour
{

    [SerializeField] SharedVariable _speed;
    private Vector3 _initialPos;
    private float realGroundSize;
    void Awake()
    {
        this._initialPos = this.transform.position;
        float groundSpriteSize = this.GetComponent<SpriteRenderer>().size.x;
        float scaleSize = this.transform.localScale.x;
        realGroundSize = scaleSize * groundSpriteSize;
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Mathf.Repeat(_speed.value * Time.time, this.realGroundSize); // move until the groundsize, when it reaches, repeat the translation
        this.transform.position = this._initialPos + Vector3.left * movement;
    }
}
