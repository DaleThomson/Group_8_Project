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

    public GameObject hireUI;

    private int lineWorkerCount = 0;
    private int deliveryWorkerCount = 0;

    public int money;
    public static int fireCounter;
    public int packageCounter, failedPackageCounter;
    public Text moneyText;
    public Text dayText;
    public TextMeshProUGUI employeeText;
    public TextMeshProUGUI moneyTotalText, moneyTotalText2;
    public TextMeshProUGUI fundsTotalText, fundsTotalText2;
    public TextMeshProUGUI todaysProfitText;
    public TextMeshProUGUI totalMoney;
    public TextMeshProUGUI fireText0, fireText1, fireText2, fireText3;
    public GameObject fired0, fired1, fired2, fired3;
    int workerNumber;
    int workerLevel;
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

    public int days;

    bool camera;
    bool check;

    [SerializeField] int packageCounterThreshold;
    public int todayMoneyTotal;
    public int todayMoneySpent;
    public int todayMoneyProfit;
    public int totalEarned;
    public int totalSpent;
    public int totalProfit;

    // Start is called before the first frame update
    void Start()
    {
        workerLevel = 1;
        days = 0;
        dayChange(days);
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
        todayMoneyTotal = 0;
        todayMoneyProfit = 0;
        todayMoneySpent = 0;
        totalProfit = 0;
        totalSpent = 0;
        totalEarned = 0;
        fireCounter = 0;
        generateWorker();
        fireText0.text = employeeText.text;
        lineWorkerCount = 0;
        lineWorker1Instance = Instantiate(lineWorker1, lineWorkerPos1);
        lineWorker2Instance = null;
        lineWorker3Instance = null;
        lineWorker4Instance = null;
        lineWorkerCount++;
    }

    // Update is called once per frame
    void Update()
    {
        if (packageCounter >= packageCounterThreshold)
        {
            hireUI.SetActive(true);
            Player.camera = false;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            if (check)
            {
                packageCounter = 0;
                Player.camera = true;
                Cursor.lockState = CursorLockMode.Locked;
                days++;
                dayChange(days);
                hireUI.SetActive(false);
                Time.timeScale = 1;
                check = false;
            }
        }
        todayMoneyProfit = todayMoneyTotal - todayMoneySpent;
        totalProfit = totalEarned - totalSpent;
        moneyText.text = "Money: £" + money;
        moneyTotalText.text = "Funds Gained:\n£50 Per Package\nTotal Money Earned Today: £" + todayMoneyTotal + "\nTotal Money Spent Today: £" + todayMoneySpent + "\nTodays Profit: £" + todayMoneyProfit;
        moneyTotalText2.text = moneyTotalText.text;
        fundsTotalText.text = "Total Earned: £" + totalEarned + "\nTotal Spent: £" + totalSpent + "\nTotal Profit: £" + totalProfit;
        fundsTotalText2.text = fundsTotalText.text;
        todaysProfitText.text = "Total Profit Made: £" + todayMoneyProfit;
        totalMoney.text = "Total Funds: £" + money;
    }

    public void dayChange(int day)
    {
        switch (day)
        {
            case 0:
                dayText.text = "Monday";
                break;
            case 1:
                todayMoneyTotal = 0;
                todayMoneyProfit = 0;
                todayMoneySpent = 0;
                dayText.text = "Tuesday";
                break;
            case 2:
                todayMoneyTotal = 0;
                todayMoneyProfit = 0;
                todayMoneySpent = 0;
                dayText.text = "Wednesday";
                break;
            case 3:
                todayMoneyTotal = 0;
                todayMoneyProfit = 0;
                todayMoneySpent = 0;
                dayText.text = "Thursday";
                break;
            case 4:
                todayMoneyTotal = 0;
                todayMoneyProfit = 0;
                todayMoneySpent = 0;
                dayText.text = "Friday";
                break;
            case 5:
                todayMoneyTotal = 0;
                todayMoneyProfit = 0;
                todayMoneySpent = 0;
                SceneManager.LoadScene("EndScene");
                break;
        }
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
                        workerLevel = 2;
                        lineWorker1Instance = Instantiate(lineWorker1, lineWorkerPos1);
                        lineWorkerCount++;
                        money -= 100;
                        todayMoneySpent += 100;
                        totalSpent += 100;
                        fireText0.text = employeeText.text;
                        fired0.SetActive(false);
                    }
                    break;
                case 1:
                    if (lineWorker2Instance == null)
                    {
                        workerNumber = 1;
                        workerLevel = 2;
                        lineWorker2Instance = Instantiate(lineWorker2, lineWorkerPos2);
                        lineWorkerCount++;
                        money -= 100;
                        todayMoneySpent += 100;
                        totalSpent += 100;
                        fireText1.text = employeeText.text;
                        fired1.SetActive(false);
                    }
                    break;
                case 2:
                    if (lineWorker3Instance == null)
                    {
                        workerNumber = 2;
                        workerLevel = 2;
                        lineWorker3Instance = Instantiate(lineWorker3, lineWorkerPos3);
                        lineWorkerCount++;
                        money -= 100;
                        todayMoneySpent += 100;
                        totalSpent += 100;
                        fireText2.text = employeeText.text;
                        fired2.SetActive(false);
                    }
                    break;
                case 3:
                    if (lineWorker4Instance == null)
                    {
                        workerNumber = 3;
                        workerLevel = 2;
                        lineWorker4Instance = Instantiate(lineWorker4, lineWorkerPos4);
                        lineWorkerCount++;
                        money -= 100;
                        todayMoneySpent += 100;
                        totalSpent += 100;
                        fireText3.text = employeeText.text;
                        fired3.SetActive(false);
                    }
                    break;
            }
        }
    }

    public void hireLineWorkerDown(int input)
    {
        if (money >= 100)
        {
            switch (input)
            {
                case 0:
                    if (lineWorker1Instance == null)
                    {
                        workerNumber = 0;
                        workerLevel = 1;
                        lineWorker1Instance = Instantiate(lineWorker1, lineWorkerPos1);
                        lineWorkerCount++;
                        money -= 50;
                        todayMoneySpent += 50;
                        totalSpent += 50;
                        fireText0.text = employeeText.text;
                        fired0.SetActive(false);
                    }
                    break;
                case 1:
                    if (lineWorker2Instance == null)
                    {
                        workerNumber = 1;
                        workerLevel = 1;
                        lineWorker2Instance = Instantiate(lineWorker2, lineWorkerPos2);
                        lineWorkerCount++;
                        money -= 50;
                        todayMoneySpent += 50;
                        totalSpent += 50;
                        fireText1.text = employeeText.text;
                        fired1.SetActive(false);
                    }
                    break;
                case 2:
                    if (lineWorker3Instance == null)
                    {
                        workerNumber = 2;
                        workerLevel = 1;
                        lineWorker3Instance = Instantiate(lineWorker3, lineWorkerPos3);
                        lineWorkerCount++;
                        money -= 50;
                        todayMoneySpent += 50;
                        totalSpent += 50;
                        fireText2.text = employeeText.text;
                        fired2.SetActive(false);
                    }
                    break;
                case 3:
                    if (lineWorker4Instance == null)
                    {
                        workerNumber = 3;
                        workerLevel = 1;
                        lineWorker4Instance = Instantiate(lineWorker4, lineWorkerPos4);
                        lineWorkerCount++;
                        money -= 50;
                        todayMoneySpent += 50;
                        totalSpent += 50;
                        fireText3.text = employeeText.text;
                        fired3.SetActive(false);
                    }
                    break;
            }
        }
    }

    public void hireLineWorkerSuper(int input)
    {
        if (money >= 100)
        {
            switch (input)
            {
                case 0:
                    if (lineWorker1Instance == null)
                    {
                        workerNumber = 0;
                        workerLevel = 3;
                        lineWorker1Instance = Instantiate(lineWorker1, lineWorkerPos1);
                        lineWorkerCount++;
                        money -= 200;
                        todayMoneySpent += 200;
                        totalSpent += 200;
                        fireText0.text = employeeText.text;
                        fired0.SetActive(false);
                    }
                    break;
                case 1:
                    if (lineWorker2Instance == null)
                    {
                        workerNumber = 1;
                        workerLevel = 3;
                        lineWorker2Instance = Instantiate(lineWorker2, lineWorkerPos2);
                        lineWorkerCount++;
                        money -= 200;
                        todayMoneySpent += 200;
                        totalSpent += 200;
                        fireText1.text = employeeText.text;
                        fired1.SetActive(false);
                    }
                    break;
                case 2:
                    if (lineWorker3Instance == null)
                    {
                        workerNumber = 2;
                        workerLevel = 3;
                        lineWorker3Instance = Instantiate(lineWorker3, lineWorkerPos3);
                        lineWorkerCount++;
                        money -= 200;
                        todayMoneySpent += 200;
                        totalSpent += 200;
                        fireText2.text = employeeText.text;
                        fired2.SetActive(false);
                    }
                    break;
                case 3:
                    if (lineWorker4Instance == null)
                    {
                        workerNumber = 3;
                        workerLevel = 3;
                        lineWorker4Instance = Instantiate(lineWorker4, lineWorkerPos4);
                        lineWorkerCount++;
                        money -= 200;
                        todayMoneySpent += 200;
                        totalSpent += 200;
                        fireText3.text = employeeText.text;
                        fired3.SetActive(false);
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
                    todayMoneyTotal += 50;
                    totalEarned += 50;
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
                    todayMoneyTotal += 50;
                    totalEarned += 50;
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
                    todayMoneyTotal += 50;
                    totalEarned += 50;
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
                    todayMoneyTotal += 50;
                    totalEarned += 50;
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

    public int getWorkerLevel()
    {
        return workerLevel;
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

    public void unPause()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Player.camera = true;
    }

    public int getMoneyTotal()
    {
        return todayMoneyTotal;
    }

    public int setMoneyTotal(int newMoney)
    {
        todayMoneyTotal = newMoney;
        return todayMoneyTotal;
    }

    public int getTotalFunds()
    {
        return totalEarned;
    }

    public int setTotalFunds(int newMoney)
    {
        totalEarned = newMoney;
        return totalEarned;
    }

    public int getMoneySpentToday()
    {
        return todayMoneySpent;
    }

    public int setMoneySpentToday(int newMoney)
    {
        todayMoneySpent = newMoney;
        return todayMoneySpent;
    }

    public int getTotalSpent()
    {
        return totalSpent;
    }

    public int setTotalSpent(int newMoney)
    {
        totalSpent = newMoney;
        return totalSpent;
    }

    public void checkTrue()
    {
        check = true;
    }
}