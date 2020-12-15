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

    // these 2 events look almost the same
    // this one is for moving the player, the other is when the player attempts to move
    public event Action<int, int> onMovePlayer;
    public void MovePlayer(int x, int y)
    {
        if (onMovePlayer != null)
        {
            onMovePlayer(x, y);
        }
    }


    public event Action onMoveEnemies;
    public void MoveEnemies()
    {
        if (onMoveEnemies != null)
        {
            onMoveEnemies();
        }
    }
}
