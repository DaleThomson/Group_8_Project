using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public int morale;
    public int productivity;
    // Start is called before the first frame update
    void Start()
    {
        morale = 100;
        productivity = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceMorale()
    {
        morale -= 10;
        productivity += 10;
        Debug.Log("Morale: " + morale);
        Debug.Log("Productivity: " + productivity);
    }
}
