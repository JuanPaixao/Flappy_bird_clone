using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyPressed : MonoBehaviour
{
    public KeyCode key;
    [SerializeField] private UnityEvent onkeyPressed;
    void Update()
    {
        if (Input.GetKeyDown(this.key))
        {
            this.onkeyPressed.Invoke();
        };
    }
}
