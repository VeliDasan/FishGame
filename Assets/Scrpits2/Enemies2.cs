using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies2 : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    private int currentHealth; // D��man�n mevcut sa�l�k de�eri
    private int maxHealth = 100; // D��man�n maksimum sa�l�k de�eri

    private void Start()
    {
        currentHealth = maxHealth; // D��man�n sa�l���n� ba�lang��ta maksimum de�ere ayarlay�n.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "mermi2")
        {
            currentHealth -= 50; // D��man�n can�n� 50 azalt�n
            if (currentHealth <= 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject); // D��man� yok edin
            }

            Destroy(collision.gameObject); // Mermiyi yok edin
        }
    }
}
