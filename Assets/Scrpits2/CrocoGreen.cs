using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocoGreen : MonoBehaviour
{
    private float TimeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectTile;

    private void Start()
    {
        TimeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {
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