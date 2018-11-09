using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class initAgents : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject civilianPrefab;
    public int numEnemy = 2;
    public int numCivilians = 12;

    private Vector3[] enemy_pos = new[] { new Vector3(14, 1, -3), new Vector3(57, 1, -22),
        new Vector3(44, 1, 22), new Vector3(27, 1, 5) };

    // Use this for initialization
    void Start()
    {
        // different initial position for enemies, works for 2. Can use a list for > 2
        int prev_ind = Random.Range(0, enemy_pos.Length - 1);

        for (int i = 0; i < numEnemy; ++i)
        {
            int rand_ind = Random.Range(0, enemy_pos.Length - 1);
            while (rand_ind == prev_ind)
            {
                rand_ind = Random.Range(0, enemy_pos.Length - 1);
            }

            GameObject enemy = Instantiate(enemyPrefab, enemy_pos[rand_ind], Quaternion.identity);
            enemy.transform.SetParent(GameObject.Find("Enemies").transform);
            prev_ind = rand_ind;
        }

        for (int i = 0; i < numCivilians; ++i)
        {
            Vector3 pos = new Vector3(Random.Range(11, 60), 1, Random.Range(-24, 24));
            pos = checkDistToEnemy(pos);
            GameObject civilian = Instantiate(civilianPrefab, pos, Quaternion.identity);
            civilian.transform.SetParent(GameObject.Find("Civilians").transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    Vector3 checkDistToEnemy(Vector3 pos)
    {
        Vector3 retVal = pos;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDist = 12f;

        foreach (GameObject enemy in enemies)
        {
            float dist = (enemy.transform.position - pos).sqrMagnitude;
            if (dist <= minDist)
            {
                retVal.x += minDist;
                retVal.z = -1 * retVal.z;
                break;
            }
        }

        return retVal;
    }
}
