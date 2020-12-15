using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameManager gameManager;
    GameObject player;

    float speed = 5;

    private void Start()
    {
        player = FindObjectOfType<PlayerScript>().gameObject;
        gameManager = FindObjectOfType<GameManager>();
        gameManager.gameEntities.Add(this);
        gameManager.events.onMoveEnemies += GoToPlayer;
    }
    public void Die()
    {
        gameManager.events.onMoveEnemies -= GoToPlayer;
        gameManager.gameEntities.Remove(this);
    }

    public void GoToPlayer()
    {
        float xDistance;
        float yDistance;
        xDistance = this.transform.position.x - player.transform.position.x;
        yDistance = this.transform.position.y - player.transform.position.y;

        float step = speed * Time.deltaTime;

        Debug.Log(xDistance);
        Debug.Log(yDistance);

        if (Mathf.Abs(xDistance) > Mathf.Abs(yDistance))
        {
            Debug.Log("go x!");
            // go toward X
            if (Mathf.Abs(xDistance) != xDistance) //number is negative)
            {
                transform.position += Vector3.right;
            }
            else
            {
                transform.position += Vector3.left;
            }
        }
        else
        {
            Debug.Log("go y!");
            // go towards Y
            if (Mathf.Abs(yDistance) != yDistance) //number is negative)
            {
                transform.position += Vector3.up;
            }
            else
            {
                transform.position += Vector3.down;
            }
        }
    }
}
