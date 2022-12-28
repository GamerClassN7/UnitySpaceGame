using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTubeController : MonoBehaviour
{
    [SerializeField]
    public GameObject[] rocketTubes;
    public TargetController targetController;
    private GameObject playerContainer;
    public Weapon weapon;

    void Start()
    {
        playerContainer = GameObject.Find("=PROJECTILES=");
    }

    public void Fire()
    {
        Debug.Log("Fire Rocket");
        if (targetController.target != null && targetController.target.scene.IsValid())
        {
            foreach (GameObject rocketTube in rocketTubes)
            {
                Debug.Log("Spawn Rocket");
                Debug.Log(rocketTube.GetComponent<RocketTube>().spawnPoint.transform);

                Transform SpawnPoint = rocketTube.GetComponent<RocketTube>().spawnPoint.transform;
                GameObject rocket = Instantiate(weapon.projectile, SpawnPoint.position, SpawnPoint.rotation);
                rocket.transform.parent = playerContainer.transform;
                rocket.GetComponent<Rocket>().target = targetController.target;
            }
        }
    }
}
