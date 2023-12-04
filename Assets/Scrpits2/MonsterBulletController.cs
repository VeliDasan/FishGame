using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBulletController : MonoBehaviour
{
    public GameObject bulletPrefab; // Mermi prefab'ý
    public Transform ateþNoktasý; // Ateþ noktasý transformu
    public float ateþHýzý; // Ateþ hýzý

    private Vector2 canavarYönü; // Canavarýn hareket yönünü saklayacaðýmýz deðiþken

    void Start()
    {
        // Saniyede bir defa ateþ etmeyi baþlat
        InvokeRepeating("AteþEt", 0f, 1f);
    }

    private void AteþEt()
    {
        // Mermi prefab'ýný ateþ noktasýnda oluþtur
        if (bulletPrefab != null && ateþNoktasý != null)
        {
            GameObject mermi = Instantiate(bulletPrefab, ateþNoktasý.position, Quaternion.identity);
            Rigidbody2D mermiRigidbody = mermi.GetComponent<Rigidbody2D>();

            // Canavarýn döndüðü yöne göre mermiye ateþ hýzýný ver
            mermiRigidbody.velocity = canavarYönü * ateþHýzý;
        }
    }

    void Update()
    {
        // Canavarýn hareket yönünü güncelle
        canavarYönü = transform.right; // "right" yatay ekseni temsil eder, yani canavarýn döndüðü yönü alýr.
    }
}
