using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damageToMonster = 50; // Mermi canavara çarpýnca vereceði hasar miktarý

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "mermi")
        {
            Destroy(collision.gameObject); // Mermiyi yok et

            // Canavara hasar ver (Eðer canavarýn bir "HealthBar" scripti varsa, o scriptteki uygun fonksiyonu çaðýrabilirsiniz)
            MonsterHealth monsterHealth = collision.gameObject.GetComponent<MonsterHealth>();
            if (monsterHealth != null)
            {
                monsterHealth.TakeDamage(damageToMonster);
            }
        }
    }
}

