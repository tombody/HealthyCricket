using UnityEngine;
using System.Collections;

public class Fielder : MonoBehaviour {

    public float moveSpeed;

    public float catchChance;
    public float ballSpeed; //measures how fast ball is moving 

    public bool ballThroughBox;

    BoxCollider moveTry;
    SphereCollider catchTry;

    public GameObject ball;

    //--------------------------------------------------------------------------------------------------//

    public void MoveTry() //Fielder runs towards where ball will land if ball passes through the boxCollider
    {
        moveTry = GetComponent<BoxCollider>();

        if (ballThroughBox)
        {
            //Look();
            //Chase();
        }
    }

    //--------------------------------------------------------------------------------------------------//

    public void CatchTry() //Fielder will try to catch to catch the ball if it falls through the sphereCollider
    {
        catchTry = GetComponent<SphereCollider>();
        ballSpeed = ball.GetComponent<Rigidbody>().velocity.magnitude;
        catchChance = ballSpeed / 1000; //need to test what the maximum vel.magnitude is for the ball instead of 1000

        if (catchChance>0.0f)//need to test variable to see what works
        {
            ball.GetComponent<Rigidbody>().isKinematic = true;
            ScoreCard.wicketsDown++;
            Debug.Log("Ball is caught");
        }
        else
        {
            Debug.Log("Ball is dropped");
        }
    }

    //--------------------------------------------------------------------------------------------------//

    public void Chase()
    {
        transform.LookAt(ball.transform);
        Debug.Log("looking at ball");
        //transform.Translate(transform.forward * moveSpeed);
        //Debug.Log("Moving to ball");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 8)
        {
            ballThroughBox = true;
            MoveTry();
            CatchTry();
        }
    }

    public void Look()
    {
        Quaternion BodyRot = Quaternion.LookRotation(ball.transform.position);
        BodyRot.x = 0;
        BodyRot.y = 0;

        transform.rotation = Quaternion.Slerp(transform.rotation, BodyRot, Time.deltaTime*5);
    }
}



