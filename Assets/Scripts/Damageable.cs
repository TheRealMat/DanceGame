using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    GameManager gameManager;
    public int maxHealth;
    int currentHealth;
    public AudioClip hitSound;
    public AudioClip dieSound;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        if(damage >= currentHealth)
        {
            currentHealth = 0;
            gameManager.musicSource.PlayOneShot(dieSound);
            Destroy(this.gameObject);
        }
        else
        {
            currentHealth -= damage;
            gameManager.musicSource.PlayOneShot(hitSound);
        }
    }
}
