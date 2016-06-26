using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreCard : MonoBehaviour {

    [HideInInspector] static public int wicketsDown;
    [HideInInspector] static public int wicketsRemaining;
    [HideInInspector] static public int bowlOrCrown;
    [HideInInspector] static public bool runOnce;

    [HideInInspector] static public int ballsBowled;
    [HideInInspector] static public int ballsInGame;
    [HideInInspector] static public int ballsRemaining;

    [HideInInspector] static public int oversBowled;
    [HideInInspector] static public int oversRemaining;

    [HideInInspector] static public int runsScored;

    public Text wicketsDownTeamA;
    public Text runsScoredTeamA;
    public Text runsRqdTeamA;
    public Text ballsRmnTeamA;
    public Text wicketsRmnTeamA;

    //--------------------------------------------------------------------------------------------------//

    void Awake () {

        wicketsDown = 0;
        wicketsRemaining = 10;

        ballsBowled = 0;
        ballsInGame = 120; //20 over game

	}
	
	void Update () {

        ballsRemaining = ballsInGame - ballsBowled;
        wicketsRemaining = 10 - wicketsDown;

        ScoreCardTextUpdate();
	}

    //--------------------------------------------------------------------------------------------------//

    static public void WicketsHit()
    {
        if (bowlOrCrown == 0 && !runOnce) //bowled
        {
            wicketsDown++;
            Debug.Log("WicketsDown = " + wicketsDown);
            Debug.Log("Bowled!");
            runOnce = true;
        }

        if (bowlOrCrown == 1 && !runOnce) //crowned
        {
            wicketsDown++;
            Debug.Log("WicketsDown = " + wicketsDown);
            Debug.Log("You crowned yourself!");
            runOnce = true;
        }
    }

    void ScoreCardTextUpdate()
    {
        wicketsDownTeamA.text = wicketsDown.ToString();
        runsScoredTeamA.text = runsScored.ToString();
        runsRqdTeamA.text = "";
        ballsRmnTeamA.text = ballsRemaining.ToString();
        wicketsRmnTeamA.text = wicketsRemaining.ToString();
    }
}
