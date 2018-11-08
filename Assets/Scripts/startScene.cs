using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScene : MonoBehaviour {

    // Use this for initialization
    void Start() {
        GameObject.Find("StartGameButton").SetActive(true);
    }

    // Update is called once per frame
    void Update() {

    }

    public void startGame()
    {
        GameObject.Find("StartGameButton").SetActive(false);
        SceneManager.LoadScene("lockdown");
    }
}
