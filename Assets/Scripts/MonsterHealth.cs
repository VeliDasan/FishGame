using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int maxHealth = 100; // Canavarýn maksimum saðlýk deðeri
    private int currentHealth; // Canavarýn mevcut saðlýk deðeri

    void Start()
    {
        currentHealth = maxHealth; // Canavarýn saðlýðýný maksimum deðerle baþlat
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Hasar miktarýný saðlýktan çýkar

        if (currentHealth <= 0)
        {
            Die(); // Eðer canavarýn saðlýðý 0 veya daha azsa öl
        }
    }

    private void Die()
    {
        

        Destroy(gameObject); // Canavarý yok et
    }
}
