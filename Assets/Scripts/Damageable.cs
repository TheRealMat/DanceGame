using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        if(damage >= currentHealth)
        {
            currentHealth = 0;
            Destroy(this.gameObject);
        }
        else
        {
            currentHealth -= damage;
        }
    }
}
