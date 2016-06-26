using UnityEngine;
using System.Collections;

public class SixActivate : MonoBehaviour {

    //displays a 6 whenever a six is scored

    static public Renderer[] sixSymbol; //an array because there are two renderers childed to NumSix gameObj

    void Awake()
    {
        sixSymbol = GetComponentsInChildren<Renderer>();
    }

    void Update()
    {
        if (RunDetector.sixBanner)
        {
            SixSign();
        }
    }

    void SixSign()
    {
        sixSymbol[0].enabled = true;
        sixSymbol[1].enabled = true;
    }
}