using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectCollision : MonoBehaviour
{
    public static bool hasCollision = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Civilian")
        {
            hasCollision = true;
        }
    }
}
