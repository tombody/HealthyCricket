using UnityEngine;
using System.Collections;

public class BowlTypeSelectFast : MonoBehaviour {

    //Let's the player select if they want to vs spin bowling or fast bowling
    //and destroys the game UI elements upon choice

    public GameObject otherSelect;
    public GameObject mainTitle;
    public GameObject scoreCard;
    public GameObject bowlingMachine;
    public Transform bowlingSpot;
    public GameObject wickets; //Ensure that wickets.cs script is not attached to these particular GameObjects
    public GameObject wicketsBowlersEnd;

    bool interacted;

    void Update()
    {
        if (interacted == true)
        {
            StartCoroutine(LateCall());
            Instantiate(bowlingMachine, bowlingSpot.position, bowlingSpot.rotation);
            interacted = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 9)
        {
            Physics.IgnoreLayerCollision(5, 9); //Ensures that only one collsion is recorded

            BowlingMachine.bowlTypeGen = 0; //0 is fastBowler
            GetComponent<MeshRenderer>().material.color = Color.red;

            Destroy(gameObject, 1);
            Destroy(otherSelect);
            Destroy(mainTitle, 1);
            Destroy(wickets); //The initial wickets won't reinstantiate until the game has started
            Destroy(wicketsBowlersEnd);

            interacted = true;
        }
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(.9f);
        scoreCard.SetActive(true); //turns on the scoredcard
    }  
}
