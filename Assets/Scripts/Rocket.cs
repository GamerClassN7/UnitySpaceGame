using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [Range(0.00f, 100.0f)]
    public float speed = 0.0f;
    public GameObject target;
    public float damage = 30.0f;

    void Start()
    {
        IEnumerator coroutine = Homing(this.gameObject);
        StartCoroutine(coroutine);
    }

    void Update()
    {

    }

    public IEnumerator Homing(GameObject rocket)
    {
        yield return new WaitForSeconds(0.3f);

        while (target != null && Vector3.Distance(target.transform.position, rocket.transform.position) > 0.3)
        {
            rocket.transform.position += (target.transform.position - rocket.transform.position).normalized * speed * Time.deltaTime;
            rocket.transform.LookAt(target.transform);

            Debug.DrawLine(rocket.transform.position, target.transform.position);

            yield return null;
        }

        if (target != null)
        {
            target.GetComponent<Target>().HP -= damage;
        }

        Destroy(rocket);
    }
}
