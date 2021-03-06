﻿using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class moveToSafetyZone : MonoBehaviour {
    private NavMeshAgent agent;
    private GameObject[] allSafeZones;
    private GameObject[] allEnemies;

    private RaycastHit hit;
    private float dist = 10;
    private Vector3 dir = new Vector3(0,-1,0);

    private float minDistToEnemy = 20f;

    public float moveSpeed = 2.5f;

    private int stopCounter = 0;

    // Use this for initialization
    void Start(){
        agent = GetComponent<NavMeshAgent>();
        allSafeZones = GameObject.FindGameObjectsWithTag("Safety");
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        agent.destination = RandomNavMeshLocation(20f);
    }

 
	// Update is called once per frame
	void Update () {

        
        
        Debug.DrawRay(transform.position, dir * dist, Color.green);


        if (Physics.Raycast(transform.position, dir, out hit, dist,1<<9))
        {
           

            if (hit.collider.gameObject.tag == "Safety")
            {
               
                gameObject.tag = "Safe";
            }
        }
        if (agent.tag == "Safe") {
            agent.isStopped = true;
            stopCounter++;
            if (stopCounter == 1) {
                gameController.increaseScore(50);
            }
        }
        else if (seenEnemy())
        {
            agent.destination = findClosestObj(allSafeZones).transform.position;
            panic();
        }
        else if (hasReachedDestination())
        {
            agent.destination = RandomNavMeshLocation(20f);
        }
    }

    bool hasReachedDestination() {
        if (!agent.pathPending) {
            if (agent.remainingDistance <= agent.stoppingDistance) {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
                    return true;
                }
            }
        }
        return false;
    }

    public Vector3 RandomNavMeshLocation(float radius) {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
    /*
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Safety")
        {
            gameObject.tag = "Safe";
        }
    }
    */
    bool seenEnemy()
    {
        bool retVal = false;
        GameObject closestEnemy = findClosestObj(allEnemies);
        float currDistToEnemy = (closestEnemy.transform.position - agent.transform.position).sqrMagnitude;
        if (currDistToEnemy <= minDistToEnemy)
        {
            retVal = true;
        }

        return retVal;
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

    public void panic()
    {
        agent.destination = findClosestObj(allSafeZones).transform.position;
        // change speed
        agent.speed = 3.75f;
        // change color
        Renderer rend = agent.GetComponent<Renderer>();
        rend.material.color = new Color32(102, 51, 153, 0);
    }
}
