using UnityEngine;
using System.Collections;

public class RunDetector : MonoBehaviour {

    //Script attached to ball prefab, calculates run scored

    float boundaryDist; //sets the boundary distance
    float hitDist; //the distance the ball has been hit on the X-Z plane (ground plane)

    //used to calculate hisDist
    float ballDistX;
    float squareBallDistX;
    float squareBallDistZ;
    float ballDistZ;

    bool runOnce;

    Transform ball;

    //--------------------------------------------------------------------------------------------------//

    void Awake()
    {
        boundaryDist = 35f; //sets the distance for a boundary. Based on the X and Z scale of BoundaryDist
        runOnce = false;

        ball = gameObject.GetComponent<Transform>();
    }

    void Update ()
    {

        ballDistX = ball.transform.position.x;
        ballDistZ = ball.transform.position.z;

        squareBallDistX = Mathf.Pow(ballDistX, 2);
        squareBallDistZ = Mathf.Pow(ballDistZ, 2);

        hitDist = Mathf.Sqrt(squareBallDistX + squareBallDistZ); //calculates distance from origin using pythag theorem
        
        if (hitDist>=boundaryDist && PostHitBounceCheck.hasHitBat && !PostHitBounceCheck.hasBounced)
            //checks if ball has hit boundary, if the ball has been hit by bat and if it hasn't bounced after being hit
        {
            SixRuns();
        }

        if (hitDist >= boundaryDist && PostHitBounceCheck.hasHitBat && PostHitBounceCheck.hasBounced)
        //checks if ball has hit boundary, if the ball has been hit by bat and if it has bounced after being hit
        {
            FourRuns();
        }

    }

    //--------------------------------------------------------------------------------------------------//

    void SixRuns()
    {
        if (!runOnce) //to ensure script only runs one time
        {
            BowlingMachine.runs += 6;
            Debug.Log("6 Runs!");
            Debug.Log("Score is " + BowlingMachine.runs + " runs");
            runOnce = true;
        }
    }

    void FourRuns()
    {
        if (!runOnce)
        {
            BowlingMachine.runs += 4;
            Debug.Log("4 Runs!");
            Debug.Log("Score is " + BowlingMachine.runs + " runs");
            runOnce = true;
        }
    }
}
