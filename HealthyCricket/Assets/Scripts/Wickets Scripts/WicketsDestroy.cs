using UnityEngine;
using System.Collections;

public class WicketsDestroy : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, BowlingMachine.destroyRate);
    }
}
