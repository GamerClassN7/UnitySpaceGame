using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float HP = 100.0f;
    public string Name = "Goliáš";
    public TargetType type = new TargetType();

    private TargetController TargetController;

    // Start is called before the first frame update
    void Start()
    {
        TargetController = GameObject.Find("Ship").GetComponent<TargetController>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        Debug.Log("Clicked");
        TargetController.target = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Camera.cameraTarget = originalTarget.GetComponent<Transform>();
        }

        if (HP <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
}

public enum TargetType
{
    Asteroid,
    EnemyShip,
    Test
};
