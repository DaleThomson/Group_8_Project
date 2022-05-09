using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    public TextMeshProUGUI fireText0, fireText1, fireText2, fireText3;
    public GameObject fired0, fired1, fired2, fired3;
    int workerNumber;
    GameObject CSV;
    string workerName;
    int randomWorker;
    int workerMorale;
    int workerProductivity;

    public TextMesh Pos1;
    public TextMesh Pos2;
    public TextMesh Pos3;
    public TextMesh Pos4;
    public TextMesh Pos5;
    public TextMesh Pos6;
    public TextMesh Pos7;
    public TextMesh Pos8;
    public TextMesh Pos9;
    public TextMesh Pos10;
    private TextMesh[] names = new TextMesh[11];
    int stringCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        names[1] = Pos1;
        names[2] = Pos2;
        names[3] = Pos3;
        names[4] = Pos4;
        names[5] = Pos5;
        names[6] = Pos6;
        names[7] = Pos7;
        names[8] = Pos8;
        names[9] = Pos9;
        names[10] = Pos10;
        CSV = GameObject.Find("/CSV");
        money = 500;
        generateWorker();
        fireText0.text = employeeText.text;
        lineWorker1Instance = Instantiate(lineWorker1, lineWorkerPos1);
        lineWorkerCount++;
    }

    // Update is called once per frame
    void Update()
    {
        if (fireCounter >= 10)
        {
            SceneManager.LoadScene("EndScene");
        }
        moneyText.text = "Money: £" + money;
    }

    public void hireLineWorker(int input)
    {
        if (money >= 100)
        {
            switch (input)
            {
                case 0:
                    if (lineWorker1Instance == null)
                    {
                        workerNumber = 0;
                        lineWorker1Instance = Instantiate(lineWorker1, lineWorkerPos1);
                        lineWorkerCount++;
                        money -= 100;
                        fireText0.text = employeeText.text;
                        fired0.SetActive(false);
                    }
                    break;
                case 1:
                    if (lineWorker2Instance == null)
                    {
                        workerNumber = 1;
                        lineWorker2Instance = Instantiate(lineWorker2, lineWorkerPos2);
                        lineWorkerCount++;
                        money -= 100;
                        fireText1.text = employeeText.text; 
                        fired1.SetActive(false);
                    }
                    break;
                case 2:
                    if (lineWorker3Instance == null)
                    {
                        workerNumber = 2;
                        lineWorker3Instance = Instantiate(lineWorker3, lineWorkerPos3);
                        lineWorkerCount++;
                        money -= 100;
                        fireText2.text = employeeText.text;
                        fired2.SetActive(false);
                    }
                    break;
                case 3:
                    if (lineWorker4Instance == null)
                    {
                        workerNumber = 3;
                        lineWorker4Instance = Instantiate(lineWorker4, lineWorkerPos4);
                        lineWorkerCount++;
                        money -= 100;
                        fireText3.text = employeeText.text;
                        fired3.SetActive(false);
                    }
                    break;
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

    public void fireLineWorker(int input)
    {
        switch (input)
        {
            case 0:
                if (lineWorker1Instance != null)
                {
                    fireCounter++;
                    names[stringCount].text = stringCount + ". " + lineWorker1Instance.GetComponent<Worker>().returnName();
                    stringCount++;
                    money += 50;
                    Destroy(lineWorker1Instance);
                    lineWorkerCount--;
                    fired0.SetActive(true);
                }
                break;
            case 1:
                if (lineWorker2Instance != null)
                {
                    fireCounter++;
                    names[stringCount].text = stringCount + ". " + lineWorker2Instance.GetComponent<Worker>().returnName();
                    stringCount++;
                    money += 50;
                    Destroy(lineWorker2Instance);
                    lineWorkerCount--;
                    fired1.SetActive(true);
                }
                break;
            case 2:
                if (lineWorker3Instance != null)
                {
                    fireCounter++;
                    names[stringCount].text = stringCount + ". " + lineWorker3Instance.GetComponent<Worker>().returnName();
                    stringCount++;
                    money += 50;
                    Destroy(lineWorker3Instance);
                    lineWorkerCount--;
                    fired2.SetActive(true);
                }
                break;
            case 3:
                if (lineWorker4Instance != null)
                {
                    fireCounter++;
                    names[stringCount].text = stringCount + ". " + lineWorker4Instance.GetComponent<Worker>().returnName();
                    stringCount++;
                    money += 50;
                    Destroy(lineWorker4Instance);
                    lineWorkerCount--;
                    fired3.SetActive(true);
                }
                break;
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
        employeeText.text = CSV.GetComponent<WorkerStats>().GetAt(randomWorker).Name + "\nMorale: " + CSV.GetComponent<WorkerStats>().GetAt(randomWorker).Morale + " /100\nProductivity: " + CSV.GetComponent<WorkerStats>().GetAt(randomWorker).Loyalty + "/100";
    }

    public int generateRandom()
    {
        randomWorker = Random.Range(0, 20);
        return randomWorker;
    }

    public string getWorkerName()
    {
        workerName = CSV.GetComponent<WorkerStats>().GetAt(randomWorker).Name;
        return workerName;
    }

    public int getWorkerMorale()
    {
        workerMorale = int.Parse(CSV.GetComponent<WorkerStats>().GetAt(randomWorker).Morale);
        return workerMorale;
    }

    public int getWorkerProductivity()
    {
        workerProductivity = int.Parse(CSV.GetComponent<WorkerStats>().GetAt(randomWorker).Loyalty);
        return workerProductivity;
    }

    public int getWorkerNumber()
    {
        return workerNumber;
    }

    public void addNameToBoard(string name, int number)
    {
        switch (number)
        {
            case 0:
                names[stringCount].text = stringCount + ". " + lineWorker1Instance.GetComponent<Worker>().returnName();
                stringCount++;
                break;
            case 1:
                names[stringCount].text = stringCount + ". " + lineWorker2Instance.GetComponent<Worker>().returnName();
                stringCount++;
                break;
            case 2:
                names[stringCount].text = stringCount + ". " + lineWorker3Instance.GetComponent<Worker>().returnName();
                stringCount++;
                break;
            case 3:
                names[stringCount].text = stringCount + ". " + lineWorker4Instance.GetComponent<Worker>().returnName();
                stringCount++;
                break;
        }    
    }
}