using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    Animator animator;
    public string name;
    public int morale;
    public int productivity;
    public float workTimer = 10f;
    public float[] setTime;
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
    public int level;
    float duration = 20.0f;
    Renderer rend;
    public float lerp;
    public float check = 0.0f;
    bool change = false;
    bool change2 = false;
    private float[] workT;
    public GameObject player;
    public int workerNumber;
    private int below50;
    private bool below;
    private int brokenSpirit;
    private int money;
    private float saturationValue = 1f;
    private float targetSaturationValue = 1f;
    public AudioSource workerVoice;
    public AudioClip packageDone, bullyReaction, encourageReaction, lowMorale, lowProductivity, workingOnBox, fired, lowStats;
    private AudioSource managerSound;

    [SerializeField] int productivityFireThreshold;
    [SerializeField] int moraleFireThreshold;

    private int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        workT = new float[6];
        setTime = new float[6];
        level = player.GetComponent<Manager>().getWorkerLevel();
        workT[1] = 10f;
        workT[2] = 12f;
        workT[3] = 14f;
        workT[4] = 16f;
        workT[5] = 18f;
        setTime[1] = 15f;
        setTime[2] = 14f;
        setTime[3] = 13f;
        setTime[4] = 12f;
        setTime[5] = 11f;
        rend = GetComponent<Renderer>();
        counter = 0;
        moraleDecreaser = 1;
        productivityDecreaser = 2;
        morale = 100;
        productivity = 100;
        packageTimer = setTime[level];
        name = player.GetComponent<Manager>().getWorkerName();
        morale = player.GetComponent<Manager>().getWorkerMorale();
        productivity = player.GetComponent<Manager>().getWorkerProductivity();
        workerNumber = player.GetComponent<Manager>().getWorkerNumber();
        below50 = player.GetComponent<Manager>().getBelow50();
        brokenSpirit = player.GetComponent<Manager>().getBrokenSpirit();
        player.GetComponent<Manager>().generateWorker();
        managerSound = player.GetComponent<Manager>().managerAudio;
    }

    // Update is called once per frame
    void Update()
    {
        money = player.GetComponent<Manager>().getMoney();
        level = Mathf.Clamp(level, 1, 5);
        morale = Mathf.Clamp(morale, minX, maxX);
        productivity = Mathf.Clamp(productivity, minX, maxX);
        moraleDecreaser = Mathf.Clamp(moraleDecreaser, 1, 5);
        productivityDecreaser = Mathf.Clamp(productivityDecreaser, 1, 10);
        workTimer -= Time.deltaTime;
        saturationValue = Mathf.Lerp(saturationValue, ((float)productivity + (float)morale) / 200, 2f * Time.deltaTime);
        Debug.Log(saturationValue);
        rend.material.SetFloat("_Saturation", saturationValue);
        if (workTimer <= 0)
        {
            DecreaseMoraleTimer();
            workTimer = workT[level];
        }
        if (productivity <= productivityFireThreshold || morale < moraleFireThreshold)
        {
            if (below)
            {
                player.GetComponent<Manager>().setBelow50(below50--);
            }
            managerSound.clip = fired;
            managerSound.Play();
            player.GetComponent<Manager>().setMoney(money - 100);
            player.GetComponent<Manager>().setBrokenSpirit(brokenSpirit += 1);
            fire();
        }
        if (productivity <= 50 || morale <= 50 && !below)
        {
            below = true;
            player.GetComponent<Manager>().setBelow50(below50 + 1);
        }
        if (below)
        {
            if (!managerSound.isPlaying)
            {
                managerSound.clip = lowStats;
                managerSound.Play();
            }
        }
        if (productivity > 50 && morale > 50 && below)
        {
            below = false;
            player.GetComponent<Manager>().setBelow50(below50--);
        }
        if (working)
        {
            if (!workerVoice.isPlaying)
            {
                workerVoice.clip = workingOnBox;
                workerVoice.Play();
                workerVoice.loop = true;
            }
            packageTimer -= Time.deltaTime;
        }
        if (packageTimer <= 0)
        {
            workerVoice.Stop();
            workerVoice.loop = false;

            if (productivity >= 80)
            {
                if (!workerVoice.isPlaying)
                {
                    workerVoice.clip = packageDone;
                    workerVoice.Play();
                }
            }
            if (productivity >= 60 && productivity < 80)
            {
                if (!workerVoice.isPlaying)
                {
                    workerVoice.clip = lowProductivity;
                    workerVoice.Play();
                }
            }
            if (productivity >= 45 && productivity < 60)
            {
                if (!workerVoice.isPlaying)
                {
                    workerVoice.clip = lowProductivity;
                    workerVoice.Play();
                }
            }

            animator.SetBool("Working", false);
            package.tag = "Finished";
            working = false;
            m_collider.enabled = true;
            packageTimer = setTime[level];
            package.transform.position = returnPoint.position;
            packageFinish();
        }
        currentLevel = level;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            animator.SetBool("Working", true);
            package = other.gameObject;
            package.tag = "inProgress";
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
            workerVoice.loop = false;
            workerVoice.clip = bullyReaction;
            workerVoice.Play();
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
            workerVoice.loop = false;
            workerVoice.clip = encourageReaction;
            workerVoice.Play();
            counter++;
            morale += 3;
            productivity += 5;
        }
    }

    public void fire()
    {
        Manager.fireCounter++;
        player.GetComponent<Manager>().addNameToBoard(name, workerNumber);
        switch (workerNumber)
        {
            case 0:
                player.GetComponent<Manager>().fired0.SetActive(true);
                Destroy(gameObject);
                break;
            case 1:
                player.GetComponent<Manager>().fired1.SetActive(true);
                Destroy(gameObject);
                break;
            case 2:
                player.GetComponent<Manager>().fired2.SetActive(true);
                Destroy(gameObject);
                break;
            case 3:
                player.GetComponent<Manager>().fired3.SetActive(true);
                Destroy(gameObject);
                break;
            default:
                break;
        }
        Destroy(gameObject);
    }

    public int getMorale()
    {
        return morale;
    }

    public int setMorale(int newMorale)
    {
        morale = newMorale;
        return morale;
    }

    public int getProductivity()
    {
        return productivity;
    }

    public int setProductivity(int newProductivity)
    {
        productivity = newProductivity;
        return productivity;
    }

    public int getLevel()
    {
        return currentLevel;
    }

    public int setLevel(int newLevel)
    {
        level = newLevel;
        return level;
    }

    public string getName()
    {
        return name;
    }

    public void DecreaseMoraleTimer()
    {
        morale -= moraleDecreaser;
        productivity -= productivityDecreaser;
        Debug.Log("Morale: " + morale);
        Debug.Log("Productivity: " + productivity);
    }
}
