using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    // subscribe to this
    public event Action onBeat;
    // fires trigger
    public void BeatHappened()
    {
        if (onBeat != null)
        {
            onBeat();
        }
    }

    public event Action<int, int> onPlayerMove;
    public void PlayerMoved(int x, int y)   
    {
        if (onPlayerMove != null)
        {
            onPlayerMove(x, y);
        }
    }
}
