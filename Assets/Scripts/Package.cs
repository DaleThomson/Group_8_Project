using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_thrust = 20f;
    public Transform teleporterNExit;
    public Transform teleporterWExit;
    public Transform teleporterEExit;
    public Transform teleporterSExit;
    public static bool full1 = false;
    bool conveyorN = false;
    bool conveyorE = false;
    bool conveyorS = false;
    bool conveyorSE = false;
    bool conveyorW = false;
    public GameObject package;
    public Transform spawnLocation;
    public GameObject player;
    private int money;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        money = player.GetComponent<Manager>().returnMoney();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ConveyorN")
        {
            m_Rigidbody.velocity = new Vector3(0, 0, 0);
            conveyorN = true;
        }
        if (other.tag == "ConveyorE")
        {
            m_Rigidbody.velocity = new Vector3(0, 0, 0);
            conveyorE = true;
        }
        if (other.tag == "ConveyorS")
        {
            m_Rigidbody.velocity = new Vector3(0, 0, 0);
            conveyorS = true;
        }
        if (other.tag == "ConveyorW")
        {
            m_Rigidbody.velocity = new Vector3(0, 0, 0);
            conveyorW = true;
        }
        if (other.tag == "ConveyorSE")
        {
            m_Rigidbody.velocity = new Vector3(0, 0, 0);
            conveyorSE = true;
        }
        if (other.tag == "Point1" && !full1)
        {
            full1 = true;
            m_Rigidbody.velocity = new Vector3(0, 0, 0);
            conveyorN = true;
        }
        //if (other.tag == "TeleporterN")
        //{
        //    teleporterNExit = GameObject.Find("TeleporterNExit").transform;
        //    gameObject.transform.position = teleporterNExit.position;
        //    m_Rigidbody.velocity = new Vector3(0, 0, 0);
        //}
        if (other.tag == "TeleporterN" && gameObject.tag == "Finished")
        {
            GameObject clone = (GameObject)Instantiate(package, spawnLocation.position, Quaternion.identity);
            clone.tag = "Grabbable";
            player.GetComponent<Manager>().setMoney(money += 50);
            player.GetComponent<Manager>().packageCounter++;
            Destroy(gameObject);
        }
        if (other.tag == "TeleporterN" && gameObject.tag == "Grabbable")
        {
            GameObject clone = (GameObject)Instantiate(package, spawnLocation.position, Quaternion.identity);
            clone.tag = "Grabbable";
            player.GetComponent<Manager>().failedPackageCounter++;
            Destroy(gameObject);
        }
        if (other.tag == "TeleporterW")
        {
            teleporterWExit = GameObject.Find("TeleporterWExit").transform;
            gameObject.transform.position = teleporterWExit.position;
            m_Rigidbody.velocity = new Vector3(0, 0, 0);
        }
        if (other.tag == "TeleporterW" && gameObject.tag == "Finished")
        {
            Destroy(gameObject);
        }
        if (other.tag == "TeleporterE")
        {
            teleporterEExit = GameObject.Find("TeleporterEExit").transform;
            gameObject.transform.position = teleporterEExit.position;
            m_Rigidbody.velocity = new Vector3(0, 0, 0);
        }
        if (other.tag == "TeleporterE" && gameObject.tag == "Finished")
        {
            Destroy(gameObject);
        }
        if (other.tag == "TeleporterS")
        {
            teleporterSExit = GameObject.Find("TeleporterSExit").transform;
            gameObject.transform.position = teleporterSExit.position;
            m_Rigidbody.velocity = new Vector3(0, 0, 0);
        }
        if (other.tag == "TeleporterS" && gameObject.tag == "Finished")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
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
        if (other.tag == "ConveyorSE")
        {
            conveyorSE = true;
        }
        if (other.tag == "ConveyorW")
        {
            conveyorW = true;
        }
        if (other.tag == "Point1")
        {
            full1 = true;
            m_Rigidbody.velocity = new Vector3(0, 0, 0);
            conveyorE = false;
            conveyorN = true;
        }
    }

    private void OnTriggerExit()
    {
        conveyorN = false;
        conveyorE = false;
        conveyorS = false;
        conveyorW = false;
        conveyorSE = false;
        full1 = false;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (conveyorN)
        {
            m_Rigidbody.rotation = Quaternion.identity;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            m_Rigidbody.AddForce(transform.forward * m_thrust * 20);
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
        if (conveyorSE)
        {

            m_Rigidbody.rotation = Quaternion.identity;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            m_Rigidbody.AddForce(transform.forward * -17.75f);
            m_Rigidbody.AddForce(transform.right * m_thrust);
        }
        if (conveyorW)
        {
            m_Rigidbody.rotation = Quaternion.identity;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            m_Rigidbody.AddForce(transform.right * -m_thrust);
        }
    }
}
