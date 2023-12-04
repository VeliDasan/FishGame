using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float playerSpeed = 0.25f;
    private float lastXPosition;
    public GameObject gameController;



   // public Transform bulletSpawnPos;
    //public GameObject sa�Mermi, solMermi;
    //public bool isLookingRight;

    public GameObject bullet;
    public Transform ate�noktas�;
    public float ate�H�z�;
    public float sayac;

    Rigidbody2D physic;

    public float xMin, xMax, yMin, yMax;
    public BulletBar bulletBar;

    public HealthBar healthBar;

    
    void Start()
    {
        
        physic = GetComponent<Rigidbody2D>();
        lastXPosition = transform.position.x;
    }
    void Update()
    {
        sayac -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0)){
            
            if (sayac <= 0 && bulletBar.GetCurrentBullet()>0 )
            {
                shoot();
                sayac = 0.25f;
                bulletBar.TakeDamage(1);
            }

        };
       
        float moveX = Input.GetAxis("Horizontal") * playerSpeed;
        float moveY = Input.GetAxis("Vertical") * playerSpeed;

        // Oyuncu hareketini hesaplay�n ve yeni pozisyonu al�n
        Vector2 newPosition = physic.position + new Vector2(moveX, moveY);

        // Yeni pozisyonu ekrana s�n�rla
        float clampedX = Mathf.Clamp(newPosition.x, xMin, xMax);
        float clampedY = Mathf.Clamp(newPosition.y, yMin, yMax);
        newPosition = new Vector2(clampedX, clampedY);

        // Yeni pozisyonu atay�n
        physic.MovePosition(newPosition);

        // Oyuncu d�n���n� kontrol edin
        if (moveX>0)
        {
            transform.localScale = new Vector2(1, 1);
           // isLookingRight = false;
            
        }
        else if (moveX < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        lastXPosition = newPosition.x;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "food" )
        {
            gameController.GetComponent<GameController>().SendMessage("IncereaseScore");
            Destroy(collision.gameObject);
           
            bulletBar.TakeDamage(-1); // Yem yedikten sonra mermi say�s�n� art�r
            bulletBar.ResetBulletCount(); // Mermi say�s�n� ba�lang�� de�erine hemen geri d�nd�r
            // shoot(); // Mermiyi hemen olu�tur ve at

            
        }
        else if
            (collision.gameObject.tag == "extraheart")
        {
            Destroy(collision.gameObject);
                healthBar.TakeDamage(-1);
                healthBar.ResetHeartCount();
            }

        
       
    }
       private void shoot()
    {
        if (bullet != null)
        {
            GameObject mermi = Instantiate(bullet, ate�noktas�.position, Quaternion.identity);
            Rigidbody2D mermiRigidbody = mermi.GetComponent<Rigidbody2D>();
            mermiRigidbody.velocity = new Vector2(ate�H�z� * Time.deltaTime, 0);
        }
    }

}
