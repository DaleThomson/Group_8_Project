using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        money = 500;
        lineWorker1Instance = Instantiate(lineWorker1, lineWorkerPos1);
        lineWorkerCount++;
    }

    // Update is called once per frame
    void Update()
    {
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
                    Destroy(lineWorker1Instance);
                    lineWorkerCount--;
                    money += 50;
                    break;
                case 2:
                    Destroy(lineWorker2Instance);
                    lineWorkerCount--;
                    money += 50;
                    break;
                case 3:
                    Destroy(lineWorker3Instance);
                    lineWorkerCount--;
                    money += 50;
                    break;
                case 4:
                    Destroy(lineWorker4Instance);
                    lineWorkerCount--;
                    money += 50;
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

    public int setMoney(int newMoney)
    {
        money = newMoney;
        return money;
    }
}