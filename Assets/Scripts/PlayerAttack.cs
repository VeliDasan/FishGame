using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damageToMonster = 50; // Mermi canavara �arp�nca verece�i hasar miktar�

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "mermi")
        {
            Destroy(collision.gameObject); // Mermiyi yok et

            // Canavara hasar ver (E�er canavar�n bir "HealthBar" scripti varsa, o scriptteki uygun fonksiyonu �a��rabilirsiniz)
            MonsterHealth monsterHealth = collision.gameObject.GetComponent<MonsterHealth>();
            if (monsterHealth != null)
            {
                monsterHealth.TakeDamage(damageToMonster);
            }
        }
    }
}

