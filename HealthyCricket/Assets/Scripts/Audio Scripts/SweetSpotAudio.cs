using UnityEngine;
using System.Collections;

public class SweetSpotAudio : MonoBehaviour {

    public AudioClip sweetSpot;
    private AudioSource source;
    float volVelocity;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        volVelocity = col.relativeVelocity.magnitude * 0.5f;
        source.pitch = Random.Range(.75f, 1.2f);

        source.PlayOneShot(sweetSpot, volVelocity);
    }
}
