using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameManager gameManager;
    PlayerMovement player;
    public int moveEvery;
    int movesWaited = 1;
    Vector3 desiredPosition;
    float speed = 10;
    int damage = 1;
    public bool attacking = false;
    Vector3 previousPosition;

    private void Start()
    {
        desiredPosition = this.transform.position;
        player = FindObjectOfType<PlayerMovement>();
        gameManager = FindObjectOfType<GameManager>();
        gameManager.gameEntities.Add(this);
        gameManager.events.onMoveEnemies += Move;
    }
    private void OnDestroy()
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
        // also should probably snap to whole numbers
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, desiredPosition, step);

        if (attacking)
        {
            if (transform.position == desiredPosition)
            {
                desiredPosition = previousPosition;
                attacking = false;
            }
        }
    }
    public void Attack(Damageable damageable)
    {
        damageable.TakeDamage(damage);
    }

    public void GoToPlayer()
    {
        float xDistance;
        float yDistance;
        xDistance = this.transform.position.x - player.transform.position.x;
        yDistance = this.transform.position.y - player.transform.position.y;

        previousPosition = this.transform.position;

        // if this can't be done in a less stupid way i'll heat my shoe
        if (Mathf.Abs(xDistance) > Mathf.Abs(yDistance))
        {
            // go toward X
            if (Mathf.Abs(xDistance) != xDistance) //number is negative)
            {
                // check if we're gonna hit player
                if (desiredPosition + Vector3.right == player.desiredPosition)
                {
                    // attack player
                    Attack(player.GetComponent<Damageable>());
                    desiredPosition = transform.position + Vector3.right / 2;
                    attacking = true;
                }
                else
                {
                    desiredPosition = transform.position + Vector3.right;
                }
            }
            else
            {
                if (desiredPosition + Vector3.left == player.desiredPosition)
                {
                    // attack player
                    Attack(player.GetComponent<Damageable>());
                    desiredPosition = transform.position + Vector3.left / 2;
                    attacking = true;
                }
                else
                {
                    desiredPosition = transform.position + Vector3.left;
                }
            }
        }
        else
        {
            // go towards Y
            if (Mathf.Abs(yDistance) != yDistance) //number is negative)
            {
                if (desiredPosition + Vector3.up == player.desiredPosition)
                {
                    // attack player
                    Attack(player.GetComponent<Damageable>());
                    desiredPosition = transform.position + Vector3.up / 2;
                    attacking = true;
                }
                else
                {
                    desiredPosition = transform.position + Vector3.up;
                }
            }
            else
            {
                if (desiredPosition + Vector3.down == player.desiredPosition)
                {
                    // attack player
                    Attack(player.GetComponent<Damageable>());
                    desiredPosition = transform.position + Vector3.down / 2;
                    attacking = true;
                }
                else
                {
                    desiredPosition = transform.position + Vector3.down;
                }
            }
        }
    }
}
