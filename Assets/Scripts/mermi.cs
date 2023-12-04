using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermi : MonoBehaviour
{
    public float speed;
    public GameObject hitEnemy;
    public int damageToMonster = 50; // Mermi canavara �arp�nca verece�i hasar miktar�

    private bool hasHitEnemy = false; // Mermi bir d��mana �arpt� m�?

  

    private void Update()
    {
        // E�er mermi d��mana �arpmad�ysa, hareketini devam ettir
        if (!hasHitEnemy)
        {
            gameObject.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            hasHitEnemy = true; // Mermi bir d��mana �arpt�

            hitEnemy.GetComponent<HitEnemy>().SendMessage("HitEnemyScore");
        }
        else if (collision.gameObject.tag == "shark")
        {
            // D��mana �arpt� ve hasar� ver
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
