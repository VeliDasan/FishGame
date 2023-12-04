using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Prison : MonoBehaviour
{
    [SerializeField]
    private string colliderScript;
    [SerializeField]
    private UnityEvent collisionEntered;
    [SerializeField]
    private UnityEvent collisionExit;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent(colliderScript))
        {
            collisionEntered?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent(colliderScript))
        {
            collisionExit?.Invoke();
        }
    }
}
