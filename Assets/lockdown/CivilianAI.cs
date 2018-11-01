using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CivilianAI : MonoBehaviour {
    private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /*private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "UpSign") {
            agent.destination = new Vector3(collision.collider.transform.position.x - 6, collision.collider.transform.position.y, collision.collider.transform.position.z);
        }
    }*/
}
