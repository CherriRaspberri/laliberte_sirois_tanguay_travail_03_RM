using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip impactSound;
    //Prevents sound spamming from tiny movements
    public float velocityThreshold = 0.5f; 

    private void OnCollisionEnter(Collision collision)
    {
        //Only play if the object hits with enough force
        if (collision.relativeVelocity.magnitude > velocityThreshold)
        {
            //Adjust volume based on how hard it hit
            float volume = Mathf.Clamp01(collision.relativeVelocity.magnitude / 5f);
            audioSource.PlayOneShot(impactSound, volume);
        }
    }
}