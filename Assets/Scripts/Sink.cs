using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour, IInteractable
{
    private List<ISinkable> objectsInSink = new List<ISinkable>();

    public void Interact()
    {
        foreach (ISinkable obj in objectsInSink)
        {
            obj.BecomeWet();
        }

        Debug.Log("Sink used → Wet state applied!");
    }

    private void OnTriggerEnter(Collider other)
    {
        ISinkable sinkable = other.GetComponentInParent<ISinkable>();
        if (sinkable != null && !objectsInSink.Contains(sinkable))
        {
            objectsInSink.Add(sinkable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ISinkable sinkable = other.GetComponentInParent<ISinkable>();
        if (sinkable != null)
        {
            objectsInSink.Remove(sinkable);
        }
    }
}
