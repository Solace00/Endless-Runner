using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spawnPlatform : MonoBehaviour
{
    //Spawning Obstacles
    public GameObject[] chunk;
    private int numberOfChunks;
    public float speed = 1;
    private float spawnTime = 0;
    public float maxSpeed = 20;
    private obstacleScript summonScript;

    //Scoring
    public Text scoreDisplay;
    public float score;
    public float scoreMultiplyer;

    //End and Reset Game
    private bool isPlaying = true;
    public GameObject Player;
    public GameObject playAgain;
    public GameObject endScreen;

    //Spawn Powerups
    public GameObject[] pUps;
    private int[] pUpPos = { -3, 0, 3 };
    private int numberOfPUps;

    // Start is called before the first frame update
    void Start()
    {
        numberOfChunks = chunk.Length;
        numberOfPUps = pUps.Length;
        Player = GameObject.FindGameObjectWithTag("Player");
        scoreMultiplyer = 0.0017f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying == true)
        {
            Play();
        }
    }

    public void EndGame()
    {
        isPlaying = false;
        Player.SetActive(false);
        playAgain.SetActive(true);
        endScreen.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    void Play()
    {
        //Scoring
        score += Time.timeSinceLevelLoad * speed * scoreMultiplyer;
        scoreDisplay.text = score.ToString("0");

        //Spawn New Obstacles
        if (spawnTime < Time.time)
        {
            for (int i = 0; i < Random.Range(1, 2); i++)
            {
                GameObject obstacle = Instantiate(chunk[Random.Range(0, numberOfChunks)], gameObject.transform.position + new Vector3(pUpPos[Random.Range(0, 3)], 0, -5), Quaternion.identity);
                summonScript = obstacle.GetComponent<obstacleScript>();
                summonScript.speed = speed;
            }

            int x = Random.Range(1, 100);
            if (x < 10)
            {
                GameObject pUp = Instantiate(pUps[Random.Range(0, numberOfPUps)], gameObject.transform.position + new Vector3(pUpPos[Random.Range(0, 3)], 0.6f, 0), Quaternion.identity);
            }

            if (speed < maxSpeed)
                speed += 0.2f;
            spawnTime = Time.time + 2 - speed * 0.1f;
        }
    }
}
