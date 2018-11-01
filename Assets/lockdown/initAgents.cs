using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class initAgents : MonoBehaviour
{
    public GameObject enemy;
    public GameObject civilians;
    private int numEnemy = 2;
    private int numCivilians = 11;

    private float x;
    private float y = 1;
    private float z;
    private Vector3 pos;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < numEnemy; ++i)
        {
            x = Random.Range(11, 60);
            z = Random.Range(-24, 24);
            pos = new Vector3(x, y, z);

            Instantiate(enemy, pos, Quaternion.identity);
        }

        for (int i = 0; i < numCivilians; ++i)
        {
            x = Random.Range(11, 60);
            z = Random.Range(-24, 24);
            pos = new Vector3(x, y, z);

            Instantiate(civilians, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
