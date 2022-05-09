using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{

    public GameObject lineWorker1;
    public GameObject lineWorker2;
    public GameObject lineWorker3;
    public GameObject lineWorker4;

    private GameObject lineWorker1Instance;
    private GameObject lineWorker2Instance;
    private GameObject lineWorker3Instance;
    private GameObject lineWorker4Instance;

    public GameObject deliveryWorker;
    private GameObject deliveryWorker1;
    private GameObject deliveryWorker2;
    private GameObject deliveryWorker3;
    private GameObject deliveryWorker4;

    public Transform lineWorkerPos1;
    public Transform lineWorkerPos2;
    public Transform lineWorkerPos3;
    public Transform lineWorkerPos4;
    public Transform deliveryWorkerPos1;
    public Transform deliveryWorkerPos2;
    public Transform deliveryWorkerPos3;
    public Transform deliveryWorkerPos4;

    private int lineWorkerCount = 0;
    private int deliveryWorkerCount = 0;

    public int money;
    public int fireCounter;
    public Text moneyText;
    public TextMeshProUGUI employeeText;
    int workerNumber;
    GameObject CSV;
    string workerName;
    int randomWorker;

    // Start is called before the first frame update
    void Start()
    {
        CSV = GameObject.Find("/CSV");
        money = 500;
        lineWorker1Instance = Instantiate(lineWorker1, lineWorkerPos1);
        lineWorkerCount++;
    }

    // Update is called once per frame
    void Update()
    {
        if (fireCounter >= 10)
        {
            Application.Quit();
            Debug.Log("Exit");
        }
        moneyText.text = "Money: £" + money;
    }

    public void hireLineWorker()
    {
        if (money >= 100)
        {
            if (lineWorkerCount < 4)
            {
                switch (lineWorkerCount)
                {
                    case 0:
                        lineWorker1Instance = Instantiate(lineWorker1, lineWorkerPos1);
                        lineWorkerCount++;
                        money -= 100;
                        break;
                    case 1:
                        lineWorker2Instance = Instantiate(lineWorker2, lineWorkerPos2);
                        lineWorkerCount++;
                        money -= 100;
                        break;
                    case 2:
                        lineWorker3Instance = Instantiate(lineWorker3, lineWorkerPos3);
                        lineWorkerCount++;
                        money -= 100;
                        break;
                    case 3:
                        lineWorker4Instance = Instantiate(lineWorker4, lineWorkerPos4);
                        lineWorkerCount++;
                        money -= 100;
                        break;
                }
            }
        }

        if (lineWorkerCount == 4)
        {
            switch (lineWorkerCount)
            {
                case 4:
                    if (lineWorker1Instance == null)
                    {
                        lineWorker1Instance = Instantiate(lineWorker1, lineWorkerPos1);
                        break;
                    }
                    if (lineWorker2Instance == null)
                    {
                        lineWorker2Instance = Instantiate(lineWorker2, lineWorkerPos2);
                        break;
                    }
                    if (lineWorker3Instance == null)
                    {
                        lineWorker3Instance = Instantiate(lineWorker3, lineWorkerPos3);
                        break;
                    }
                    if (lineWorker4Instance == null)
                    {
                        lineWorker4Instance = Instantiate(lineWorker4, lineWorkerPos4);
                        break;
                    }
                    break;
            }
        }
    }

    public void fireLineWorker()
    {
        if (lineWorkerCount > 0)
        {
            switch (lineWorkerCount)
            {
                case 1:
                    money += 50;
                    Destroy(lineWorker1Instance);
                    lineWorkerCount--;
                    break;
                case 2:
                    money += 50;
                    Destroy(lineWorker2Instance);
                    lineWorkerCount--;
                    break;
                case 3:
                    money += 50;
                    Destroy(lineWorker3Instance);
                    lineWorkerCount--;
                    break;
                case 4:
                    money += 50;
                    Destroy(lineWorker4Instance);
                    lineWorkerCount--;
                    break;
            }
        }
    }

    public void hireDeliveryWorker()
    {
        if (deliveryWorkerCount < 4)
        {
            switch (deliveryWorkerCount)
            {
                case 0:
                    deliveryWorker1 = Instantiate(deliveryWorker, deliveryWorkerPos1);
                    deliveryWorkerCount++;
                    break;
                case 1:
                    deliveryWorker2 = Instantiate(deliveryWorker, deliveryWorkerPos2);
                    deliveryWorkerCount++;
                    break;
                case 2:
                    deliveryWorker3 = Instantiate(deliveryWorker, deliveryWorkerPos3);
                    deliveryWorkerCount++;
                    break;
                case 3:
                    deliveryWorker4 = Instantiate(deliveryWorker, deliveryWorkerPos4);
                    deliveryWorkerCount++;
                    break;
            }
        }
    }

    public void fireDeliveryWorker()
    {
        if (deliveryWorkerCount > 0)
        {
            switch (deliveryWorkerCount)
            {
                case 1:
                    Destroy(deliveryWorker1);
                    deliveryWorkerCount--;
                    break;
                case 2:
                    Destroy(deliveryWorker2);
                    deliveryWorkerCount--;
                    break;
                case 3:
                    Destroy(deliveryWorker3);
                    deliveryWorkerCount--;
                    break;
                case 4:
                    Destroy(deliveryWorker4);
                    deliveryWorkerCount--;
                    break;
            }
        }
    }

    public int returnMoney()
    {
        return money;
    }

    public int returnFireCounter()
    {
        return fireCounter;
    }

    public int setMoney(int newMoney)
    {
        money = newMoney;
        return money;
    }

    public int setFireCounter(int newFireCounter)
    {
        fireCounter = newFireCounter;
        return fireCounter;
    }

    public void generateWorker()
    {
        generateRandom();
        employeeText.text = CSV.GetComponent<WorkerStats>().GetAt(randomWorker).Name;
    }

    public int generateRandom()
    {
        randomWorker = Random.Range(0, 20);
        return randomWorker;
    }

    public string getWorkerDetails()
    {
        workerName = CSV.GetComponent<WorkerStats>().GetAt(randomWorker).Name;
        return workerName;
    }

    public int returnWorkerNumber()
    {
        return workerNumber;
    }
}