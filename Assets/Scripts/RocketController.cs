using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnPoints;
    public TargetController targetController;
    private GameObject playerContainer;

    public bool fire = false;

    void Start()
    {
        playerContainer = GameObject.Find("=PROJECTILES=");
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            fire = true;
        }

        if (fire == true)
        {
            fire = false;
            Fire();
        }
    }

    private void Fire()
    {
        if (targetController.target != null && targetController.target.scene.IsValid())
        {
            foreach (GameObject rocketTube in spawnPoints)
            {
                if (rocketTube.gameObject.GetComponent<Weapon>() != null)
                {
                    GameObject rocket = Instantiate(rocketTube.gameObject.GetComponent<Weapon>().projectile, rocketTube.transform.position, rocketTube.transform.rotation);
                    rocket.transform.parent = playerContainer.transform;
                    rocket.GetComponent<Rocket>().target = targetController.target;
                }
            }
        }
    }
}
