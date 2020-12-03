using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatTrigger : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    public void onBeat(){
        GameObject.FindObjectOfType<GameEvents>().onBeat += HeartBeat;
    }
    public void offBeat(){
        GameObject.FindObjectOfType<GameEvents>().onBeat -= HeartBeat;
    }
    public void HeartBeat()
    {
        animator.SetTrigger("HeartBeat");
    }
}
