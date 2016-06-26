using UnityEngine;
using System.Collections;

public class EdgeAudio : MonoBehaviour {

    public AudioClip edge;
    private AudioSource source;
    float volVelocity;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        volVelocity = col.relativeVelocity.magnitude * 0.1f;
        source.pitch = Random.Range(.75f, 1.2f);

        source.PlayOneShot(edge, volVelocity);
    }
}