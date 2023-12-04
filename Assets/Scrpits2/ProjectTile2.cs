using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTile2 : MonoBehaviour
{
	float moveSpeed = 20f;

	Rigidbody2D rb;

	Player2 target;
	Vector2 moveDirection;
	public int damageAmount = 1;
	private Player2 player2;




	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindObjectOfType<Player2>();
		player2 = target; // Player2 script'ine sahip olan nesneyi player2 deðiþkenine atayýn
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		Destroy(gameObject, 3f);
	}



	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player2")
		{
			if (!player2.Shielded)
			{
				collision.gameObject.GetComponent<HealthBar2>().TakeDamage(damageAmount);

			}
			// Oyuncuya hasar ver

			Destroy(gameObject);

		}
	}
}
