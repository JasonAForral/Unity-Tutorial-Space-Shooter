using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour 
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GameObject scorePanel;
    public GameObject restartPanel;
    public GameObject gameOverPanel;
    
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    
    private bool gameOver;
    private bool restart;
    private int score;


    void Start()
    {
        gameOver = false;
        restart = false;
        //restartText.text = "";
        //gameOverText.text = "";
        restartPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }

    void Update()
    {
        if (restart)
        { 
            if (Input.GetButton("Submit"))
            {
                Application.LoadLevel (Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartPanel.SetActive(true);
                restartText.text = "Press [Submit] to Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "1UP: " + score;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
