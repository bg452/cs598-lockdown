using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlarmTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Civilian") {
            other.GetComponent<moveToSafetyZone>().panic();
            Debug.Log("alarm trigger activated: civilian should panic!");
        }
    }
}
