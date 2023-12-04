using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPortal : MonoBehaviour
{
    public GameObject uiPanel; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2"))
        {
            
            uiPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2"))
        {
            
            uiPanel.SetActive(false);
        }
    }
}

