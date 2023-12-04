using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStingray : MonoBehaviour
{
    [SerializeField]
    private List<Creture> Allcretures;
    private List<LineController> allL�nes;
    [SerializeField]
    private LineController linePrefab;
    private bool weaponIsOn;
    [SerializeField]
    private Transform origin;

    


    private void Awake()
    {
        allL�nes = new List<LineController>();
        for (int i = 0; i < Allcretures.Count; i++)
        {
            LineController newLine = Instantiate(linePrefab);
            allL�nes.Add(newLine);

            newLine.AssingTarget(origin.position, Allcretures[i].transform);
            newLine.gameObject.SetActive(false);
        }
       

        weaponIsOn = false;
    }

    public void ToggleWeapon(bool activate)
    {
        if (weaponIsOn == activate)
        {
            return; 
        }

        foreach (var line in allL�nes)
        {
            line.gameObject.SetActive(activate);
        }

        weaponIsOn = activate;
    }

    public bool IsWeaponOn()
    {
        return weaponIsOn;
    }
}
