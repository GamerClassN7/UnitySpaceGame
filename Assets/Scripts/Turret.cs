using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public GameObject barrel;
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Aim();
        }
    }

    private void Aim()
    {
        //LEFT/RIGHT
        float targetPlaneAngle = Vector3AngleOnPlane(target.transform.position, transform.position, -transform.up, transform.forward);
        Vector3 newRotation = new Vector3(0, targetPlaneAngle, 0);
        transform.Rotate(newRotation, Space.Self);

        //UP/DOWN
        float upAngle = Vector3.Angle(target.transform.position, barrel.transform.up);
        Vector3 upRotation = new Vector3(-upAngle + 90, 0, 0);
        Debug.Log(upAngle);
        barrel.transform.Rotate(upRotation, Space.Self);
    }

    float Vector3AngleOnPlane(Vector3 from, Vector3 to, Vector3 planeNormal, Vector3 toZeroAngle)
    {
        Vector3 projectedVector = Vector3.ProjectOnPlane(from - to, planeNormal);
        float projectedVectorAngle = Vector3.SignedAngle(projectedVector, toZeroAngle, planeNormal);

        return projectedVectorAngle;
    }
}
