using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFootstepsSystem : MonoBehaviour
{
    private AudioSource audioSource;
    private Rigidbody rb;

    public AudioClip[] footstepSounds;

    private float stepTimer;

    public float stepInterval = 0.5f;
    public float minVelocity = 0.1f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        stepTimer = 0f;
    }

    void Update()
    {
        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (horizontalVelocity.magnitude > minVelocity)
        {
            stepTimer += Time.deltaTime;

            if (stepTimer >= stepInterval)
            {
                PlayFootstep();
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = stepInterval; // resetuj, ¿eby od razu zagra³ przy kolejnym ruchu
        }
    }

    void PlayFootstep()
    {
        if (footstepSounds.Length == 0) return;

        AudioClip clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
        audioSource.PlayOneShot(clip);
    }
}
