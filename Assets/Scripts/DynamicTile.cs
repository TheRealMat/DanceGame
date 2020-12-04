using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTile : MonoBehaviour
{
    GameManager gameManager;
    Sprite tile1;
    Sprite tile1Active;
    Sprite tile2;
    Sprite tile2Active;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        CalculateTiles();
        gameManager.events.onBeat += SwitchTiles;

    }
    private void SwitchTiles()
    {

    }
    private void CalculateTiles()
    {
        // is X even?
        if (this.transform.position.x % 2 == 0)
        {

            if (this.transform.position.y % 2 == 0)
            {
                // tile is EVEN/EVEN
                // tile 1
            }
            else
            {
                // tile is EVEN/UNEVEN
                // tile 2
            }
        }
        else
        {
            if (this.transform.position.y % 2 == 0)
            {
                // tile is UNEVEN/EVEN
                // tile 2
            }
            else
            {
                // tile is UNEVEN/UNEVEN
                // tile 1
            }
        }
    }
}
