using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RehineBalıkTakip : MonoBehaviour
{
    private Transform hedef;
    public float hız;
    public float durmaMesafesi;

    private bool takipEdiyor = false;
    private bool temasEdildi = false;
    private float temasBeklemeSuresi = 5f;
    private float temasZamanlayıcı;

    void Start()
    {
        hedef = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>();
    }

    void HostogeFollow()
    {
        if (takipEdiyor)
        {
            if (Vector2.Distance(transform.position, hedef.position) > durmaMesafesi)
            {
                transform.position = Vector2.MoveTowards(transform.position, hedef.position, hız * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, hedef.position) < durmaMesafesi)
            {
                transform.position = Vector2.MoveTowards(transform.position, hedef.position, -hız * Time.deltaTime);

                if (hedef.position.x < transform.position.x)
                {
                    transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
                }
                else
                {
                    transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2"))
        {
            temasEdildi = true;
            temasZamanlayıcı = Time.time + temasBeklemeSuresi;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2") && Input.GetKey("e") && (Time.time > temasZamanlayıcı))
        {
            takipEdiyor = true;
        }
    }

    void Update()
    {
        HostogeFollow();
    }
}
