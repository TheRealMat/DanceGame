using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    GameManager gameManager;
    public int damage = 1;
    private void start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.playerRef = this.gameObject;
    }

    public void Attack(Damageable damageable)
    {
        damageable.TakeDamage(damage);
    }
}
