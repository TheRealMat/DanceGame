using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    GameManager gameManager;
    KeyCode lastHitKey;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // currently can't handle more than one input at a time, too bad!
        if (Input.GetKeyDown("w"))
        {
            //up
            gameManager.events.PlayerMoved(0, 1);
        }

        else if (Input.GetKeyDown("s"))
        {
            // down
            gameManager.events.PlayerMoved(0, -1);
        }

        else if (Input.GetKeyDown("d"))
        {
            //right
            gameManager.events.PlayerMoved(1, 0);
        }

        else if (Input.GetKeyDown("a"))
        {
            // left
            gameManager.events.PlayerMoved(-1, 0);
        }
        else if (Input.GetKeyDown("escape"))
        {
            gameManager.Pause();
        }


    }
}
