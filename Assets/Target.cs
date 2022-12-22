using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public CameraControl Camera;
    private Transform originalTarget;

    // Start is called before the first frame update
    void Start()
    {
        originalTarget = Camera.cameraTarget;
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        Debug.Log("Clicked");
        Camera.cameraTarget = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Camera.cameraTarget = originalTarget.GetComponent<Transform>();
        }
    }
}
