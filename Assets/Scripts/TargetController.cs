using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TargetController : MonoBehaviour
{
    public GameObject target;
    public Slider targetHealthSlider;
    public TMP_Text targetHealthText;

    public CameraControl Camera;
    private Transform originalTarget;

    void Start()
    {
        originalTarget = Camera.cameraTarget;

        targetHealthSlider.minValue = 0.0f;
        targetHealthSlider.maxValue = 100.0f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null)
        {
            targetHealthSlider.gameObject.SetActive(false);
            targetHealthText.gameObject.SetActive(false);
            return;
        }

        targetHealthSlider.gameObject.SetActive(true);
        targetHealthText.gameObject.SetActive(true);

        if (target.scene.IsValid())
        {
            targetHealthSlider.value = target.GetComponent<Target>().HP;
            targetHealthText.text = target.GetComponent<Target>().Name;
        }
    }
}
