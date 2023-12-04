using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    [SerializeField] private int damage = 1;
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HealthBar healthBar = collision.gameObject.GetComponent<HealthBar>();
            if (healthBar != null)
            {
                healthBar.TakeDamage(damage);

                if (healthBar.GetCurrentHealth() <= 0)
                {
                    // oyuncu öldükten sonra healthbarý çalýþtýr
                    Instantiate(playerExplosion, collision.transform.position, collision.transform.rotation);
                    //Destroy(collision.gameObject); // yok oldu player

                    collision.gameObject.SetActive(false);
                }
            }

            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject); // yok oldu enemy
        }
        else if (collision.tag == "mermi")
        {
           
            // mermi deðince yok olur düþman
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(collision.gameObject); 
            Destroy(gameObject); 
        }
    }
}


