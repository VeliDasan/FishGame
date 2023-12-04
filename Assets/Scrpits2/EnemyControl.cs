using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator enemyAnimator;
    public float moveInput;
    public float animationThreshold = 0.1f; // H�z e�i�i - bu de�eri istedi�iniz gibi de�i�tirebilirsiniz.
    public string animationParameter = "Speed"; // Animator'da "Speed" parametresinin ad�n� al�r.

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Burada moveInput de�erini g�ncelleyebilirsiniz, �rne�in klavyeden veya ba�ka bir kaynaktan giri� alarak.
    }

    private void FixedUpdate()
    {
        enemyAnimator.SetFloat(animationParameter, Mathf.Abs(moveInput));

        // E�er hareket h�z� animationThreshold'dan b�y�kse, di�er animasyonu oynat
        if (Mathf.Abs(moveInput) > animationThreshold)
        {
            // Di�er animasyonun oynat�lmas� i�in yap�lacak i�lemleri burada ekleyin.
            // �rne�in:
             enemyAnimator.SetBool("playerhurt", true);
        }
        else
        {
            // Di�er animasyonu durdurmak isterseniz:
             enemyAnimator.SetBool("player�dle", false);
        }
    }
}
