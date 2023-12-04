using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{

    public float playerSpeed = 0.25f;
    [SerializeField] float slowSpeed = 0.20f;
    [SerializeField] float boostSpeed = 0.35f;

    private float lastXPosition;
    Rigidbody2D physic;

    public GameObject bullet;
    public Transform ateþnoktasý;
    public float ateþHýzý;
    public float sayac;

    public float xMin, xMax, yMin, yMax;

    public GameObject gameController;
    public GameObject gameController2;
    GameController2 GameController2;


    public bool Shielded;
    [SerializeField]
    public GameObject shield;
    private ShieldBar shieldBar;
    private int shieldUsageCount = 0;

    [SerializeField] GameObject coinNumPrefab;
    [SerializeField] GameObject coinNumPrefab1;

    private WeaponStingray weaponStingray;
    private float originalPlayerSpeed;






    void CheckShield()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !Shielded && shieldUsageCount < 3)
        {
            if (shieldBar != null)
            {
                shieldBar.TakeDamage(1);
            }
            shield.SetActive(true);
            Shielded = true;

            Invoke("NoShield", 3f);
            shieldUsageCount++;
        }
    }
    void NoShield()
    {
        shield.SetActive(false);
        Shielded = false;
    }



    void Start()
    {
        Shielded = false;
        physic = GetComponent<Rigidbody2D>();
        lastXPosition = transform.position.x;
        shieldBar = GetComponent<ShieldBar>();
        GameController2 = FindObjectOfType<GameController2>();

        gameController2 = GameController2.gameObject;

        weaponStingray = FindObjectOfType<WeaponStingray>();
        originalPlayerSpeed = playerSpeed;
    }



    void Update()
    {
        CheckShield();


        sayac -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {

            shoot();

        };
        float moveX = Input.GetAxis("Horizontal") * playerSpeed;
        float moveY = Input.GetAxis("Vertical") * playerSpeed;

        // Oyuncu hareketini hesaplayýn ve yeni pozisyonu alýn
        Vector2 newPosition = physic.position + new Vector2(moveX, moveY);

        // Yeni pozisyonu ekrana sýnýrla
        float clampedX = Mathf.Clamp(newPosition.x, xMin, xMax);
        float clampedY = Mathf.Clamp(newPosition.y, yMin, yMax);
        newPosition = new Vector2(clampedX, clampedY);

        // Yeni pozisyonu atayýn
        physic.MovePosition(newPosition);

        // Oyuncu dönüþünü kontrol edin
        if (moveX > 0)
        {
            transform.localScale = new Vector2(0.19f, 0.19f);
            // isLookingRight = false;

        }
        else if (moveX < 0)
        {
            transform.localScale = new Vector2(-0.19f, 0.19f);
        }

        lastXPosition = newPosition.x;
    }
    private void shoot()
    {
        if (bullet != null)
        {
            GameObject mermi = Instantiate(bullet, ateþnoktasý.position, Quaternion.identity);
            Rigidbody2D mermiRigidbody = mermi.GetComponent<Rigidbody2D>();
            mermiRigidbody.velocity = new Vector2(ateþHýzý * Time.deltaTime, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Elmas")
        {
            Vector3 collisionPosition = collision.transform.position;
            int scoreToAdd = 10;

            gameController.GetComponent<GameController2>().IncereaseScore(collisionPosition, scoreToAdd);
            Destroy(collision.gameObject);
            Destroy(Instantiate(coinNumPrefab, collision.transform.position, Quaternion.identity), 1f);
        }

        if (collision.gameObject.tag == "Pearl")
        {
            Vector3 collisionPosition1 = collision.transform.position;
            int scoreToAdd1 = 1;
            gameController2.GetComponent<GameController2>().PearlScore(collisionPosition1, scoreToAdd1);
            Destroy(collision.gameObject);
            Destroy(Instantiate(coinNumPrefab1, collision.transform.position, Quaternion.identity), 1f);
        }

        playerSpeed = slowSpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boost")
        {
            playerSpeed = boostSpeed;
        }

        if (collision.gameObject.tag == "Stringray")
        {
            playerSpeed =slowSpeed;

            if (weaponStingray != null && weaponStingray.IsWeaponOn())
            {
                playerSpeed = slowSpeed; 
            }
        }



    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stringray")
        {
            playerSpeed = originalPlayerSpeed; 
        }
    }

}