using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public int morale;
    public int productivity;
    public Timer workTimer = 10;
    // Start is called before the first frame update
    void Start()
    {
        morale = 100;
        productivity = 100;
    }

    // Update is called once per frame
    void Update()
    {
        workTimer -= Time.deltaTime;
        if (workTimer <= 0)
        {
            DecreaseMoraleTimer();
            workTimer = 10;
        }
    }

    public void ReduceMorale()
    {
        morale -= 10;
        productivity += 10;
        Debug.Log("Morale: " + morale);
        Debug.Log("Productivity: " + productivity);
    }

    public void IncreaseMorale()
    {
        morale += 10;
        productivity += 10;
        Debug.Log("Morale: " + morale);
        Debug.Log("Productivity: " + productivity);
    }

    public void DecreaseMoraleTimer()
    {
        morale -= 1;
        productivity -= 1;
        Debug.Log("Morale: " + morale);
        Debug.Log("Productivity: " + productivity);
    }
}
