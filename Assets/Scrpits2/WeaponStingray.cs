using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStingray : MonoBehaviour
{
    [SerializeField]
    private List<Creture> Allcretures;
    private List<LineController> allLÝnes;
    [SerializeField]
    private LineController linePrefab;
    private bool weaponIsOn;
    [SerializeField]
    private Transform origin;

    


    private void Awake()
    {
        allLÝnes = new List<LineController>();
        for (int i = 0; i < Allcretures.Count; i++)
        {
            LineController newLine = Instantiate(linePrefab);
            allLÝnes.Add(newLine);

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

        foreach (var line in allLÝnes)
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
