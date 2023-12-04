using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator enemyAnimator;
    public float moveInput;
    public float animationThreshold = 0.1f; // Hýz eþiði - bu deðeri istediðiniz gibi deðiþtirebilirsiniz.
    public string animationParameter = "Speed"; // Animator'da "Speed" parametresinin adýný alýr.

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Burada moveInput deðerini güncelleyebilirsiniz, örneðin klavyeden veya baþka bir kaynaktan giriþ alarak.
    }

    private void FixedUpdate()
    {
        enemyAnimator.SetFloat(animationParameter, Mathf.Abs(moveInput));

        // Eðer hareket hýzý animationThreshold'dan büyükse, diðer animasyonu oynat
        if (Mathf.Abs(moveInput) > animationThreshold)
        {
            // Diðer animasyonun oynatýlmasý için yapýlacak iþlemleri burada ekleyin.
            // Örneðin:
             enemyAnimator.SetBool("playerhurt", true);
        }
        else
        {
            // Diðer animasyonu durdurmak isterseniz:
             enemyAnimator.SetBool("playerýdle", false);
        }
    }
}
