using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollesionDetector : MonoBehaviour
{
    [SerializeField]
    private string colliderScript;
    [SerializeField]
    private UnityEvent collisionEntered;
    [SerializeField]
    private UnityEvent collisionExit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent(colliderScript))
        {
            collisionEntered?.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent(colliderScript))
        {
            collisionExit?.Invoke();
        }
    }
}
