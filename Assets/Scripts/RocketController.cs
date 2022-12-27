using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnPoints;
    public TargetController targetController;
    public GameObject rocketPrefab;
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
            foreach (GameObject spawnPoint in spawnPoints)
            {
                GameObject rocket = Instantiate(rocketPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                rocket.transform.parent = playerContainer.transform;
                rocket.GetComponent<Rocket>().target = targetController.target;
            }
        }
    }
}
