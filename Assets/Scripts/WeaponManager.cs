using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weapons;
    private int weaponIndex = 0;
    public GameObject weaponImage;
    public GameObject weaponText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0.0f)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0.0f && weaponIndex < (weapons.Length - 1))
            {
                weaponIndex++;
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0.0f && weaponIndex > 0)
            {
                weaponIndex--;
            }
            Debug.Log("WEAPON_" + weaponIndex);
        }
        selectWeapon(weaponIndex);

        if (Input.GetButtonDown("Jump"))
        {
            if (weapons[weaponIndex].GetComponent<RocketTubeController>() != null)
            {
                weapons[weaponIndex].GetComponent<RocketTubeController>().Fire();
            }
            else if (weapons[weaponIndex].GetComponent<MineLauncherController>() != null)
            {
                weapons[weaponIndex].GetComponent<MineLauncherController>().Fire();
            }
            else if (weapons[weaponIndex].GetComponent<TurretController>() != null)
            {
                weapons[weaponIndex].GetComponent<TurretController>().Fire();
            }
            Debug.Log("WEAPON_" + weaponIndex + "_FIRE");
        }
    }

    private void selectWeapon(int index)
    {
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        weapons[index].SetActive(true);

        if (weapons[index].GetComponent<Weapon>().thumbnail != null)
        {
            weaponImage.GetComponent<RawImage>().texture = weapons[index].GetComponent<Weapon>().thumbnail;
            weaponText.GetComponent<TMP_Text>().text = weapons[index].GetComponent<Weapon>().ammo.ToString();
            return;
        }

        weaponImage.GetComponent<RawImage>().texture = null;
        weaponText.GetComponent<TMP_Text>().text = "";
    }
}
