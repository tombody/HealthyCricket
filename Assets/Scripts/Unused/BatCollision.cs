using UnityEngine;
using System.Collections;

public class BatCollision : MonoBehaviour {

void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag=="Ball")
        {
            Debug.Log("Bat has collided");
        }
            
    }
}
