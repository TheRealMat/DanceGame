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
        // using this let's you hold down a button and then press another button to fool the system. too bad!
        if (Input.anyKeyDown)
        {
            // currently can't handle more than one input at a time, too bad!
            if (Input.GetAxis("Vertical") > 0)
            {
                //up
                gameManager.events.PlayerMoved(0, 1);
            }

            else if (Input.GetAxis("Vertical") < 0)
            {
                // down
                gameManager.events.PlayerMoved(0, -1);
            }

            else if (Input.GetAxis("Horizontal") > 0)
            {
                //right
                gameManager.events.PlayerMoved(1, 0);
            }

            else if (Input.GetAxis("Horizontal") < 0)
            {
                // left
                gameManager.events.PlayerMoved(-1, 0);
            }
        }
        if (Input.GetKeyDown("escape"))
        {
            gameManager.Pause();
        }


    }
}
