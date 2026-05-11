using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trial_book_script : MonoBehaviour
{
    public HingeJoint bookHinge;
    public Animator targetAnimator;
    public string triggerName;
    
    private bool hasTriggered = false;

    void Update()
    {
        //Checks if the angle is very close to the limit
        //hinge.angle returns the current rotation relative to the start position
        if (!hasTriggered && bookHinge.angle >= bookHinge.limits.max - 1f)
        {
            //Sets trigger for animation
            targetAnimator.SetTrigger(triggerName);
            //Prevents the animation from firing every frame
            hasTriggered = true; 
            Debug.Log("Book Opened: Animation Triggered!");
        }
    }
}
