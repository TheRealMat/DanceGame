using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.events.onPlayerMove += PlayerMove;
    }
    private void OnDisable()
    {
        gameManager.events.onPlayerMove -= PlayerMove;
    }

    void PlayerMove(int x, int y)
    {
        // do this with an animation or something?
        transform.position = new Vector2(transform.position.x + x, transform.position.y + y);
    }
}
