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
        initialHeartCount = hearts.Length; // Ba�lang��ta sahip olunan can say�s�n� tut
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
        // Mermi say�s�n� direkt ba�lang�� de�erine geri d�nd�r
        lifeAmount = initialHeartCount;
        UpdateHeartsUI();
        isDead = false; // Oyuncu durumunu s�f�rla
    }

    private void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lifeAmount)
            {
                hearts[i].SetActive(true); // canlar� aktifle�tir
            }
            else
            {
                hearts[i].SetActive(false); // canlar� devre d��� b�rak
            }
        }
    }

    public int GetCurrentHealth()
    {
        return lifeAmount;
    }

    
}



