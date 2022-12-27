using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    public Transform thisShip;
    public Slider throttleSlider;
    public GameObject trusters;
    public float HP = 100.0f;
    public Slider healthSlider;
    public Rigidbody r;
    //public Camera c;

    public float turnSpeed = 60f;
    public float boostSpeed = 45f;

    [Range(0.00f, 1.0f)]
    public float throttle = 0.0f;

    private void Start()
    {
        r = thisShip.GetComponent<Rigidbody>();
        r.useGravity = false;

        throttleSlider.minValue = 0.0f;
        throttleSlider.maxValue = 1.0f;

        healthSlider.minValue = 0.0f;
        healthSlider.maxValue = HP;
    }

    private void FixedUpdate()
    {
        Turn();
        Trust();
        healthSlider.value = HP;
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
        if (Input.GetAxis("Trottle") > 0 && throttle < 1.0f)
        {
            throttle += 1.0f * Time.deltaTime;
        }
        else if (Input.GetAxis("Trottle") < 0 && throttle > 0.0f)
        {
            throttle -= 1.0f * Time.deltaTime;
        }
        else if (throttle > 1.0f)
        {
            throttle = 1.0f;
        }
        else if (throttle < 0.0f)
        {
            throttle = 0.0f;
        }


        else if (throttle == 0.0f)
        {
            trusters.SetActive(false);
        }
        else
        {
            trusters.SetActive(true);
        }

        throttleSlider.value = throttle;
        thisShip.position += thisShip.forward * throttle * boostSpeed * Time.deltaTime;
    }
}
