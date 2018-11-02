using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
    public void RestartGame() {
        GameObject.Find("GameOverPanel").SetActive(false);
        SceneManager.LoadScene("lockdown");
    }
}
