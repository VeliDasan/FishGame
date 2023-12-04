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
        initialHeartCount = shields.Length; // Baþlangýçta sahip olunan kalkan sayýsýný tut
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
        // kalkan sayýsýný direkt baþlangýç deðerine geri döndür
        lifeAmount = initialHeartCount;
        UpdateHeartsUI();
        isDead = false; // Oyuncu durumunu sýfýrla
    }

    private void UpdateHeartsUI()
    {
        for (int i = 0; i <shields.Length; i++)
        {
            if (i < lifeAmount)
            {
                shields[i].SetActive(true); // kalkanlarý aktifleþtir
            }
            else
            {
                shields[i].SetActive(false); // kalkanlarý devre dýþý býrak
            }
        }
    }

    public int GetCurrentHealth()
    {
        return lifeAmount;
    }
}
