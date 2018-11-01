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
            NavMeshAgent agent = other.GetComponent<NavMeshAgent>();
            agent.destination = new Vector3(sign.transform.position.x - 6, sign.transform.position.y, sign.transform.position.z);
        }
    }
}
