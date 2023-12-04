using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;
    private int lifeAmount;
    private bool isDead;

    private int initialHeartCount;

    private void Start()
    {
        lifeAmount = hearts.Length;
        initialHeartCount = hearts.Length; // Baþlangýçta sahip olunan can sayýsýný tut
        lifeAmount = initialHeartCount;
        UpdateHeartsUI();
    }

    private void Update()
    {
        if (isDead)
        {
      
         }
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead) return; 

        lifeAmount -= damageAmount;
        UpdateHeartsUI();

        if (lifeAmount <= 0)
        {
            isDead = true;
           
        }
    }

    public void ResetHeartCount()
    {
        // Mermi sayýsýný direkt baþlangýç deðerine geri döndür
        lifeAmount = initialHeartCount;
        UpdateHeartsUI();
        isDead = false; // Oyuncu durumunu sýfýrla
    }

    private void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lifeAmount)
            {
                hearts[i].SetActive(true); // canlarý aktifleþtir
            }
            else
            {
                hearts[i].SetActive(false); // canlarý devre dýþý býrak
            }
        }
    }

    public int GetCurrentHealth()
    {
        return lifeAmount;
    }

    
}



