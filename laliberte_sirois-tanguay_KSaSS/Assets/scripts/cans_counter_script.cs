using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class CanCounter : MonoBehaviour
{
    public int requiredCans = 6;
    private int currentCans = 0;
    
    public UnityEvent onCollectionComplete;

    // This is the function the Socket will call
    public void AddCan(SelectEnterEventArgs args)
    {
        //Gets the object that was just put in the socket
        GameObject can = args.interactableObject.transform.gameObject;

        //Hides the can so the socket is empty again
        can.SetActive(false);

        //Counts it
        currentCans++;
        Debug.Log("Cans collected: " + currentCans + " / " + requiredCans);

        //Checks if the count is equal to the threshold
        if (currentCans >= requiredCans)
        {
            onCollectionComplete.Invoke();
        }
    }
}