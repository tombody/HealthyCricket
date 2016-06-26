using UnityEngine;
using System.Collections;

public class BailsBowledAudio : MonoBehaviour {

    public AudioClip bailsBowled;
    private AudioSource source;
    float volVelocity;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        volVelocity = col.relativeVelocity.magnitude * 0.3f;
        source.pitch = Random.Range(.75f, 1.2f);

        source.PlayOneShot(bailsBowled, volVelocity);
    }
}
