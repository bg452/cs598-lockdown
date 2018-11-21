using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SignTrigger : MonoBehaviour {
    private GameObject sign;
	// Use this for initialization
	void Start () {
        sign = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Civilian") {
            // Add points to score for each civilian that enters the sign
            gameController.increaseScore(20);

            int xOffset = 0;
            int zOffset = 0;
            if (sign.tag == "UpSign") {
                xOffset = -6;
            } else if (sign.tag == "DownSign") {
                xOffset = 6;
            } else if (sign.tag == "LeftSign") {
                zOffset = -6;
            } else if (sign.tag == "RightSign") {
                zOffset = 6;
            }
            NavMeshAgent agent = other.GetComponent<NavMeshAgent>();
            agent.destination = new Vector3(sign.transform.position.x + xOffset, sign.transform.position.y, sign.transform.position.z + zOffset);
        }
    }
}
