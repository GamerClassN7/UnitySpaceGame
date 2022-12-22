using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float HP = 100.0f;
    public string Name = "Goliáš";
    public TargetType type = new TargetType();

    public TargetController TargetController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnMouseDown()
    {
        Debug.Log("Clicked");

        HP -= 10.0f;
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
            return;
        }
    }
}

public enum TargetType
{
    Asteroid,
    EnemyShip
};
