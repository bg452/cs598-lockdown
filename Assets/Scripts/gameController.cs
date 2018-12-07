using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class gameController : MonoBehaviour {
    public GameObject gameOverPanel;
    public GameObject nextLevelPanel;
    public GameObject statusPanel;
    public GameObject timer;

    public static int score = 0;

    private float elapsedTime;
    private int levelComplete = 0;

    public void Start() {
        Time.timeScale = 1;
        elapsedTime = Time.deltaTime;
        gameOverPanel.SetActive(false);
        nextLevelPanel.SetActive(false);
        statusPanel.SetActive(true);
        timer.SetActive(false);
        GameObject.Find("StatusScore").GetComponent<Text>().text = "Score: " + (score).ToString();
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
            levelComplete++;
        }
        EnemyAI.playerWin = false;
    }

    public void LoadNextLevel() {
        nextLevelPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartGame() {
        // Reset score to 0
        score = 0;

        gameOverPanel.SetActive(false);
        // Restart current level
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Restart from level 1
        SceneManager.LoadScene(1);
    }
    public void LoadMainMenu() {
        // Reset score to 0
        score = 0;

        statusPanel.SetActive(false);

        SceneManager.LoadScene("Start");
    }

    private void displayElapsedTime() {
        string minutes = Mathf.Floor(elapsedTime / 60).ToString("00");
        string seconds = (elapsedTime % 60).ToString("00");
        timer.SetActive(true);
        GameObject.Find("TimerText").GetComponent<Text>().text = "Elapsed time: " + minutes + ":" + seconds;
        // Add text for time bonus (bonus score points for quickly beating the level + scales as you progress)
        if (minutes == "00" && levelComplete == 1) {
            int s = Int32.Parse(seconds);
            int currLevel = SceneManager.GetActiveScene().buildIndex;
            if (s < 10) {
                increaseScore(50 * currLevel);
                GameObject.Find("TimeBonusText").GetComponent<Text>().text = "Time bonus: +" + (50 * currLevel);
            } else if (s < 20) {
                increaseScore(20 * currLevel);
                GameObject.Find("TimeBonusText").GetComponent<Text>().text = "Time bonus: +" + (20 * currLevel);
            } else if (s < 30) {
                increaseScore(10 * currLevel);
                GameObject.Find("TimeBonusText").GetComponent<Text>().text = "Time bonus: +" + (10 * currLevel);
            }
        }

    }
    public float getTime() {
        return elapsedTime;

    }
    public static void increaseScore(int points) {
        score += points;
        GameObject.Find("StatusScore").GetComponent<Text>().text = "Score: " + (score).ToString();
    }

}
