using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatTrigger : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = this.GetComponent<Animator>();
        GameObject.FindObjectOfType<GameEvents>().onBeat += HeartBeat;
    }

    private void HeartBeat()
    {
        animator.SetTrigger("HeartBeat");
    }
}
