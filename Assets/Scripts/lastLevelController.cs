using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lastLevelController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject statusPanel;
    public GameObject timer;

    private float elapsedTime;

    public void Start()
    {
        Time.timeScale = 1;
        elapsedTime = Time.deltaTime;
        gameOverPanel.SetActive(false);
        statusPanel.SetActive(true);
        timer.SetActive(false);
        EnemyAI.playerWin = false;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (detectCollision.hasCollision)
        {
            endGame(false);
        }
        else if (EnemyAI.playerWin == true)
        {
            endGame(true);
        }
    }

    private void endGame(bool playerWin)
    {
        displayElapsedTime();
        Time.timeScale = 0;
        Destroy(GameObject.Find("Spawner"));
        gameOverPanel.SetActive(true);
        if (playerWin)
        {
            GameObject.Find("GameOverText").GetComponent<Text>().text = "You win!";
        }

        EnemyAI.playerWin = false;
    }

    public void RestartGame()
    {
        gameOverPanel.SetActive(false);
        // Restart current level
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Restart from level 1
        SceneManager.LoadScene(1);
    }
    public void LoadMainMenu()
    {
        statusPanel.SetActive(false);

        SceneManager.LoadScene("Start");
    }

    private void displayElapsedTime()
    {
        string minutes = Mathf.Floor(elapsedTime / 60).ToString("00");
        string seconds = (elapsedTime % 60).ToString("00");
        timer.SetActive(true);
        GameObject.Find("TimerText").GetComponent<Text>().text = "Elapsed time: " + minutes + ":" + seconds;
    }
}
