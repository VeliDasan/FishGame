using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMekanizma : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    HealthBar2 healthBar2Script;
    Rigidbody2D rb;
    public int damageAmount = 1;
    private Player2 player2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player2 = FindObjectOfType<Player2>(); // Player2 komponentine sahip nesneyi bul
        
    }

    private void FixedUpdate()
    {
        rb.velocity = -transform.right * bulletSpeed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        if (collision.gameObject.tag == "Player2")
        {
            if (player2 != null && !player2.Shielded)
            {
                collision.gameObject.GetComponent<HealthBar2>().TakeDamage(damageAmount);
            }

           
        }
    }
}
