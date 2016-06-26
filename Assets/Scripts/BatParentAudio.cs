using UnityEngine;
using System.Collections;

public class BatParentAudio : MonoBehaviour {

    private AudioSource source;
    public AudioClip sweetSpot;
    public AudioClip edged;
    public AudioClip normalBatHit;
    public AudioClip handle;
    public AudioClip backBat;

    float volVelocity; //controls the volume of the audio based on velocity

    //--------------------------------------------------------------------------------------------------//

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    //--------------------------------------------------------------------------------------------------//

    void OnCollisionEnter(Collision col)
    {
        ContactPoint contact = col.contacts[0];
        Collider point = contact.thisCollider;

        if (point.name == "Bat")
        {
            Audio(normalBatHit, .3f, col);
        }

        if (point.name == "SweetSpot")
        {
            Audio(sweetSpot, 0.5f, col);
        }

        if (point.name == "EdgeLeft")
        {
            Audio(edged, 0.1f, col);
        }

        if (point.name == "EdgeRight")
        {
            Audio(edged, 0.1f, col);
        }

        if (point.name == "Handle")
        {
            Audio(edged, 0.1f, col);
        }

        if (point.name == "BatBack")
        {
            Audio(edged, 0.2f, col);
        }
    }

    //--------------------------------------------------------------------------------------------------//

    void Audio(AudioClip clip, float volumeMod, Collision col)//selects audioclip and sets volume level modifier
    {
        if (col.gameObject.tag == "Ball")
        {
            volVelocity = col.relativeVelocity.magnitude * 0.3f;
            source.pitch = Random.Range(.75f, 1.2f);

            source.PlayOneShot(clip, volVelocity);
        }
    }

}
