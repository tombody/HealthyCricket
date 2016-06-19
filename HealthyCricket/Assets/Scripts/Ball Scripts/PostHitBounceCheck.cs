using UnityEngine;
using System.Collections;

public class PostHitBounceCheck : MonoBehaviour {

    // Attach to ball prefab. Checks to see if ball has bounced after contact with bat.

    [HideInInspector]static public bool hasBounced; //checks to see if ball has hit the ground after making contact with the bat
    [HideInInspector]static public bool hasHitBat; //checks if ball has hit the bat

    void Start()
    {
        hasBounced = false;
        hasHitBat = false;
    }

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.layer==9) //9 is bat
        {
            hasHitBat = true;
        }

        if (col.gameObject.layer==10 && hasHitBat==true) //10 is ground (pitch and outfield)
        {
            hasBounced = true;
        }
	}
}
