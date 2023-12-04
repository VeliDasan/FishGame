using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMekanizma : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float rotationSpeed; // Eklendi: Dönüþ hýzý
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
        if (player2 != null)
        {
            Vector2 moveDirection = (player2.transform.position - transform.position).normalized;
            rb.velocity = moveDirection * bulletSpeed;

            // Eklendi: Hedefe doðru dönüþ hesaplamasý
            float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            if (player2 != null && !player2.Shielded)
            {
                collision.gameObject.GetComponent<HealthBar2>().TakeDamage(damageAmount);
            }
        }

        gameObject.SetActive(false);
    }
}
