using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    float m_thrust = 20f;
    bool conveyor = false;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Conveyor")
        {
            conveyor = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(conveyor)
        {
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            m_Rigidbody.AddForce(transform.forward * m_thrust);
        }
    }
}
