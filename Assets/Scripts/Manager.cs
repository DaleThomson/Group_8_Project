using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public GameObject lineWorker1;
    public GameObject lineWorker2;
    public GameObject lineWorker3;
    public GameObject lineWorker4;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void hireLineWorker()
    {
        if (lineWorkerCount < 4)
        {
            switch (lineWorkerCount)
            {
                case 0:
                    lineWorker1 = Instantiate(lineWorker1, lineWorkerPos1);
                    lineWorkerCount++;
                    break;
                case 1:
                    lineWorker2 = Instantiate(lineWorker2, lineWorkerPos2);
                    lineWorkerCount++;
                    break;
                case 2:
                    lineWorker3 = Instantiate(lineWorker3, lineWorkerPos3);
                    lineWorkerCount++;
                    break;
                case 3:
                    lineWorker4 = Instantiate(lineWorker4, lineWorkerPos4);
                    lineWorkerCount++;
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
                    Destroy(lineWorker1);
                    lineWorkerCount--;
                    break;
                case 2:
                    Destroy(lineWorker2);
                    lineWorkerCount--;
                    break;
                case 3:
                    Destroy(lineWorker3);
                    lineWorkerCount--;
                    break;
                case 4:
                    Destroy(lineWorker4);
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
}