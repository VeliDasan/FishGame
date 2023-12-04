using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermi : MonoBehaviour
{
    public float speed;
    public GameObject hitEnemy;
    public int damageToMonster = 50; // Mermi canavara çarpýnca vereceði hasar miktarý

    private bool hasHitEnemy = false; // Mermi bir düþmana çarptý mý?

  

    private void Update()
    {
        // Eðer mermi düþmana çarpmadýysa, hareketini devam ettir
        if (!hasHitEnemy)
        {
            gameObject.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            hasHitEnemy = true; // Mermi bir düþmana çarptý

            hitEnemy.GetComponent<HitEnemy>().SendMessage("HitEnemyScore");
        }
        else if (collision.gameObject.tag == "shark")
        {
            // Düþmana çarptý ve hasarý ver
            MonsterHealth monsterHealth = collision.gameObject.GetComponent<MonsterHealth>();
            if (monsterHealth != null)
            {
                monsterHealth.TakeDamage(damageToMonster);
            }

            // Mermiyi yok et
            Destroy(gameObject);
        }
    }

    
}
