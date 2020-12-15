using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameManager gameManager;
    GameObject player;
    public int moveEvery;
    int movesWaited = 1;
    Vector3 desiredPosition;
    float speed = 10;

    private void Start()
    {
        player = FindObjectOfType<PlayerScript>().gameObject;
        gameManager = FindObjectOfType<GameManager>();
        gameManager.gameEntities.Add(this);
        gameManager.events.onMoveEnemies += Move;
    }
    public void Die()
    {
        gameManager.events.onMoveEnemies -= Move;
        gameManager.gameEntities.Remove(this);
    }

    // handles if enemy should move or wait another turn
    private void Move()
    {
        if (movesWaited >= moveEvery)
        {
            movesWaited = 1;
            GoToPlayer();
        }
        else
        {
            movesWaited++;
        }
    }

    private void Update()
    {
        // really needs something to prevent it from moving while it's already moving
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, desiredPosition, step);
    }


    public void GoToPlayer()
    {
        float xDistance;
        float yDistance;
        xDistance = this.transform.position.x - player.transform.position.x;
        yDistance = this.transform.position.y - player.transform.position.y;

        if (Mathf.Abs(xDistance) > Mathf.Abs(yDistance))
        {
            // go toward X
            if (Mathf.Abs(xDistance) != xDistance) //number is negative)
            {
                desiredPosition = transform.position + Vector3.right;
            }
            else
            {
                desiredPosition = transform.position + Vector3.left;
            }
        }
        else
        {
            // go towards Y
            if (Mathf.Abs(yDistance) != yDistance) //number is negative)
            {
                desiredPosition = transform.position + Vector3.up;
            }
            else
            {
                desiredPosition = transform.position + Vector3.down;
            }
        }
    }
}
