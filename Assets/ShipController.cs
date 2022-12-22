using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Transform thisShip;
    public Rigidbody r;
    //public Camera c;

    public float turnSpeed = 60f;
    public float boostSpeed = 45f;

    private void Start()
    {
        r = thisShip.GetComponent<Rigidbody>();
        r.useGravity = false;
    }

    private void FixedUpdate()
    {
        Turn();
        Trust();
    }

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Rotate");

        thisShip.Rotate(pitch, yaw, roll);
    }

    void Trust()
    {
        thisShip.position += thisShip.forward * boostSpeed * Time.deltaTime * Input.GetAxis("Trottle");
    }
}
