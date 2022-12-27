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

    void Start()
    {
        cameraOffset = transform.position - cameraTarget.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        RotateCameraAround(Input.GetMouseButton(1));
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
