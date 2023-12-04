using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBar : MonoBehaviour
{
    [SerializeField] private GameObject[] bullets;
    private int bullethakk�;
    private bool isDead;

    private int initialBulletCount; // Ba�lang��ta sahip olunan mermi say�s�n� tutmak i�in de�i�ken
    void Start()
    {
        initialBulletCount = bullets.Length; // Ba�lang��ta sahip olunan mermi say�s�n� tut
        bullethakk� = initialBulletCount;
        UpdateBulletUI();


    }
   

    void Update()
    {
        if (isDead)
        {

        }
    }

    public void TakeDamage(int damageamount)
    {
        if (isDead) return;
        bullethakk� -= damageamount;
        UpdateBulletUI();
        if (bullethakk� <= 0)
        {
            isDead = true;
            
        }

    }

    public void ResetBulletCount()
    {
        // Mermi say�s�n� direkt ba�lang�� de�erine geri d�nd�r
        bullethakk� = initialBulletCount;
        UpdateBulletUI();
        isDead = false; // Oyuncu durumunu s�f�rla
    }
   
    private void UpdateBulletUI()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (i < bullethakk�)
            {
                bullets[i].SetActive(true); // canlar� aktifle�tir
            }
            else
            {
                bullets[i].SetActive(false); // canlar� devre d��� b�rak
            }
        }
    }
    public int GetCurrentBullet()
    {
        return bullethakk�;
    }

}
