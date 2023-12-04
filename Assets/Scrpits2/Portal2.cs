using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2 : MonoBehaviour
{
    public float xMin, xMax, yMin, yMax;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player2")
        {
            // Oyuncuyu s�n�rl� alan�n i�inde tutmak i�in pozisyonunu s�n�rla
            Vector3 newPosition = collision.transform.position;
            newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
            newPosition.y = Mathf.Clamp(newPosition.y, yMin, yMax);
            collision.transform.position = newPosition;
        }
    }
}
