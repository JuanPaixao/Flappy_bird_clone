using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
{
    private Player _player;
    void Start()
    {
        this._player = this.GetComponent<Player>();
        StartCoroutine(this.AddImpulseRoutine());
    }
    private IEnumerator AddImpulseRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.75f);
            this._player.SetImpulse();
        }
    }
}
