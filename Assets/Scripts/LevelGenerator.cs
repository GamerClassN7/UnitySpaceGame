using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public int numberOfObjects = 30;
    public float fieldRadius = 100.0f;
    [SerializeField]
    private GameObject[] enviromentElements;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject SelectedElement = enviromentElements[Random.Range(0, enviromentElements.Length)];
            GameObject newElement = Instantiate(SelectedElement, Random.insideUnitSphere * fieldRadius, Random.rotation);
            newElement.name += (SelectedElement.name + "_" + i);
            newElement.transform.parent = this.gameObject.transform;
            newElement.GetComponent<Target>().Name = (SelectedElement.name + "_" + i);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
