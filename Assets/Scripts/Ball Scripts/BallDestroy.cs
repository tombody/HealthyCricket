using UnityEngine;
using System.Collections;

public class BallDestroy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, BowlingMachine.destroyRate);
    }
}
