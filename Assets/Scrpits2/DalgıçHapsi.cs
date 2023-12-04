using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalgıçHapsi : MonoBehaviour
{
    public float xMin, xMax, yMin, yMax;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Dalgıç")
        {
            // Oyuncuyu sınırlı alanın içinde tutmak için pozisyonunu sınırla
            Vector3 newPosition = collision.transform.position;
            newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
            newPosition.y = Mathf.Clamp(newPosition.y, yMin, yMax);
            collision.transform.position = newPosition;
        }
    }

}
