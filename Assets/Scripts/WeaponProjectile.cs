using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    public float damage = 5.0f;
    public float tileToLive = 2000.0f;
    public ParticleSystem explosionEffect;


    //Turn off collider on launch
    //private float timer = 0f;
    private bool oneTime = true;
    //
    void Start()
    {
        //this.gameObject.GetComponent<Collider>().enabled = false;
    }

    void Update()
    {
        // if (timer < Time.time)
        // {
        //     if (oneTime == true)
        //     {
        //         oneTime = false;
        //         this.gameObject.GetComponent<Collider>().enabled = true;
        //     }
        // }
        // else
        // {
        if (tileToLive > 0)
        {
            Destroy(this.gameObject, tileToLive);
        }
        //}
    }

    void OnCollisionEnter(Collision collision)
    {
        explosionEffect.Play(true);

        if (collision.gameObject.GetComponent<Target>() != null)
        {
            collision.gameObject.GetComponent<Target>().HP -= damage;
        }
        else
        {
            GetShipController(collision).HP -= damage;
        }


        Destroy(this.gameObject);
        Debug.Log(collision.gameObject.name);
    }

    private ShipController GetShipController(Collision collision)
    {
        Transform t = collision.gameObject.transform;
        while (t.transform.parent != null)
        {
            if (t.gameObject.GetComponent<ShipController>() != null)
            {
                Debug.Log("Ship Controller Found");
                return t.gameObject.GetComponent<ShipController>();
            }
            t = t.transform.parent;
        }

        return null;
    }
}

