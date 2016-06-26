using UnityEngine;
using System.Collections;

public class WicketsCollisionCheck : MonoBehaviour {

    //Used to check if ball or bat has collided with the wickets

    bool endThisBall;//Ensures only the first collision is detected

    void Start () {

        endThisBall = false; 
	}
	
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.layer == 8 && !endThisBall) //ball hitting wickets
        {
            ScoreCard.bowlOrCrown = 0; //0 is for bowled
            ScoreCard.WicketsHit();
            endThisBall = true;

        }

        if (col.gameObject.layer == 9 && !endThisBall) //bat hitting wickets
        {
            ScoreCard.bowlOrCrown = 1; //1 is for crowned
            ScoreCard.WicketsHit();
            endThisBall = true;
        }

    }
}
