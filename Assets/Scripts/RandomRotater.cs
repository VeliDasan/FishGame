using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotater : MonoBehaviour
{
    Rigidbody2D physic;

    public float maxAngularSpeed = 100f; // Adjust the maximum angular speed as needed.

    void Start()
    {
        physic = GetComponent<Rigidbody2D>();
        physic.angularVelocity = Random.Range(-maxAngularSpeed, maxAngularSpeed);
    }
}
