using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int score;
    private int foodPoints = 10;
    public Text scoreText;

    public GameObject fishFood;
    private int foodTimer = 0;
    private int foodTimerGoal = 30;
    private int foodTimerRandom=60;


    public GameObject tehlike;
    public int spawnCount;
    public float spawnWait;
    public float startSpawn;
    public float waveWait;

    public GameObject extraHearts;
    public int spawnHeart;
    public float spawnWaitHeart;
    public float startSpawnHeart;
    public float waveWaitHeart;

    public GameObject fish1;
    public int fishCount;
    public float fishWait;
    public float fishStart;

    public GameObject fish2;
    public int fish2Count;
    public float fish2Wait;
    public float fish2Start;

    public GameObject fish3;
    public int fish3Count;
    public float fish3Wait;
    public float fish3Start;

    public float zaman=30f;
    public Text zamanText;

    private bool isGameRunning = true;

   

    IEnumerator Fish3Values()
    {
        yield return new WaitForSeconds(fish3Start);
        while (true)
        {
            for (int i = 0; i < fish3Count; i++)
            {
                Vector3 fishPosetion = new Vector3(-50, Random.Range(-90, 4), 0);
                Quaternion fishRotation = Quaternion.identity;

                Instantiate(fish3, fishPosetion, fishRotation);
                yield return new WaitForSeconds(fish3Wait);
            }
        }


    }


    IEnumerator FishValues()
    {
        yield return new WaitForSeconds(fishStart);
        while(true)
        {
            for(int i=0; i < fishCount; i++)
            {
                Vector3 fishPosetion = new Vector3(150, Random.Range(-90, 4), 0);
                Quaternion fishRotation = Quaternion.identity;

                Instantiate(fish1, fishPosetion, fishRotation);
                yield return new WaitForSeconds(fishWait);
            }
        }

        
    }
    IEnumerator Fish2Values()
    {
        yield return new WaitForSeconds(fish2Start);
        while (true)
        {
            for (int i = 0; i < fish2Count; i++)
            {
                Vector3 fishPosetion = new Vector3(150, Random.Range(-90, 4), 0);
                Quaternion fishRotation = Quaternion.identity;

                Instantiate(fish2, fishPosetion, fishRotation);
                yield return new WaitForSeconds(fish2Wait);
            }
        }


    }




    IEnumerator SpawnValues()
    {
        yield return new WaitForSeconds(startSpawn);
        while (true)
        {
            
            for (int i = 0; i < spawnCount; i++)
            {

                Vector3 spawnPosition = new Vector3(150, Random.Range(-90, 4), 0);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(tehlike, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
       }

    IEnumerator SpawnValuesHeart()
    {
        yield return new WaitForSeconds(startSpawnHeart);
        while (true)
        {
            for (int i = 0; i < spawnHeart; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-50, 150), Random.Range(-90, 4), 0);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(extraHearts, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWaitHeart);
            }
            yield return new WaitForSeconds(waveWaitHeart);
        }
    }
    void Start()
    {
        
        score = 0;
        foodTimerRandom = Random.Range(0, 101);
        StartCoroutine(SpawnValues());
        StartCoroutine(FishValues());
        StartCoroutine(Fish2Values());
        StartCoroutine(Fish3Values());
        StartCoroutine(SpawnValuesHeart());

    }
    private void Update()
    {
        if (isGameRunning)
        {
            zaman -= Time.deltaTime;
            zamanText.text = "Zaman: " + (int)zaman;

            if (zaman <= 0f)
            {
                
                isGameRunning = false;
                StopAllCoroutines();

               
                GameOver();
            }
        }
    }

   

    void GameOver()
    {
        
    }



void FixedUpdate()
    {
        if (foodTimer > foodTimerGoal + foodTimerRandom)
        {
            Instantiate(fishFood, new Vector2(Random.Range(-30f, 65f), 6f), Quaternion.identity);

            foodTimer = 0;
            foodTimerRandom = Random.Range(0, 101);
        }
        foodTimer++;
    }

    public void IncereaseScore()
    {
        score += foodPoints;
        scoreText.text = "Score: " + score;
    }

    
}
