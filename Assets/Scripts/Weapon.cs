using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string Name;
    public Texture thumbnail;
    public GameObject projectile;
    public float speed = 20.0f;
    private GameObject playerContainer;


    void Start()
    {
        playerContainer = GameObject.Find("=PROJECTILES=");
    }
    public void Fire(Transform spawnPoint, GameObject target)
    {
        GameObject newProjectile = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);

        if (newProjectile.GetComponent<Turret>() != null)
        {
            newProjectile.GetComponent<Turret>().target = target;
        }
        else if (newProjectile.GetComponent<Rocket>() != null)
        {
            newProjectile.GetComponent<Rocket>().target = target;
        }

        newProjectile.transform.parent = playerContainer.transform;
        newProjectile.GetComponent<Rigidbody>().velocity = spawnPoint.transform.TransformDirection(Vector3.forward * speed);
    }
}
