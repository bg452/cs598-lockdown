using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class moveToSafetyZone : MonoBehaviour {
    private NavMeshAgent agent;
    private GameObject[] allSafeZones;
    private GameObject[] allEnemies;

    private float minDistToEnemy = 20f;

    public float moveSpeed = 2.5f;
    public float rotSpeed = 10f;

    private bool isRotaingLeft = false;
    private bool isRoatingRight = false;
    private bool isWalking = false;

    private bool isWander = false;

    // Use this for initialization
    void Start(){
        agent = GetComponent<NavMeshAgent>();
        allSafeZones = GameObject.FindGameObjectsWithTag("Safety");
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

 
	// Update is called once per frame
	void Update () {

        if (seenEnemy())
        {
            agent.destination = findClosestObj(allSafeZones).transform.position;
            agent.speed = 3.5f;
            

        }
        else
        {
            StartCoroutine(Wander());

            if (isRoatingRight)
            {
                transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
            }

            if (isRotaingLeft)
            {
                transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
            }

            if (isWalking)
            {
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Safety")
        {
            gameObject.tag = "Safe";
        }
    }
    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotWait = Random.Range(1, 4);
        int rotateLorR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotWait);

        if (rotateLorR == 1)
        {
            isRoatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotaingLeft = false;
        }
        if (rotateLorR == 2)
        {
            isRotaingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRoatingRight = false;
        }
    }

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
}
