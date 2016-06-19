using UnityEngine;
using System.Collections;

public class OffPitchMovement : MonoBehaviour {

    //Controls how much the balls spins off the pitch
    Rigidbody ball;

    float rotSpinXLow;  //the low value for spin in the X direction
    float rotSpinXHigh; //the high value for spin in the X direction
    float rotSpinZLow;  //the low value for spin in the Z direction
    float rotSpinZHigh; //the high value for spin in the Z direction


    void OnCollisionEnter(Collision col)
    {
        if (BowlingMachine.bowlTypeGen==1)
        {
            switch (BowlingMachine.spinType)
            {
                case 0: //Legbreak
                    rotSpinZLow = -90f;
                    rotSpinZHigh = -120f;
                    Debug.Log("LegBreak Pitch");
                    break;

                case 1: //OffBreak
                    rotSpinZLow = 90f;
                    rotSpinZHigh = 120f;
                    Debug.Log("OffBreak Pitch");
                    break;

                case 2: //Flipper
                    rotSpinXLow = 50f;
                    rotSpinXHigh = 100f;
                    Debug.Log("Flipper Pitch");
                    break;
            }
        }

        float spinX = Random.Range(rotSpinXLow, rotSpinXHigh);
        float spinZ = Random.Range(rotSpinZLow, rotSpinZHigh);

        ball = GetComponent<Rigidbody>();
        if (col.gameObject.tag == "Pitch" && BowlingMachine.alreadyBounced==false)
            //Ensures that ball only moves off pitch on the first bounce
        {
            ball.AddForce(spinX, 0, spinZ);
            BowlingMachine.alreadyBounced = true;
        }
            
    }

}
