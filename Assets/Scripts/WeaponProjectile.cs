using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    public float damage = 5.0f;
    public float tileToLive = 2000.0f;
    public ParticleSystem explosionEffect;
    void Start()
    {

    }

    void Update()
    {
        Destroy(this.gameObject, tileToLive);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>() != null)
        {
            explosionEffect.Play(true);

            collision.gameObject.GetComponent<Target>().HP -= damage;

            Destroy(this.gameObject);
        }
    }
}
