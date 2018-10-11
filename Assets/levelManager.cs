using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text gameOverText;

    public void Awake()
    {
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (detectCollision.hasCollision)
        {
            endGame();
        }
    }

    private void endGame()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
}
