﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GameManager gameManager;
    float speed = 10;
    Vector3 desiredPosition;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.events.onMovePlayer += PlayerMove;
    }
    private void OnDisable()
    {
        gameManager.events.onMovePlayer -= PlayerMove;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, desiredPosition, step);
    }

    void PlayerMove(int x, int y)
    {
        // do this with an animation or something?
        desiredPosition = new Vector2(transform.position.x + x, transform.position.y + y);
    }
}
