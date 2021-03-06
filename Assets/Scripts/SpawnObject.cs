﻿

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 
public class SpawnObject : MonoBehaviour {
	private GameObject prefab;

    private int maxDistraction = 5;
    private int maxAlarm = 1;
    private int maxSign = 5;
    private int count = 0;
    // Counts to limit how many of each object can be spawned
    public int alarmCount = 0;
    public int signCount = 0;
    public int distractionCount = 0;
    public string[] actions;
    public float[] time;
    private float elapsedTime;
	// Use this for initialization
	void Start () {
        

    }
    void Awake()
    {
       
        actions = new string[maxAlarm + maxDistraction + maxSign];
        time = new float[maxAlarm + maxDistraction + maxSign];
       
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (distractionCount < maxDistraction)
            {
                prefab = (GameObject)Resources.Load("Prefabs/DistractionCube");
                SpawnPrefab(prefab);
                
                actions[count] = "distraction";
                time[count] = elapsedTime;
                Debug.Log(actions[count] + " at " + time[count]);
                count++;
                
                
            }
            distractionCount++;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (alarmCount < maxAlarm)
            {
                prefab = (GameObject)Resources.Load("Prefabs/Alarm");
                SpawnPrefab(prefab);
                actions[count] = "alarm";
                time[count] = elapsedTime;
                Debug.Log(actions[count] + " at " + time[count]);
                count++;
            }
            alarmCount++;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (signCount < maxSign)
            {
                prefab = (GameObject)Resources.Load("Prefabs/UpSign");
                SpawnSign(prefab, 'W');
                actions[count] = "upArrow";
                time[count] = elapsedTime;
                Debug.Log(actions[count] + " at " + time[count]);
                count++;
            }
            signCount++;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (signCount < maxSign)
            {
                prefab = (GameObject)Resources.Load("Prefabs/LeftSign");
                SpawnSign(prefab, 'A');
                actions[count] = "leftArrow";
                time[count] = elapsedTime;
                Debug.Log(actions[count] + " at " + time[count]);
                count++;
            }
            signCount++;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (signCount < maxSign)
            {
                prefab = (GameObject)Resources.Load("Prefabs/DownSign");
                SpawnSign(prefab, 'S');
                actions[count] = "downArrow";
                time[count] = elapsedTime;
                Debug.Log(actions[count] + " at " + time[count]);
                count++;
            }
            signCount++;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (signCount < maxSign)
            {
                prefab = (GameObject)Resources.Load("Prefabs/RightSign");
                SpawnSign(prefab, 'D');
                actions[count] = "rightArrow";
                time[count] = elapsedTime;
                Debug.Log(actions[count] + " at " + time[count]);
                count++;
            }
            signCount++;
        }
        else
        {
            // do nothing
        }

        if (signCount <= maxSign)
        {
            GameObject.Find("StatusSign").GetComponent<Text>().text = "Signs: " + (maxSign - signCount).ToString();
        }

        if (distractionCount <= maxDistraction)
        {
            GameObject.Find("StatusDistraction").GetComponent<Text>().text = "Distractions: " + (maxDistraction - distractionCount).ToString();
        }

        if (alarmCount <= maxAlarm)
        {
            GameObject.Find("StatusAlarm").GetComponent<Text>().text = "Alarms: " + (maxAlarm - alarmCount).ToString();
        }
    }

    void SpawnPrefab (GameObject prefab) {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
            Vector3 editedHitPoint = hit.point;
            editedHitPoint.y = 1.5f;
            Instantiate(prefab, editedHitPoint, hit.transform.rotation);
            Debug.Log(hit.point);
        }
    }

    void SpawnSign (GameObject prefab, char c) {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
            Vector3 editedHitPoint = hit.point;
            Vector3 rotation = new Vector3(0, 0, 0);
            editedHitPoint.y = 1;
            if (c == 'W') {
                rotation = new Vector3(0, 90, 0);
            } else if (c == 'A') {
                rotation = new Vector3(0, 0, 0);
            } else if (c == 'S') {
                rotation = new Vector3(0, -90, 0);
            } else if (c == 'D') {
                rotation = new Vector3(0, 180, 0);
            }
            Instantiate(prefab, editedHitPoint, Quaternion.Euler(rotation));
        }
    }
}

