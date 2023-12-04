using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi2 : MonoBehaviour
{
    public float speed;


    void Start()
    {

    }


    void Update()
    {
        gameObject.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }


}