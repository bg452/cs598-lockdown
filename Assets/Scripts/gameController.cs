using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour {
    public GameObject gameOverPanel;

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
        Time.timeScale = 0;
        Destroy(GameObject.Find("Spawner"));
        gameOverPanel.SetActive(true);
        if (playerWin) {
            GameObject.Find("GameOverText").GetComponent<Text>().text = "You win!";
        }
        EnemyAI.playerWin = false;
    }
}
