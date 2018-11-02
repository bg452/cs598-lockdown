using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectCollision : MonoBehaviour
{
    public static bool hasCollision;
    public static bool hasBeenDistracted;

    private void Awake() {
        hasCollision = false;
        hasBeenDistracted = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Civilian")
        {
            hasCollision = true;
        }

        if (collision.collider.tag == "Distraction") 
        {
            hasBeenDistracted = true;
        }
    }
}
