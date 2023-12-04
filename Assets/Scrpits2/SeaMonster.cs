using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMonster : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float TimeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectTile;
    private Transform player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player2").transform;
        TimeBtwShots = startTimeBtwShots;
        
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
           
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

          
            if (player.position.x < transform.position.x)
            {
                
                transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
            }
            else
            {
                
                transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            // Hiçbir þey yapmayýn, canavarý durma mesafesinde tutun
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
           
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);

           
            if (player.position.x < transform.position.x)
            {
               
                transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
            }
            else
            {
                
                transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
        }

        if (TimeBtwShots <= 0)
        {
            Instantiate(projectTile, transform.position, Quaternion.identity);
            TimeBtwShots = startTimeBtwShots;
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }
    }

}
