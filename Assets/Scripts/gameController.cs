using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public GameObject gameOverPanel;

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
