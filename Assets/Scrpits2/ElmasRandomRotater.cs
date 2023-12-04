using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElmasRandomRotater : MonoBehaviour
{
    Rigidbody2D physic;
    public float maxAngularSpeed = 100;

    void Start()
    {
        physic = GetComponent<Rigidbody2D>();
        physic.angularVelocity = Random.Range(-maxAngularSpeed, maxAngularSpeed);
        
    }


}
