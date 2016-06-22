using UnityEngine;
using System.Collections;

public class RunDetector : MonoBehaviour {

    //Script attached to ball prefab, calculates run scored
    //Use this script to reset runOnce balls on ball instantiation

    float boundaryDist; //sets the boundary distance
    float hitDist; //the distance the ball has been hit on the X-Z plane (ground plane)

    //used to calculate hisDist
    float ballDistX;
    float squareBallDistX;
    float squareBallDistZ;
    float ballDistZ;

    int fours; //counts fours
    int sixes; //counts sixes

    bool runOnce;

    Transform ball;

    //--------------------------------------------------------------------------------------------------//

    void Awake()
    {
        boundaryDist = 45f; //sets the distance for a boundary. Based on the X and Z scale of BoundaryDist

        runOnce = false;
        ScoreCard.runOnce = false; //resets the runOnce on scoreBoard on ball initialize

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
            ScoreCard.runsScored += 6;
            Debug.Log("6 Runs!");
            sixes++; //counts sixes
            runOnce = true;
        }
    }

    void FourRuns()
    {
        if (!runOnce)
        {
            ScoreCard.runsScored += 4;
            Debug.Log("4 Runs!");
            fours++; //counts fours
            runOnce = true;
        }
    }
}
