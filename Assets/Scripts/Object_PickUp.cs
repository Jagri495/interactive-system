using UnityEngine;

public class Object_PickUp : MonoBehaviour, IPickup
{
    private Rigidbody rb;
    private Collider col;
    public string DisplayName => "Pills";

    private bool beingHeld = false;
    private Transform holdPoint;

    public float moveSpeed = 15f;
    public LayerMask collisionMask;   // Assign “Default” only, exclude HeldObject layer

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    void Update()
    {
        if (!beingHeld) return;

        Vector3 targetPos = holdPoint.position;

        // prevent clipping
        if (Physics.Linecast(transform.position, holdPoint.position, out RaycastHit hit, collisionMask))
        {
            targetPos = hit.point - holdPoint.forward * 0.15f;
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, holdPoint.rotation, moveSpeed * Time.deltaTime);
    }

    public void OnPickup(Transform holdPoint)
    {
        this.holdPoint = holdPoint;
        beingHeld = true;

        rb.isKinematic = true;
        rb.useGravity = false;
        gameObject.layer = LayerMask.NameToLayer("HeldObject");  // IGNORE collision
    }

    public void OnDrop()
    {
        beingHeld = false;

        rb.isKinematic = false;
        rb.useGravity = true;
        gameObject.layer = 0; // Default layer

        rb.AddForce(holdPoint.forward * 1.5f, ForceMode.Impulse);
    }
}
