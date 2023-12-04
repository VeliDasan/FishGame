using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBulletController : MonoBehaviour
{
    public GameObject bulletPrefab; // Mermi prefab'�
    public Transform ate�Noktas�; // Ate� noktas� transformu
    public float ate�H�z�; // Ate� h�z�

    private Vector2 canavarY�n�; // Canavar�n hareket y�n�n� saklayaca��m�z de�i�ken

    void Start()
    {
        // Saniyede bir defa ate� etmeyi ba�lat
        InvokeRepeating("Ate�Et", 0f, 1f);
    }

    private void Ate�Et()
    {
        // Mermi prefab'�n� ate� noktas�nda olu�tur
        if (bulletPrefab != null && ate�Noktas� != null)
        {
            GameObject mermi = Instantiate(bulletPrefab, ate�Noktas�.position, Quaternion.identity);
            Rigidbody2D mermiRigidbody = mermi.GetComponent<Rigidbody2D>();

            // Canavar�n d�nd��� y�ne g�re mermiye ate� h�z�n� ver
            mermiRigidbody.velocity = canavarY�n� * ate�H�z�;
        }
    }

    void Update()
    {
        // Canavar�n hareket y�n�n� g�ncelle
        canavarY�n� = transform.right; // "right" yatay ekseni temsil eder, yani canavar�n d�nd��� y�n� al�r.
    }
}
