using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class moveToSafetyZone : MonoBehaviour {
    private NavMeshAgent agent;
    private GameObject[] allSafeZones;

    // Use this for initialization
    void Start(){
        agent = GetComponent<NavMeshAgent>();
        allSafeZones = GameObject.FindGameObjectsWithTag("Safety");
    }

	// Update is called once per frame
	void Update () {
        agent.destination = findClosestObj(allSafeZones).transform.position;
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
