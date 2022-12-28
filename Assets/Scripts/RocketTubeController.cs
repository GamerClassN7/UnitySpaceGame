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
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Init RocketTubes");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //Fire();
        }
        Debug.Log("Update RocketTubes");
        foreach (GameObject rocketTube in rocketTubes)
        {
            Debug.Log(rocketTube.name);

        }
    }

    private void Fire()
    {
        Debug.Log("Fire Rocket");
        if (targetController.target != null && targetController.target.scene.IsValid())
        {
            foreach (GameObject rocketTube in rocketTubes)
            {
                // Debug.Log("Spawn Rocket");
                // Debug.Log(rocketTube.GetComponent<RocketTube>().spawnPoint.transform);

                // Transform SpawnPoint = rocketTube.GetComponent<RocketTube>().spawnPoint.transform;
                // GameObject rocket = Instantiate(weapon.projectile, rocketTube.transform.position, rocketTube.transform.rotation);
                // rocket.transform.parent = playerContainer.transform;
                // rocket.GetComponent<Rocket>().target = targetController.target;
            }
        }
    }
}
