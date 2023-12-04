using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    private Vector2 direciton;
    private Vector2 target;
       

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player2");
      

        if(player != null)
        {
            target = player.transform.position;
            direciton = target - (Vector2)transform.position;
            transform.right = -direciton;

        }
        
        
    }
}
