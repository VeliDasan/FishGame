using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBar : MonoBehaviour
{
    [SerializeField] private GameObject[] shields;
    private int lifeAmount;
    private bool isDead;

    private int initialHeartCount;

    private void Start()
    {
        lifeAmount = shields.Length;
        initialHeartCount = shields.Length; // Ba�lang��ta sahip olunan kalkan say�s�n� tut
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
        // kalkan say�s�n� direkt ba�lang�� de�erine geri d�nd�r
        lifeAmount = initialHeartCount;
        UpdateHeartsUI();
        isDead = false; // Oyuncu durumunu s�f�rla
    }

    private void UpdateHeartsUI()
    {
        for (int i = 0; i <shields.Length; i++)
        {
            if (i < lifeAmount)
            {
                shields[i].SetActive(true); // kalkanlar� aktifle�tir
            }
            else
            {
                shields[i].SetActive(false); // kalkanlar� devre d��� b�rak
            }
        }
    }

    public int GetCurrentHealth()
    {
        return lifeAmount;
    }
}
