using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies2 : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    private int currentHealth; // Düþmanýn mevcut saðlýk deðeri
    private int maxHealth = 100; // Düþmanýn maksimum saðlýk deðeri

    private void Start()
    {
        currentHealth = maxHealth; // Düþmanýn saðlýðýný baþlangýçta maksimum deðere ayarlayýn.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "mermi2")
        {
            currentHealth -= 50; // Düþmanýn canýný 50 azaltýn
            if (currentHealth <= 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject); // Düþmaný yok edin
            }

            Destroy(collision.gameObject); // Mermiyi yok edin
        }
    }
}
