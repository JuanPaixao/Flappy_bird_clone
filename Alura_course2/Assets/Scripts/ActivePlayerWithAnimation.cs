using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivePlayerWithAnimation : MonoBehaviour
{
    [SerializeField] private UnityEvent onAnimationFinish;
    public void ActivePlayer()
    {
        this.onAnimationFinish.Invoke();
    }
}
