using UnityEngine;
using System.Collections;

public class BowlingMachine : MonoBehaviour {

    private int repeatTime = 5;
    private int repeatRate = 5; //sets the repeat rate and time for each ball
    static public float destroyRate = 5f; //sets the destroy rate for the ball and wickets

    public Rigidbody ballPrefab;
    public Transform bowlingSpot;

    public Transform wicketsPosition;
    public GameObject wicketsPrefab;
    public Transform wicketsBowlerEndPosition;
    public GameObject wicketsBowlerEndPrefab;

    public float fastBowlLow, fastBowlHigh, spinBowlLow, spinBowlHigh; //sets the range values for fast and spin bowling

    private float bowlSpeed;

    [HideInInspector]static public bool hitCheck; //checks to see if ball has already been hit by bat
    [HideInInspector]static public bool alreadyBounced = false;//checks to see if the ball has colllided with the pitch, used to ensure the ball only spins on first contact
    [HideInInspector]static public int bowlTypeGen; //Random int called in Start(). 0 for fastBowler, 1 for spinBowler
    [HideInInspector]static public int spinType; //Random int that controls the type of spinball bowled. 0 is LegBreak, 1 is OffBreak, 2 is Flipper

    //--------------------------------------------------------------------------------------------------//

    void Start()
    {
        fastBowlLow = 1700f;
        fastBowlHigh = 2200f;
        spinBowlLow = 1000f;
        spinBowlHigh = 1100f;

        BowlAgain();
        WicketReset();
        WicketBowlerEndReset();

    }

    //--------------------------------------------------------------------------------------------------//

    void BowlAgain()
    {
        if (bowlTypeGen == 0) //FastBowler
        {
            Debug.Log("FastBowler called up");
            InvokeRepeating("FastBowler", repeatTime, repeatRate);
            InvokeRepeating("WicketReset", repeatTime, repeatRate);
            InvokeRepeating("WicketBowlerEndReset", repeatTime, repeatRate);
        }
        else if (bowlTypeGen == 1) //SpinBowler
        {
            Debug.Log("SpinBowler called up");
            InvokeRepeating("SpinBowler", repeatTime, repeatRate);
            InvokeRepeating("WicketReset", repeatTime, repeatRate);
            InvokeRepeating("WicketBowlerEndReset", repeatTime, repeatRate);
            InvokeRepeating("BounceReset", repeatTime, repeatRate);
        }
    }

    void Bowler(float rotXLow, float rotXHigh, float rotYLow, float rotYHigh, float bowlSpeedLow, float bowlSpeedHigh)
    //rotXLow, rotXHigh, rotYLow, rotYHigh are floats that determine the range for the length (X) and line (Y) of the bowler
    //bowlSpeedLow, bowlSpeedHigh sets the range for the bowlSpeed

    {
        float bowlingRotationX, bowlingRotationY; //X controls length, Y controls line
        bowlingRotationX = Random.Range(rotXLow, rotXHigh);
        bowlingRotationY = Random.Range(rotYLow, rotYHigh);
        bowlSpeed = Random.Range(bowlSpeedLow, bowlSpeedHigh);

        //Varies the rotation of the bowling machine
        bowlingSpot.rotation = Quaternion.Euler(bowlingRotationX, bowlingRotationY, 0);

        //Instantiates a bowling ball with a random bowlSpeed
        Rigidbody ballInstance;
        ballInstance = Instantiate(ballPrefab, bowlingSpot.position, bowlingSpot.rotation) as Rigidbody;
        ballInstance.AddForce(bowlingSpot.forward * bowlSpeed);
        hitCheck = false; //ensures that each instantiated ball will collide with bat

        ScoreCard.ballsBowled++; //adds 1 to the balls bowled counter
    }

    //--------------------------------------------------------------------------------------------------//

    void FastBowler() 
    {
        Bowler(4f, 10f, 87f, 91f, fastBowlLow, fastBowlHigh);
    }


    //--------------------------------------------------------------------------------------------------//
    void SpinBowler()
    {
        spinType = Random.Range(0, 3);
        switch (spinType)
        {
            case 0:
                LegBreak();
                break;
            case 1:
                OffBreak();
                break;
            case 2:
                Flipper();
                break;
        }
    }

    void LegBreak()
    {
        Debug.Log("LegBreak");
        Bowler(-7f, -8f, 86f, 90f, spinBowlLow, spinBowlHigh);

    }

    void OffBreak()
    {
        Debug.Log("OffBreak");
        Bowler(-7f, -8f, 90f, 94f, spinBowlLow, spinBowlHigh);
    }

    void Flipper()
    {
        Debug.Log("Flipper");
        Bowler(-7f, -8f, 90f, 92f, spinBowlLow, spinBowlHigh);
    }


    //--------------------------------------------------------------------------------------------------//

    void WicketReset() //Resets the wickets every ball
    {
        GameObject wicketsInstance;
        wicketsInstance = Instantiate(wicketsPrefab, wicketsPosition.position,wicketsPosition.rotation) as GameObject;
    }

    void WicketBowlerEndReset() //Resets the wicketsBowlerEnd every ball
    {
        GameObject wicketsBowlerEndInstance;
        wicketsBowlerEndInstance = Instantiate(wicketsBowlerEndPrefab, wicketsBowlerEndPosition.position, wicketsBowlerEndPosition.rotation) as GameObject;
    }

    void BounceReset() //Resests the bounce bool each ball
    {
        alreadyBounced = false;
    }

    //--------------------------------------------------------------------------------------------------//

    void TestBowl() //For testing. Not called during play
    {
        InvokeRepeating("Flipper", repeatTime, repeatRate);
        InvokeRepeating("WicketReset", repeatTime, repeatRate);
        InvokeRepeating("WicketBowlerEndReset", repeatTime, repeatRate);
    }

    
}
