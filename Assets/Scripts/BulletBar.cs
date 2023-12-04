using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBar : MonoBehaviour
{
    [SerializeField] private GameObject[] bullets;
    private int bullethakký;
    private bool isDead;

    private int initialBulletCount; // Baþlangýçta sahip olunan mermi sayýsýný tutmak için deðiþken
    void Start()
    {
        initialBulletCount = bullets.Length; // Baþlangýçta sahip olunan mermi sayýsýný tut
        bullethakký = initialBulletCount;
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
        bullethakký -= damageamount;
        UpdateBulletUI();
        if (bullethakký <= 0)
        {
            isDead = true;
            
        }

    }

    public void ResetBulletCount()
    {
        // Mermi sayýsýný direkt baþlangýç deðerine geri döndür
        bullethakký = initialBulletCount;
        UpdateBulletUI();
        isDead = false; // Oyuncu durumunu sýfýrla
    }
   
    private void UpdateBulletUI()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (i < bullethakký)
            {
                bullets[i].SetActive(true); // canlarý aktifleþtir
            }
            else
            {
                bullets[i].SetActive(false); // canlarý devre dýþý býrak
            }
        }
    }
    public int GetCurrentBullet()
    {
        return bullethakký;
    }

}
