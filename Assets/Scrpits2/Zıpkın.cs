using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zıpkın : MonoBehaviour
{
    private float TimeBtwShots;
    public float startTimeBtwShots;

    public GameObject ok;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player2").transform;
        TimeBtwShots = startTimeBtwShots;

    }

    
    void Update()
    {
        if (TimeBtwShots <= 0)
        {
            Instantiate(ok, transform.position, Quaternion.identity);
            TimeBtwShots = startTimeBtwShots;
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }
    }
}
