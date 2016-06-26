using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ControllerFeedback : MonoBehaviour {

    SteamVR_Controller.Device device;
    SteamVR_TrackedObject trackedObj;

    private AudioSource source;
    public AudioClip sweetSpot;
    public AudioClip edged;
    public AudioClip normalBatHit;
    float volVelocity; //controls the volume of the audio based on velocity

    //For Haptic Feedback (not working yet)
    float vibrationTime = 500f;
    float vibrationStrength = 1;

    //--------------------------------------------------------------------------------------------------//

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);

    }

    //--------------------------------------------------------------------------------------------------//

    void OnCollisionEnter(Collision col)
    {
        ContactPoint contact = col.contacts[0];
        Collider point = contact.thisCollider;

        if (point.name=="Bat")   
        {
            Audio(normalBatHit, .3f, col);
            Debug.Log("Collided with Bat");
        }

        if (point.name == "SweetSpot")   
        {
            Audio(sweetSpot, 0.5f, col);
            Debug.Log("Collided with SweetSpot");
        }

        if (point.name == "EdgeLeft")
        {
            Audio(edged, 0.1f, col);
            Debug.Log("Collided with EdgeLeft");
        }

        if (point.name == "EdgeRight")
        {
            Audio(edged, 0.1f, col);
            Debug.Log("Collided with EdgeRight");
        }

        if (col.gameObject.tag=="Ball")
        {
            Debug.Log("Ball has collided with controller's rigidbody");
            //LongVibration(vibrationTime, vibrationStrength); //Not working yet
        }
       
        
    }

    //--------------------------------------------------------------------------------------------------//

    void Audio(AudioClip clip, float volumeMod, Collision col)//selects audioclip and sets volume level modifier
    {
        if (col.gameObject.tag=="Ball")
        {
            volVelocity = col.relativeVelocity.magnitude * 0.3f;
            source.pitch = Random.Range(.75f, 1.2f);

            source.PlayOneShot(clip, volVelocity);
        }
    }

    /*IEnumerator LongVibration(float length, float strength)
    {
        for (float i = 0; i < length; i+=Time.deltaTime)
        {
            //SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(1000);
            device.TriggerHapticPulse(3999);
            yield return null;
        }
    } */
}
