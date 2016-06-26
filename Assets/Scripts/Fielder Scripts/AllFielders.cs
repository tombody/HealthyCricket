using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AllFielders : MonoBehaviour {

    //Populates the fielders list and fielders distance to ball list
    //Contains method to find which fielder is the closest

    static public List<GameObject> fielders;
    string fielderName;

    [HideInInspector] public List<float> fieldersDistToBall;
    [HideInInspector] public float distToBall;
    [HideInInspector] static public int closestFielderIndex;

    [HideInInspector] static public GameObject ball;

    //--------------------------------------------------------------------------------------------------//

    void Start ()
    {
        InnerFieldersList(); //must be in start so it happens after awake. Awake in InnerFielder sets the number of fielders
    }
	
	void FixedUpdate ()
    {
        ball = GameObject.FindGameObjectWithTag("Ball"); //For instantiated balls

        FielderDistToBallGen();
        ClosestFielder();
    }

    //--------------------------------------------------------------------------------------------------//

    void InnerFieldersList()
        //sets the fielders list according to the number of InnerFielders on field
    {
        fielders = new List<GameObject>();

        for (int i = 0; i < Fielder.numberOfFielders; i++)
            //loops over numbered fielders to add them to list (note all fielders beside the initial MUST be named InnerFielder (i)
        {
            fielderName = "InnerFielder" + " (" + i + ")";
            fielders.Add(GameObject.Find(fielderName));
        }

        fielders[0]= GameObject.Find("InnerFielder"); //ensures first element of list is just InnerFielder
        fielders[8] = GameObject.Find("InnerFielder (8)"); //ensures first element of list is just InnerFielder
    }

    //--------------------------------------------------------------------------------------------------//

    void FielderDistToBallGen()
        //creates a list of the distance of each fielder to the ball
    {
        fieldersDistToBall = new List<float>();

        if (ball != null)
        {
            foreach (var fielder in fielders)
            {
                distToBall = Vector3.Distance(ball.transform.position, fielder.transform.position);
                fieldersDistToBall.Add(distToBall);
            }
        }
    }

    //--------------------------------------------------------------------------------------------------//

    void ClosestFielder()
        //determines which fielder is the closest and sets the index of the list to closestFielder
    {
        if (ball!=null)
        {
            closestFielderIndex = fieldersDistToBall.IndexOf(fieldersDistToBall.Min());

        }
    }

}
