using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineLauncherController : MonoBehaviour
{
    [SerializeField]
    public GameObject[] mineLaunchers;
    public TargetController targetController;
    private GameObject playerContainer;
    public Weapon weapon;

    void Start()
    {
        playerContainer = GameObject.Find("=PROJECTILES=");
    }

    public void Fire()
    {
        Debug.Log("Mine Launched");
        foreach (GameObject mineLauncher in mineLaunchers)
        {
            Debug.Log("Mine Spawned");
            Debug.Log(mineLauncher.GetComponent<MineLauncher>().spawnPoint.transform);

            Transform SpawnPoint = mineLauncher.GetComponent<MineLauncher>().spawnPoint.transform;
            GameObject rocket = Instantiate(weapon.projectile, SpawnPoint.position, SpawnPoint.rotation);
            rocket.transform.parent = playerContainer.transform;
        }
    }
}
