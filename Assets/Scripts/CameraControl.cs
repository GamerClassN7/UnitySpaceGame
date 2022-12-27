using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform cameraTarget;
    private Vector3 cameraOffset;
    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

    public float rotationSpeed = 5.0f;
    public bool mouseButtonLeftHeld = false;

    private float cameraRotationX;
    private float cameraRotationY;

    void Start()
    {
        cameraOffset = transform.position - cameraTarget.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Pressed right preset.");
            mouseButtonLeftHeld = true;
        }
        else if (mouseButtonLeftHeld == true && Input.GetMouseButtonUp(1))
        {
            Debug.Log("Pressed right released.");
            mouseButtonLeftHeld = false;
        }
        RotateCameraAround(mouseButtonLeftHeld);
    }

    private void RotateCameraAround(bool rotateAroundPlayer = false)
    {
        if (rotateAroundPlayer)
        {
            Quaternion cameraTurnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            cameraOffset = cameraTurnAngleX * cameraOffset;

            Quaternion cameraTurnAngleY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * rotationSpeed, (Vector3.left * -1));
            cameraOffset = cameraTurnAngleY * cameraOffset;
        }

        Vector3 newPosition = (cameraTarget.position + cameraOffset);
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);

        if (rotateAroundPlayer)
        {
            transform.LookAt(cameraTarget);
        }
    }
}
