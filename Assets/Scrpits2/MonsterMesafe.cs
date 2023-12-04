using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMesafe : MonoBehaviour
{
    public Transform nesne1;
    public Transform nesne2;
    public Transform nesne3;
    public float minimumMesafe = 5f;

    void Update()
    {
        // 1. ve 2. nesneler arasýndaki uzaklýðý hesapla
        float uzaklik12 = Vector3.Distance(nesne1.position, nesne2.position);
        if (uzaklik12 < minimumMesafe)
        {
            Vector3 yeniPozisyon1 = nesne1.position + (nesne2.position - nesne1.position).normalized * minimumMesafe;
            nesne1.position = yeniPozisyon1;

            Vector3 yeniPozisyon2 = nesne2.position - (nesne2.position - nesne1.position).normalized * minimumMesafe;
            nesne2.position = yeniPozisyon2;
        }

        // 1. ve 3. nesneler arasýndaki uzaklýðý hesapla
        float uzaklik13 = Vector3.Distance(nesne1.position, nesne3.position);
        if (uzaklik13 < minimumMesafe)
        {
            Vector3 yeniPozisyon1 = nesne1.position + (nesne3.position - nesne1.position).normalized * minimumMesafe;
            nesne1.position = yeniPozisyon1;

            Vector3 yeniPozisyon3 = nesne3.position - (nesne3.position - nesne1.position).normalized * minimumMesafe;
            nesne3.position = yeniPozisyon3;
        }

        // 2. ve 3. nesneler arasýndaki uzaklýðý hesapla
        float uzaklik23 = Vector3.Distance(nesne2.position, nesne3.position);
        if (uzaklik23 < minimumMesafe)
        {
            Vector3 yeniPozisyon2 = nesne2.position + (nesne3.position - nesne2.position).normalized * minimumMesafe;
            nesne2.position = yeniPozisyon2;

            Vector3 yeniPozisyon3 = nesne3.position - (nesne3.position - nesne2.position).normalized * minimumMesafe;
            nesne3.position = yeniPozisyon3;
        }
    }
}
