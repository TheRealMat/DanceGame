using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
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


    }
}
