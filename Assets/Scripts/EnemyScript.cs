using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameManager gameManager;
    GameObject player;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.gameEntities.Add(this.gameObject);
    }

    public void Die()
    {
        gameManager.gameEntities.Remove(this.gameObject);
    }

    public void GoToPlayer()
    {
        float xDistance;
        float yDistance;
        xDistance = this.transform.position.x - player.transform.position.x;
        yDistance = this.transform.position.y - player.transform.position.y;

        if (xDistance < yDistance)
        {
            // uhhh go towards X
        }
        else
        {
            // go towards Y
        }
        
    }
}
