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
        SceneManager.LoadScene(1);
    }
    public void Level1()
    {
        GameObject.Find("StartGameButton").SetActive(false);
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        GameObject.Find("StartGameButton").SetActive(false);
        SceneManager.LoadScene(2);
    }
    public void Level3()
    {
        GameObject.Find("StartGameButton").SetActive(false);
        SceneManager.LoadScene(3);
    }
    public void Level4()
    {
        GameObject.Find("StartGameButton").SetActive(false);
        SceneManager.LoadScene(4);
    }
    public void Level5()
    {
        GameObject.Find("StartGameButton").SetActive(false);
        SceneManager.LoadScene(5);
    }

}
