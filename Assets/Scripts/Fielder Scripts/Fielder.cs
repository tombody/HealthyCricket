using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fielder : MonoBehaviour {

    [HideInInspector] public float moveSpeed; //determines how fast the fielders will move towards the ball. set in the child fielder class
    [HideInInspector] public float rotSpeed;  //determines how quickly the fielder rotate back to their original position

    [HideInInspector] public GameObject ball; //set in the child fielder class
    private Vector3 moveDir;

    public float catchChance;
    [HideInInspector] public float ballSpeed; //measures how fast ball is moving 

    BoxCollider moveTry;
    SphereCollider catchTry;

    static public int numberOfFielders;

    void Update()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    //--------------------------------------------------------------------------------------------------//

    public void Look()
    {
        if (ball != null)
        {
            transform.LookAt(ball.transform);
        }
    }

    public void Move()
    {
        if (ball != null)
        {
            moveDir = new Vector3(ball.transform.position.x, transform.position.y, ball.transform.position.z);
            //moves the fielder in the direction of the ball without changing it's global Y position

            transform.position = Vector3.Lerp(transform.position, moveDir, moveSpeed); //lerps the fielder to the ball
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

}



