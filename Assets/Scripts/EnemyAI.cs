using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    private GameObject[] allCivilians;
    private List<GameObject> distraction;
    private GameObject closestDistraction;
    public static bool playerWin;

    // Use this for initialization
    void Start () {
        playerWin = false;
        allCivilians = GameObject.FindGameObjectsWithTag("Civilian");
    }
	
	// Update is called once per frame
	void Update () {
        allCivilians = GameObject.FindGameObjectsWithTag("Civilian");
        distraction = new List<GameObject>(GameObject.FindGameObjectsWithTag("Distraction"));
        if (distraction.Count != 0 && !detectCollision.hasBeenDistracted) {
            StartCoroutine("Distracted");
        } else if (allCivilians.Length > 0) {
		    StartCoroutine("Chasing");
        } else {
            // All civilians are safe
            GetComponent<NavMeshAgent>().isStopped = true;
            playerWin = true;
        }
	}

    IEnumerator Distracted() {
        closestDistraction = findClosestObj(distraction.ToArray());
        GetComponent<NavMeshAgent>().destination = closestDistraction.transform.position;
        distraction.Remove(closestDistraction);
        yield return new WaitForSeconds(10);
        detectCollision.hasBeenDistracted = false;
        Destroy(closestDistraction);
    }

    IEnumerator Chasing() {
        GetComponent<NavMeshAgent>().destination = findClosestObj(allCivilians).transform.position;
        yield return new WaitForEndOfFrame();
    }


    GameObject findClosestObj(GameObject[] targetObject)
    {
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject obj in targetObject)
        {
            if (!(obj.tag == "Safe"))
            {
                Vector3 diff = obj.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = obj;
                    distance = curDistance;
                }
            }
        }

        return closest;
    }
}
