using UnityEngine;

public class Player_PickUP : MonoBehaviour
{
    
    public Camera cam;
    public float pickupDistance = 3f;
    public Transform holdPoint;

    private IPickup heldObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (heldObject == null)
                TryPickup();
            else
                Drop();
        }
    }

    void TryPickup()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickupDistance))
        {
            IPickup pickup = hit.collider.GetComponent<IPickup>();
            if (pickup != null)
            {
                heldObject = pickup;
                pickup.OnPickup(holdPoint);
            }
        }
    }

    void Drop()
    {
        if (heldObject != null)
        {
            heldObject.OnDrop();
            heldObject = null;
        }
    }
}
