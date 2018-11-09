using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {
    public GameObject gameOverPanel;
    public GameObject nextLevelPanel;

    public void Start() {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
    }

    private void Update() {
        if (detectCollision.hasCollision) {
            endGame(false);
        } else if (EnemyAI.playerWin == true) {
            endGame(true);
        }
    }

    private void endGame(bool playerWin) {
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 0;
        Destroy(GameObject.Find("Spawner"));
        if (!playerWin) {
            gameOverPanel.SetActive(true);
        }
        if (playerWin && currentBuildIndex < 2) {
            nextLevelPanel.SetActive(true);
        } else {
            gameOverPanel.SetActive(true);
        }
        EnemyAI.playerWin = false;
    }

    public void LoadNextLevel() {
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
}
