using UnityEngine;
using System.Collections;

public class InnerFielder : Fielder {

    void Awake()
    {
        Debug.Log("Carrot is awake");
    }

    void FixedUpdate()
    {
        Look();
    }
}

