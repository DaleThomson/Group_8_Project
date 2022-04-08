using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float sizeX = transform.GetComponent<MeshRenderer>().bounds.size.x;
        float sizeY = transform.GetComponent<MeshRenderer>().bounds.size.y;
        Debug.Log("X: " + sizeX + "Y: " + sizeY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
