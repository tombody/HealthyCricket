using UnityEngine;
using System.Collections;

public class BallOffBat : MonoBehaviour {

    //Controls how the ball comes off the bat. Script attaches to the ball prefab

    public GameObject batParent;
    BoxCollider[] batCol; //array for the colliders parented under batParent

    Rigidbody ball; 
    Collider ballCol;

    Vector3 batVel; //the velocity of the bat
    float fastVelModifier; //modifies the velocity of the ball coming off the bat for fastBowler
    float spinVelModifier; //for spinBowler

    //--------------------------------------------------------------------------------------------------//

    void Start()
    {
        ball = GetComponent<Rigidbody>();
        ballCol = GetComponent<Collider>();
        batCol = batParent.GetComponentsInChildren<BoxCollider>();
        fastVelModifier = 1.5f;
        spinVelModifier = 1.75f; //these variables should eventually be used to determine the skill level of a batsmen
    }

    void FixedUpdate()  //this will ensure that bat will collide only once per instance of each ball.
                        //this prevents the bat from passing through the ball on hit and having the 
                        //back of the bat re-hit the ball
    {
        if (BowlingMachine.hitCheck == true)    //hitCheck checks to see if ball has been hit by the bat
                                                //it is false when the ball is instantiated
        {
            Physics.IgnoreLayerCollision(8, 9); //layer 8 is the ball layer, and 9 is the bat
        }
        if (BowlingMachine.hitCheck == false)
        {
            Physics.IgnoreLayerCollision(8, 9,false);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer==9 && BowlingMachine.bowlTypeGen==0) //layer 9 is bat. This changes the velocity of the ball directly for fastBowler
        {
            BowlingMachine.hitCheck = true; //on collision with the bat, sets hitChecks to true
            batVel = col.relativeVelocity;
            ball.velocity = Vector3.Lerp(ball.velocity, batVel, 0.1f) * fastVelModifier;
        }
        else if (col.gameObject.layer == 9 && BowlingMachine.bowlTypeGen == 1) //for spinBowler
        {
            BowlingMachine.hitCheck = true;
            batVel = col.relativeVelocity;
            ball.velocity = Vector3.Lerp(ball.velocity, batVel, 0.1f) * spinVelModifier;
        }
    }
}
