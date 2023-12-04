using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creture : MonoBehaviour
{
    private bool isPlayerInside = false;
    private WeaponStingray weaponStingray;

    private void Start()
    {
        weaponStingray = FindObjectOfType<WeaponStingray>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Stringray"))
        {
            isPlayerInside = true;
            if (weaponStingray != null)
            {
                weaponStingray.ToggleWeapon(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Stringray"))
        {
            isPlayerInside = false;
            if (weaponStingray != null)
            {
                weaponStingray.ToggleWeapon(false);
            }
        }
    }
}
