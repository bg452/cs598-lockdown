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
        } else if (Input.GetKeyDown(KeyCode.W)) {
            prefab = (GameObject)Resources.Load("Prefabs/UpSign");
            SpawnSign(prefab, 'W');
        } else if (Input.GetKeyDown(KeyCode.A)) {
            prefab = (GameObject)Resources.Load("Prefabs/LeftSign");
            SpawnSign(prefab, 'A');
        } else if (Input.GetKeyDown(KeyCode.S)) {
            prefab = (GameObject)Resources.Load("Prefabs/DownSign");
            SpawnSign(prefab, 'S');
        } else if (Input.GetKeyDown(KeyCode.D)) {
            prefab = (GameObject)Resources.Load("Prefabs/RightSign");
            SpawnSign(prefab, 'D');
        } else {
            // do nothing
        }

	}

    void SpawnPrefab (GameObject prefab) {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
            Vector3 editedHitPoint = hit.point;
            Instantiate(prefab, editedHitPoint, hit.transform.rotation);
            Debug.Log(hit.point);
        }
    }

    void SpawnSign (GameObject prefab, char c) {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
            Vector3 editedHitPoint = hit.point;
            Vector3 rotation = new Vector3(0, 0, 0);
            editedHitPoint.y = 1;
            if (c == 'W') {
                rotation = new Vector3(0, 90, 0);
            } else if (c == 'A') {
                rotation = new Vector3(0, 0, 0);
            } else if (c == 'S') {
                rotation = new Vector3(0, -90, 0);
            } else if (c == 'D') {
                rotation = new Vector3(0, 180, 0);
            }
            Instantiate(prefab, editedHitPoint, Quaternion.Euler(rotation));
        }
    }
}
