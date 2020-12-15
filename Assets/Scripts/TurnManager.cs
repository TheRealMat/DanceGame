using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.events.onPlayerMove += PlayerMove;
    }



    public void PlayerMove(int x, int y)
    {
        // tell player to move
        gameManager.events.MovePlayer(x, y);

        // then move enemies
        EnemyMove();
    }
    // if player failed to move, move enemies. this should be an event
    public void BeatMissed()
    {

        EnemyMove();
    }

    // should probably know where all enemies want to go so they can move together better
    public void EnemyMove()
    {
        gameManager.events.MoveEnemies();
    }
}
