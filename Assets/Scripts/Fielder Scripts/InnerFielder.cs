using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InnerFielder : Fielder {

    //Shoud be attached to the InnerFielder empty in game

    int fielderIndex;

    Vector3 startPos;
    Quaternion startRot;

    //--------------------------------------------------------------------------------------------------//

    void Awake() //Do not change from awake
    {
        moveSpeed = 0.01f;
        rotSpeed = 0.1f;
        numberOfFielders++; //adds to the total numbers of fielders. Must be in Awake so that lists populate properly.

        startPos = transform.position; //saves the initial position of the fielder for this instance
        startRot = transform.rotation;
    }

    void Start()
    {
    }

    void FixedUpdate()
    {
        Look();
        fielderIndex = AllFielders.fielders.IndexOf(gameObject); //must be in start to occur after awake
        

        if (AllFielders.ball)
        {
            if (fielderIndex == AllFielders.closestFielderIndex) //if the fielder is not the closest fielder
            {
                Move(); //only the closest fielder will move
            }
            else if (fielderIndex != AllFielders.closestFielderIndex)
            {
                BackToPos(); //When not the closest fielder returns back to the start position
            }
        }

        if (!AllFielders.ball)
        {
            BackToPos(); //When there is no ball the player moves back to the start position
        }

    }

    //--------------------------------------------------------------------------------------------------//

    public void BackToPos() //Returns fielder back to the start position
    {
        transform.position = Vector3.Lerp(transform.position, startPos, moveSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, startRot, rotSpeed);
    }
}

