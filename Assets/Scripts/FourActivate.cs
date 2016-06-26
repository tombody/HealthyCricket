using UnityEngine;
using System.Collections;

public class FourActivate : MonoBehaviour {

    //displays a 6 whenever a six is scored

    static public Renderer fourSymbol;

    void Awake()
    {
        fourSymbol = GetComponent<Renderer>();
    }

	void Update ()
    {
        if (RunDetector.fourBanner)
        {
            FourSign();
        }
	}

    void FourSign()
    {
        fourSymbol.enabled = true;
    }
}
