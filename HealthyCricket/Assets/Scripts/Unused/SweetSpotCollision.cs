using UnityEngine;
using System.Collections;

public class SweetSpotCollision : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball")
            Debug.Log("SweetSpot has collided");
    }

    void OnCollisionExit(Collision col)
    {

    }
}

