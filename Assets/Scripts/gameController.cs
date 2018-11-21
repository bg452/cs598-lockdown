using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {
    public GameObject gameOverPanel;
    public GameObject nextLevelPanel;
    public GameObject statusPanel;
    public GameObject timer;

    private float elapsedTime;

    public void Start() {
        Time.timeScale = 1;
        elapsedTime = Time.deltaTime;
        gameOverPanel.SetActive(false);
        nextLevelPanel.SetActive(false);
        statusPanel.SetActive(true);
        timer.SetActive(false);
    }

    private void Update() {
        elapsedTime += Time.deltaTime;
        if (detectCollision.hasCollision) {
            endGame(false);
        } else if (EnemyAI.playerWin == true) {
            endGame(true);
        }
    }

    private void endGame(bool playerWin) {
        displayElapsedTime();
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 0;
        Destroy(GameObject.Find("Spawner"));
        if (!playerWin) {
            gameOverPanel.SetActive(true);
            GameObject.Find("GameOverText").GetComponent<Text>().text = "Game Over!";
        } else {
            nextLevelPanel.SetActive(true);
        }
        EnemyAI.playerWin = false;
    }

    public void LoadNextLevel() {
        nextLevelPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
