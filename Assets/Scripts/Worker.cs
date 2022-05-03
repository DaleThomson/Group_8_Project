using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public string name;
    public int morale;
    public int productivity;
    public float workTimer = 10f;
    public float setTime = 15f;
    public GameObject package;
    public bool working = false;
    private Rigidbody packBody;
    public float packageTimer;
    public Transform packagePoint;
    public Transform returnPoint;
    public Collider m_collider;
    public int moraleDecreaser;
    public int productivityDecreaser;
    public int counter;
    public int minX = 0, maxX = 100;
    public Material material1;
    public Material material2;
    public Material material3;
    float duration = 20.0f;
    Renderer rend;
    public float lerp;
    public float check = 0.0f;
    bool change = false;
    bool change2 = false;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        counter = 0;
        moraleDecreaser = 1;
        productivityDecreaser = 2;
        morale = 100;
        productivity = 100;
        packageTimer = setTime;
        rend.material = material1;
    }

    // Update is called once per frame
    void Update()
    {
        morale = Mathf.Clamp(morale, minX, maxX);
        productivity = Mathf.Clamp(productivity, minX, maxX);
        moraleDecreaser = Mathf.Clamp(moraleDecreaser, 1, 5);
        productivityDecreaser = Mathf.Clamp(productivityDecreaser, 1, 10);
        workTimer -= Time.deltaTime;
        if (workTimer <= 0)
        {
            DecreaseMoraleTimer();
            workTimer = 10;
        }
        if (morale < 10 || productivity <= 0)
        {
            Destroy(gameObject);
        }
        if (working)
        {
            packageTimer -= Time.deltaTime;
        }
        if (packageTimer <= 0)
        {
            package.tag = "Finished";
            working = false;
            m_collider.enabled = true;
            packageTimer = setTime;
            package.transform.position = returnPoint.position;
            packageFinish();
        }
        if (productivity <= 75 && !change)
        {
            check += 0.01f;
            lerp = Mathf.PingPong(check, duration) / duration;
            rend.material.Lerp(material1, material2, lerp);
            if (lerp >= 0.99f)
            {
                check = 0;
                lerp = 0;
                rend.material = material2;
                change = true;
            }
        }
        if (productivity <= 40 && !change2)
        {
            check += 0.01f;
            lerp = Mathf.PingPong(check, duration) / duration;
            rend.material.Lerp(material2, material3, lerp);
            if (lerp >= 0.99f)
            {
                check = 0;
                lerp = 0;
                rend.material = material3;
                change2 = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            package = other.gameObject;
            package.transform.position = packagePoint.position;
            packBody = package.GetComponent<Rigidbody>();
            packBody.velocity = new Vector3(0, 0, 0);
            m_collider.enabled = !m_collider.enabled;
            working = true;
        }
    }

    public int returnMorale()
    {
        return morale;
    }

    public string returnName()
    {
        return name;
    }

    public int returnProductivity()
    {
        return productivity;
    }

    public void bully()
    {
        if (productivity < 100 && moraleDecreaser < 5)
        {
            moraleDecreaser++;
            productivity += 5;
            productivityDecreaser += 2;
        }
    }

    public void packageFinish()
    {
        morale -= 5;
        productivity -= 5;
    }

    public void encourage()
    {
        if (counter < 5 && morale < 100 & productivity < 100)
        {
            counter++;
            morale += 2;
            productivity += 5;
        }
    }

    public void fire()
    {
        Destroy(gameObject);
    }

    public void DecreaseMoraleTimer()
    {
        morale -= moraleDecreaser;
        productivity -= productivityDecreaser;
        Debug.Log("Morale: " + morale);
        Debug.Log("Productivity: " + productivity);
    }
}
