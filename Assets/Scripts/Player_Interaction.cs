using UnityEngine;
using UnityEngine.UI;
using TMPro;

public interface IInteractable
{
    void Interact();
}

public interface IPickup
{
    string DisplayName { get; }
    void OnPickup(Transform holdPoint);
    void OnDrop();
}

public class Player_Interaction : MonoBehaviour
{
    public Camera playerCam;
    public float interactDistance = 3f;

    public RawImage interactIcon;
    public TextMeshProUGUI interactText;

    public Transform holdPoint;      // added to player!

    private IInteractable currentInteractable;
    private IPickup currentPickup;

    private IPickup heldObject = null;

    void Update()
    {
        UpdateLookAt();

        // E → Interact
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }

        // Q → Pick up or drop
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TryPickupOrDrop();
        }
    }

    void UpdateLookAt()
    {
        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        RaycastHit hit;

        currentInteractable = null;
        currentPickup = null;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            currentInteractable = hit.collider.GetComponent<IInteractable>();
            currentPickup = hit.collider.GetComponent<IPickup>();
        }

        // If already holding something → no pickup text
        if (heldObject != null)
        {
            interactText.enabled = false;
            interactIcon.enabled = false;
            return;
        }

        // Show UI
        bool lookingAtSomething = currentInteractable != null || currentPickup != null;
        interactIcon.enabled = lookingAtSomething;

        if (currentPickup != null)
        {
            interactText.enabled = true;
            interactText.text = $"Press Q to pick up {currentPickup.DisplayName}";
        }
        else if (currentInteractable != null)
        {
            interactText.enabled = true;
            interactText.text = "Press E to interact";
        }
        else
        {
            interactText.enabled = false;
        }
    }

    void TryInteract()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void TryPickupOrDrop()
    {
        // Drop if already holding something
        if (heldObject != null)
        {
            heldObject.OnDrop();
            heldObject = null;
            return;
        }

        // Pick up if looking at pickup object
        if (currentPickup != null)
        {
            heldObject = currentPickup;
            heldObject.OnPickup(holdPoint);
        }
    }
}