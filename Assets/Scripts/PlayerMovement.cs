using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
    GameManager gameManager;
    PlayerScript playerScript;
    float speed = 10;
    public Vector3 desiredPosition;
    public bool attacking = false;
    Vector3 previousPosition;

    void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
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
        if (attacking)
        {
            if(transform.position == desiredPosition)
            {
                desiredPosition = previousPosition;
                attacking = false;
            }
        }
    }

    void PlayerMove(int x, int y)
    {
        previousPosition = this.transform.position;

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
            playerScript.Attack(enemy.GetComponent<Damageable>());
            desiredPosition = new Vector2(transform.position.x + (float)x / 2, transform.position.y + (float)y / 2);
            attacking = true;
        }

    }
}
