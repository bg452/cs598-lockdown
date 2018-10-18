using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    private GameObject[] allCivilians;

    // Use this for initialization
    void Start () {
        allCivilians = GameObject.FindGameObjectsWithTag("Civilian");
    }
	
	// Update is called once per frame
	void Update () {

		GetComponent<NavMeshAgent>().destination = findClosestObj(allCivilians).transform.position;
	}


    GameObject findClosestObj(GameObject[] targetObject)
    {
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject obj in targetObject)
        {
            Vector3 diff = obj.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = obj;
                distance = curDistance;
            }
        }

        return closest;
    }
}
