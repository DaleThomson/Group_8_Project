using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    float m_thrust = 20f;
    bool conveyorN = false;
    bool conveyorE = false;
    bool conveyorS = false;
    bool conveyorW = false;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ConveyorN")
        {
            conveyorN = true;
        }
        if (other.tag == "ConveyorE")
        {
            conveyorE = true;
        }
        if (other.tag == "ConveyorS")
        {
            conveyorS = true;
        }
        if (other.tag == "ConveyorW")
        {
            conveyorW = true;
        }
    }

    private void OnTriggerExit()
    {
        conveyorN = false;
        conveyorE = false;
        conveyorS = false;
        conveyorW = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (conveyorN)
        {
            m_Rigidbody.rotation = Quaternion.identity;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            m_Rigidbody.AddForce(transform.forward * m_thrust);
        }
        if (conveyorE)
        {
            m_Rigidbody.rotation = Quaternion.identity;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            m_Rigidbody.AddForce(transform.right * m_thrust);
        }
        if (conveyorS)
        {
            m_Rigidbody.rotation = Quaternion.identity;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            m_Rigidbody.AddForce(transform.forward * -m_thrust);
        }
        if (conveyorW)
        {
            m_Rigidbody.rotation = Quaternion.identity;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            m_Rigidbody.AddForce(transform.right * -m_thrust);
        }
    }
}
