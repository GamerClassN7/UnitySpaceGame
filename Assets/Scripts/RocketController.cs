using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public TargetController targetController;
    public GameObject spawnPoint;
    public GameObject rocketPrefab;

    [Range(0.00f, 10.0f)]
    public float speed = 0.0f;

    public bool fire = false;

    void Update()
    {
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

            GameObject rocket = Instantiate(rocketPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            rocket.transform.LookAt(targetController.target.transform);

            IEnumerator coroutine = Homing(rocket);
            StartCoroutine(coroutine);
        }
    }
    public IEnumerator Homing(GameObject rocket)
    {
        while (Vector3.Distance(targetController.target.transform.position, rocket.transform.position) > 0.3f)
        {
            rocket.transform.position += (targetController.target.transform.position - rocket.transform.position).normalized * speed * Time.deltaTime;
            rocket.transform.LookAt(targetController.target.transform);
            yield return null;
        }
        Destroy(rocket);
    }
}
