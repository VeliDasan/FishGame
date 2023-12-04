using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int maxHealth = 100; // Canavar�n maksimum sa�l�k de�eri
    private int currentHealth; // Canavar�n mevcut sa�l�k de�eri

    void Start()
    {
        currentHealth = maxHealth; // Canavar�n sa�l���n� maksimum de�erle ba�lat
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Hasar miktar�n� sa�l�ktan ��kar

        if (currentHealth <= 0)
        {
            Die(); // E�er canavar�n sa�l��� 0 veya daha azsa �l
        }
    }

    private void Die()
    {
        

        Destroy(gameObject); // Canavar� yok et
    }
}
