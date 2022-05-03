using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Collider m_collider;
    public float checkTimer;
    public float resetTimer;
    bool on = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!on)
        {
            checkTimer -= Time.deltaTime;
        }
        if (checkTimer <= 0)
        {
            on = true;
            m_collider.enabled = true;
            checkTimer = resetTimer;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finished")
        {
            on = false;
            m_collider.enabled = false;
        }
    }
}
