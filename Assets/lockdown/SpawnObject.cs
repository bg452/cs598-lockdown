using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {
	private GameObject prefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
            prefab = (GameObject)Resources.Load("Prefabs/DistractionCube");
            SpawnPrefab(prefab);
        } else if (Input.GetKeyDown(KeyCode.Q)) {
            prefab = (GameObject)Resources.Load("Prefabs/UpSign");
            SpawnPrefab(prefab);
        } else {
            // do nothing
        }

	}

    void SpawnPrefab (GameObject prefab) {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
            Instantiate(prefab, hit.point, hit.transform.rotation);
        }
    }
}
