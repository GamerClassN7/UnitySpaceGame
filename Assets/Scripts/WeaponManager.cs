using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weapons;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        weapons[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
