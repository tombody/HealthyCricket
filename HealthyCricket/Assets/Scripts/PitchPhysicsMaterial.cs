using UnityEngine;
using System.Collections;

public class PitchPhysicsMaterial : MonoBehaviour {

    //Changes the physics material  of the pitch dependent on facing a fast or spin bowler

    public PhysicMaterial fast;
    public PhysicMaterial spin;
    public PhysicMaterial afterHit;

    void Start ()
    {
        PitchCheck();
	}

    void FixedUpdate()
    {
        if (BowlingMachine.hitCheck==true)
        {
            GetComponent<Collider>().material = afterHit;   //reduces the bounce of the pitch. This stops the ball from
                                                            //rocketting off the pitch due to the high bounce setting on
                                                            //the fast pitch
        }
            
        else if(BowlingMachine.hitCheck==false)
        {
            PitchCheck();
        }
    }

    void PitchCheck()
    {
        if (BowlingMachine.bowlTypeGen == 0)
        {
            GetComponent<Collider>().material = fast;
        }
        else if (BowlingMachine.bowlTypeGen == 1)
        {
            GetComponent<Collider>().material = spin;
        }
    }
	
}
