using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 300f;

    public Transform body;          // Assign "Body"
    public Transform cameraPivot;   // Assign "CameraHolder"

    float verticalRot = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Horizontal on body
        body.Rotate(Vector3.up * mouseX);

        // Vertical on camera pivot
        verticalRot -= mouseY;
        verticalRot = Mathf.Clamp(verticalRot, -80f, 80f);

        cameraPivot.localRotation = Quaternion.Euler(verticalRot, 0f, 0f);
    }
}