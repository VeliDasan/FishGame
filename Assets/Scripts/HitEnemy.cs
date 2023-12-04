using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitEnemy : MonoBehaviour
{
    public int hitEnemy;
    private int enemyPoints = 1;
    public Text enemyText;
    void Start()
    {
        hitEnemy = 0;
    }




    public void HitEnemyScore()
    {
        hitEnemy += enemyPoints;
        enemyText.text = "Vurulan Düþman:" + hitEnemy;
    }
}
