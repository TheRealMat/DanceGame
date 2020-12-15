using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
    GameManager gameManager;
    float speed = 10;
    public Vector3 desiredPosition;
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
        // really needs something to prevent it from moving while it's already moving
        // also should probably snap to whole numbers
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, desiredPosition, step);
    }

    void PlayerMove(int x, int y)
    {   


        // check if moving into an enemy
        EnemyScript enemy = (from item in gameManager.gameEntities
                    where item.transform.position.x == transform.position.x + x && item.transform.position.y == transform.position.y + y
                             select item).FirstOrDefault();

        if (enemy == null)
        {
            // do this with an animation or something?
            desiredPosition = new Vector2(transform.position.x + x, transform.position.y + y);
        }
        else
        {
            // attack enemy
        }

    }
}
