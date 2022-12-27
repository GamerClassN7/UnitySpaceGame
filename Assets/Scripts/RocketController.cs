using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public TargetController targetController;

    [SerializeField]
    private GameObject[] spawnPoints;

    public GameObject rocketPrefab;

    private GameObject playerContainer;


    [Range(0.00f, 30.0f)]
    public float speed = 0.0f;

    public bool fire = false;

    void Start()
    {
        playerContainer = GameObject.Find("=PLAYER=");
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
                //rocket.transform.LookAt(targetController.target.transform);
                rocket.transform.parent = playerContainer.transform;

                IEnumerator coroutine = Homing(rocket);
                StartCoroutine(coroutine);
            }
        }
    }

    public IEnumerator Homing(GameObject rocket)
    {
        yield return new WaitForSeconds(0.3f);

        while (targetController.target != null && Vector3.Distance(targetController.target.transform.position, rocket.transform.position) > 0.3)
        {
            rocket.transform.position += (targetController.target.transform.position - rocket.transform.position).normalized * speed * Time.deltaTime;
            rocket.transform.LookAt(targetController.target.transform);
            yield return null;
        }

        if (targetController.target != null)
        {
            targetController.target.GetComponent<Target>().HP -= 10.0f;
        }

        Destroy(rocket);
    }
}
