using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public Transform hinge;   // Assign the "Hinge" child in Inspector
    private bool isOpen = false;

    public float openAngle = 90f;   // customizable
    public float closedAngle = 0f;

    public void Interact()
    {
        if (hinge == null)
        {
            Debug.LogWarning("Door has no hinge assigned!");
            return;
        }

        isOpen = !isOpen;
        float angle = isOpen ? openAngle : closedAngle;

        hinge.localRotation = Quaternion.Euler(0, angle, 0);

        Debug.Log("Door toggled!");
    }
}