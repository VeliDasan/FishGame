using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class GameController2 : MonoBehaviour
{
    public GameObject extraSpeed;
    public int spawnSpeed;
    public float spawnWaitSpeed;
    public float startSpawnSpeed;
    public float waveWaitSpeed;

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

    public GameObject extraElmas;
    public int spawnElmas;
    public float spawnWaitElmas;
    public float startSpawnElmas;
    public float waveWaitElmas;
    private int score;
    public Text scoreText;

    public GameObject pearl;
    private int scorePearl;
    private int pearlScore = 1;
    public Text pearlText;

    [SerializeField] GameObject animatedCoinPrefab;
    [SerializeField] Transform target; 
    [SerializeField] int maxCoins;
    Queue<GameObject> coinsQueue = new Queue<GameObject>();
    [SerializeField] [Range(0.5f, 0.9f)] float minAnimDuration;
    [SerializeField] [Range(0.5f, 2f)] float maxAnimDuration;
    [SerializeField] Ease easeType;
    [SerializeField] float spread;
    Vector3 targetPosetion;

    [SerializeField] GameObject animatedCoinPrefab1;
    [SerializeField] Transform target1;
    [SerializeField] int maxCoins1;
    Queue<GameObject> coinsQueue1 = new Queue<GameObject>();
    [SerializeField] [Range(0.5f, 0.9f)] float minAnimDuration1;
    [SerializeField] [Range(0.5f, 2f)] float maxAnimDuration1;
    [SerializeField] Ease easeType1;
    [SerializeField] float spread1;
    Vector3 targetPosetion1;

    public GameObject gameOverUI;

    public void GameOver()
    {
        gameOverUI.SetActive(true);

    }

    public void restrat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void Awake()
    {
        targetPosetion1 = target1.position;
        targetPosetion = target.position;

        PrepareCoins();
        PrepareCoins1();
    }

    void PrepareCoins()
    {
        GameObject coin;
        for(int i = 0; i < maxCoins; i++)
        {
            coin = Instantiate(animatedCoinPrefab);
            coin.transform.parent = transform;
            coin.SetActive(false);
            coinsQueue.Enqueue(coin);

        }

    }
    void PrepareCoins1()
    {
        GameObject coin;
        for (int i = 0; i < maxCoins1; i++)
        {
            coin = Instantiate(animatedCoinPrefab1);
            coin.transform.parent = transform;
            coin.SetActive(false);
            coinsQueue1.Enqueue(coin);

        }

    }
    void Animate(Vector3 collectedCoinPosetion, int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            if (coinsQueue.Count > 0)
            {
                GameObject coin = coinsQueue.Dequeue();
                coin.SetActive(true);
                coin.transform.position = collectedCoinPosetion+new Vector3(Random.Range(-spread,spread),0f,0f);


                float duration = Random.Range(minAnimDuration, maxAnimDuration);
                coin.transform.DOMove(targetPosetion, duration)
                .SetEase(easeType)
                .OnComplete(() =>
                {
                    coin.SetActive(false);
                    coinsQueue.Enqueue(coin);
                    score++;
                });
            }
        }
    }
    void Animate1(Vector3 collectedCoinPosetion1, int amount1)
    {
        for (int i = 0; i < amount1; i++)
        {
            if (coinsQueue1.Count > 0)
            {
                GameObject coin = coinsQueue1.Dequeue();
                coin.SetActive(true);
                coin.transform.position = collectedCoinPosetion1 + new Vector3(Random.Range(-spread1, spread1), 0f, 0f);


                float duration = Random.Range(minAnimDuration1, maxAnimDuration1);
                coin.transform.DOMove(targetPosetion1, duration)
                .SetEase(easeType1)
                .OnComplete(() =>
                {
                    coin.SetActive(false);
                    coinsQueue1.Enqueue(coin);
                    scorePearl++;
                });
            }
        }
    }


    public void PearlScore(Vector3 collectedCoinPosetion1, int amount1)
    {

        Animate1(collectedCoinPosetion1, amount1);
        pearlText.text = " " + scorePearl;
    }


    

    IEnumerator SpawnValuesElmas()
    {
        yield return new WaitForSeconds(startSpawnElmas);
        while (true)
        {
            for (int i = 0; i < spawnElmas; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-50, 150), Random.Range(-90, 4), 0);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(extraElmas, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWaitElmas);
            }
            yield return new WaitForSeconds(waveWaitElmas);
        }
    }
    public void IncereaseScore(Vector3 collectedCoinPosetion, int amount)
    {
        Animate(collectedCoinPosetion,amount);
       scoreText.text = " " + score;
       
    }

    void Start()
    {

        score = 0;
        StartCoroutine(SpawnValuesElmas());
        StartCoroutine(SpawnValuesSpeed());
        StartCoroutine(FishValues());
        StartCoroutine(Fish2Values());
        StartCoroutine(Fish3Values());
    }

    
    void Update()
    {
        
    }
    IEnumerator SpawnValuesSpeed()
    {
        yield return new WaitForSeconds(startSpawnSpeed);
        while (true)
        {
            for (int i = 0; i < spawnSpeed; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-50, 150), Random.Range(-90, 4), 0);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(extraSpeed, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWaitSpeed);
            }
            yield return new WaitForSeconds(waveWaitSpeed);
        }
    }
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
        while (true)
        {
            for (int i = 0; i < fishCount; i++)
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
}
