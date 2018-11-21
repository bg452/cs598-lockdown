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
            // Add points to score for each civilian that enters the alarm
            gameController.increaseScore(10);
            other.GetComponent<moveToSafetyZone>().panic();
        } else if (other.tag == "Enemy") {
            other.GetComponent<EnemyAI>().alarm();
        }
    }
}
