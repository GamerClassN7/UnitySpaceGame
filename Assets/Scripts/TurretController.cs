using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] turrets;
    public TargetController targetController;
    public Weapon weapon;

    // Update is called once per frame
    void LateUpdate()
    {
        foreach (GameObject turret in turrets)
        {
            turret.GetComponent<Turret>().target = targetController.target;
            turret.GetComponent<Turret>().weapon = weapon;
            if (targetController.target == null)
            {
                turret.GetComponent<Turret>().fire = false;
            }
        }

    }

    public void Fire()
    {
        foreach (GameObject turret in turrets)
        {
            turret.GetComponent<Turret>().fire = true;
        }
    }
}
