using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trial_book_script : MonoBehaviour
{
    public HingeJoint bookHinge;
    public Animator targetAnimator;
    public string triggerName;
    
    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip doorOpenSound;

    private bool hasTriggered = false;

    void Update()
    {
        //Checks if the angle is very close to the limit
        if (!hasTriggered && bookHinge.angle >= bookHinge.limits.max - 1f)
        {
            //Sets trigger for animation
            targetAnimator.SetTrigger(triggerName);

            //PLAY SOUND HERE
            if (audioSource != null && doorOpenSound != null)
            {
                audioSource.PlayOneShot(doorOpenSound);
            }

            //Prevents the animation and sound from firing every frame
            hasTriggered = true; 
            Debug.Log("Book Opened: Animation and Sound Triggered!");
        }
    }
}
