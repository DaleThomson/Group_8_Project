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

    //public GameObject deliveryWorker;
    //private GameObject deliveryWorker1;
    //private GameObject deliveryWorker2;
    //private GameObject deliveryWorker3;
    //private GameObject deliveryWorker4;

    public Transform lineWorkerPos1;
    public Transform lineWorkerPos2;
    public Transform lineWorkerPos3;
    public Transform lineWorkerPos4;
    //public Transform deliveryWorkerPos1;
    //public Transform deliveryWorkerPos2;
    //public Transform deliveryWorkerPos3;
    //public Transform deliveryWorkerPos4;

    public GameObject hireUI;

    private int lineWorkerCount = 0;
    private int deliveryWorkerCount = 0;

    public int money;
    public static int fireCounter;
    public static int packageCounter, failedPackageCounter, totalPackageCounter, earlyCloses;
    public Text moneyText;
    public Text dayText;
    public TextMeshProUGUI employeeText;
    public TextMeshProUGUI moneyTotalText, moneyTotalText2;
    public TextMeshProUGUI fundsTotalText, fundsTotalText2;
    public TextMeshProUGUI todaysProfitText;
    public TextMeshProUGUI totalMoney;
    public TextMeshProUGUI employeeFiredText, employeeFiredText2, employeeFiredText3;
    public TextMeshProUGUI employeeBrokenText, employeeBrokenText2, employeeBrokenText3;
    public TextMeshProUGUI employeeBelowFiftyText, employeeBelowFiftyText2;
    public TextMeshProUGUI employeeHiredText, employeeHiredText2;
    public TextMeshProUGUI upgradeText1, upgradeText2, upgradeText3, upgradeText4;
    public TextMeshProUGUI fireText0, fireText1, fireText2, fireText3;
    public GameObject fired0, fired1, fired2, fired3;
    public GameObject upgradeFired0, upgradeFired1, upgradeFired2, upgradeFired3;
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
    public TextMesh Pos11;
    public TextMesh Pos12;
    public TextMesh Pos13;
    public TextMesh Pos14;
    public TextMesh Pos15;
    public TextMesh Pos16;
    public TextMesh Pos17;
    public TextMesh Pos18;
    public TextMesh Pos19;
    public TextMesh Pos20;
    public TextMesh Pos21;
    public TextMesh Pos22;
    public TextMesh Pos23;
    public TextMesh Pos24;
    private TextMesh[] names = new TextMesh[25];
    int stringCount = 1;

    public int days;

    bool camera;
    bool check, check2;

    [SerializeField] int packageCounterThreshold;
    public int todayMoneyTotal;
    public int todayMoneySpent;
    public int todayMoneyProfit;
    public int totalEarned;
    public int totalSpent;
    public static int totalProfit;
    public int below50;
    public int brokenSpirit;
    public int hireCounter;
    private int workerInstance1Level, workerInstance2Level, workerInstance3Level, workerInstance4Level;
    private int workerInstanceMorale1, workerInstanceMorale2, workerInstanceMorale3, workerInstanceMorale4;
    private int workerInstanceProductivity1, workerInstanceProductivity2, workerInstanceProductivity3, workerInstanceProductivity4;

    public Slider morale1, morale2, morale3, morale4;
    public Slider productivity1, productivity2, productivity3, productivity4;

    public AudioSource managerAudio;
    public AudioClip nextDay;

    // Start is called before the first frame update
    void Start()
    {
        earlyCloses = 0;
        totalPackageCounter = 0;
        check = false;
        check2 = false;
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
        names[11] = Pos11;
        names[12] = Pos12;
        names[13] = Pos13;
        names[14] = Pos14;
        names[15] = Pos15;
        names[16] = Pos16;
        names[17] = Pos17;
        names[18] = Pos18;
        names[19] = Pos19;
        names[20] = Pos20;
        names[21] = Pos21;
        names[22] = Pos22;
        names[23] = Pos23;
        names[24] = Pos24;
        CSV = GameObject.Find("/CSV");
        money = 500;
        todayMoneyTotal = 0;
        todayMoneyProfit = 0;
        todayMoneySpent = 0;
        totalProfit = 0;
        totalSpent = 0;
        totalEarned = 0;
        fireCounter = 0;
        hireCounter = 0;
        below50 = 0;
        brokenSpirit = 0;
        generateWorker();
        fireText0.text = employeeText.text;
        lineWorkerCount = 0;
        workerLevel = 2;
        lineWorker1Instance = Instantiate(lineWorker1, lineWorkerPos1);
        lineWorker2Instance = null;
        lineWorker3Instance = null;
        lineWorker4Instance = null;
        lineWorkerCount++;
        Player.camera = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        hireUI.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (packageCounter >= packageCounterThreshold)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            hireUI.SetActive(true);
            Player.camera = false;
            Time.timeScale = 0;
        }
        if (check == true)
        {
            if (lineWorker1Instance == null && lineWorker2Instance == null && lineWorker3Instance == null && lineWorker4Instance == null && !hireUI.active)
            {
                if (check2)
                {
                    earlyCloses++;
                }
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                hireUI.SetActive(true);
                Player.camera = false;
                Time.timeScale = 0;
                check2 = true;
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
        employeeFiredText.text = "Total Employees Fired: " + fireCounter;
        employeeFiredText2.text = employeeFiredText.text;
        employeeFiredText3.text = employeeFiredText.text;
        employeeBelowFiftyText.text = below50 + " Employees Below 50% Efficiency";
        employeeBelowFiftyText2.text = employeeBelowFiftyText.text;
        employeeBrokenText.text = brokenSpirit + " Employee Breakdowns";
        employeeBrokenText2.text = employeeBrokenText.text;
        employeeBrokenText3.text = employeeBrokenText.text;
        employeeHiredText.text = "Total Employees Hired: " + hireCounter;
        employeeHiredText2.text = employeeHiredText.text;

        if (lineWorker1Instance != null)
        {
            workerInstance1Level = lineWorker1Instance.GetComponent<Worker>().getLevel();
            workerInstanceMorale1 = lineWorker1Instance.GetComponent<Worker>().getMorale();
            workerInstanceProductivity1 = lineWorker1Instance.GetComponent<Worker>().getProductivity();
            upgradeFired0.SetActive(false);
            upgradeText1.text = lineWorker1Instance.GetComponent<Worker>().getName() + ": Level: " + lineWorker1Instance.GetComponent<Worker>().getLevel() + "/5";
            morale1.value = lineWorker1Instance.GetComponent<Worker>().getMorale();
            productivity1.value = lineWorker1Instance.GetComponent<Worker>().getProductivity();
        }

        if (lineWorker2Instance != null)
        {
            workerInstance2Level = lineWorker2Instance.GetComponent<Worker>().getLevel();
            workerInstanceMorale2 = lineWorker2Instance.GetComponent<Worker>().getMorale();
            workerInstanceProductivity2 = lineWorker2Instance.GetComponent<Worker>().getProductivity();
            upgradeFired1.SetActive(false);
            upgradeText2.text = lineWorker2Instance.GetComponent<Worker>().getName() + ": Level: " + lineWorker2Instance.GetComponent<Worker>().getLevel() + "/5";
            morale2.value = lineWorker1Instance.GetComponent<Worker>().getMorale();
            productivity2.value = lineWorker1Instance.GetComponent<Worker>().getProductivity();
        }

        if (lineWorker3Instance != null)
        {
            workerInstanceMorale3 = lineWorker3Instance.GetComponent<Worker>().getMorale();
            workerInstance3Level = lineWorker3Instance.GetComponent<Worker>().getLevel();
            workerInstanceProductivity3 = lineWorker3Instance.GetComponent<Worker>().getProductivity();
            upgradeFired2.SetActive(false);
            upgradeText3.text = lineWorker3Instance.GetComponent<Worker>().getName() + ": Level: " + lineWorker3Instance.GetComponent<Worker>().getLevel() + "/5";
            morale3.value = lineWorker1Instance.GetComponent<Worker>().getMorale();
            productivity3.value = lineWorker1Instance.GetComponent<Worker>().getProductivity();
        }

        if (lineWorker4Instance != null)
        {
            workerInstanceMorale4 = lineWorker4Instance.GetComponent<Worker>().getMorale();
            workerInstance4Level = lineWorker4Instance.GetComponent<Worker>().getLevel();
            workerInstanceProductivity4 = lineWorker4Instance.GetComponent<Worker>().getProductivity();
            upgradeFired3.SetActive(false);
            upgradeText4.text = lineWorker4Instance.GetComponent<Worker>().getName() + ": Level: " + lineWorker4Instance.GetComponent<Worker>().getLevel() + "/5";
            morale4.value = lineWorker1Instance.GetComponent<Worker>().getMorale();
            productivity4.value = lineWorker1Instance.GetComponent<Worker>().getProductivity();
        }

        if (lineWorker1Instance == null)
        {
            upgradeFired0.SetActive(true);
        }

        if (lineWorker2Instance == null)
        {
            upgradeFired1.SetActive(true);
        }

        if (lineWorker3Instance == null)
        {
            upgradeFired2.SetActive(true);
        }

        if (lineWorker4Instance == null)
        {
            upgradeFired3.SetActive(true);
        }
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
                        hireCounter++;
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
                        hireCounter++;
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
                        hireCounter++;
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
                        hireCounter++;
                        fireText3.text = employeeText.text;
                        fired3.SetActive(false);
                    }
                    break;
            }
        }
    }

    public void hireLineWorkerDown(int input)
    {
        if (money >= 50)
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
                        hireCounter++;
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
                        hireCounter++;
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
                        hireCounter++;
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
                        hireCounter++;
                        fireText3.text = employeeText.text;
                        fired3.SetActive(false);
                    }
                    break;
            }
        }
    }

    public void upgradeWorker(int input)
    {
        switch (input)
        {
            case 0:
                if (lineWorker1Instance != null && money >= 100 && workerInstance1Level < 5)
                {
                    lineWorker1Instance.GetComponent<Worker>().setLevel(workerInstance1Level + 1);
                    lineWorker1Instance.GetComponent<Worker>().setMorale(workerInstanceMorale1 + 10);
                    lineWorker1Instance.GetComponent<Worker>().setProductivity(workerInstanceProductivity1 + 10);
                    money -= 100;
                    totalSpent += 100;
                    todayMoneySpent += 100;
                    break;
                }
                break;
            case 1:
                if (lineWorker2Instance != null && money >=100 && workerInstance2Level < 5) 
                {
                    lineWorker2Instance.GetComponent<Worker>().setLevel(workerInstance2Level + 1);
                    lineWorker2Instance.GetComponent<Worker>().setMorale(workerInstanceMorale2 + 10);
                    lineWorker2Instance.GetComponent<Worker>().setProductivity(workerInstanceProductivity2 + 10);
                    money -= 100;
                    totalSpent += 100;
                    todayMoneySpent += 100;
                    break;
                }
                break;
            case 2:
                if (lineWorker3Instance != null && money >= 100 && workerInstance3Level < 5)
                {
                    lineWorker3Instance.GetComponent<Worker>().setLevel(workerInstance3Level + 1);
                    lineWorker3Instance.GetComponent<Worker>().setMorale(workerInstanceMorale3 + 10);
                    lineWorker3Instance.GetComponent<Worker>().setProductivity(workerInstanceProductivity3 + 10);
                    money -= 100;
                    totalSpent += 100;
                    todayMoneySpent += 100;
                    break;
                }
                break;
            case 3:
                if (lineWorker4Instance != null && money >= 100 && workerInstance4Level < 5)
                {
                    lineWorker4Instance.GetComponent<Worker>().setLevel(workerInstance4Level + 1);
                    lineWorker4Instance.GetComponent<Worker>().setMorale(workerInstanceMorale4 + 10);
                    lineWorker4Instance.GetComponent<Worker>().setProductivity(workerInstanceProductivity4 + 10);
                    money -= 100;
                    totalSpent += 100;
                    todayMoneySpent += 100;
                    break;
                }
                break;
        }
    }

    public void hireLineWorkerSuper(int input)
    {
        if (money >= 200)
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
                        hireCounter++;
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
                        hireCounter++;
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
                        hireCounter++;
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
                        hireCounter++;
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
                    workerName = lineWorker1Instance.GetComponent<Worker>().getName();
                    addNameToBoard(workerName, input);
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
                    workerName = lineWorker2Instance.GetComponent<Worker>().getName();
                    addNameToBoard(workerName, input);
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
                    workerName = lineWorker3Instance.GetComponent<Worker>().getName();
                    addNameToBoard(workerName, input);
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
                    workerName = lineWorker4Instance.GetComponent<Worker>().getName();
                    addNameToBoard(workerName, input);
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

    //public void hireDeliveryWorker()
    //{
    //    if (deliveryWorkerCount < 4)
    //    {
    //        switch (deliveryWorkerCount)
    //        {
    //            case 0:
    //                deliveryWorker1 = Instantiate(deliveryWorker, deliveryWorkerPos1);
    //                deliveryWorkerCount++;
    //                break;
    //            case 1:
    //                deliveryWorker2 = Instantiate(deliveryWorker, deliveryWorkerPos2);
    //                deliveryWorkerCount++;
    //                break;
    //            case 2:
    //                deliveryWorker3 = Instantiate(deliveryWorker, deliveryWorkerPos3);
    //                deliveryWorkerCount++;
    //                break;
    //            case 3:
    //                deliveryWorker4 = Instantiate(deliveryWorker, deliveryWorkerPos4);
    //                deliveryWorkerCount++;
    //                break;
    //        }
    //    }
    //}

    //public void fireDeliveryWorker()
    //{
    //    if (deliveryWorkerCount > 0)
    //    {
    //        switch (deliveryWorkerCount)
    //        {
    //            case 1:
    //                Destroy(deliveryWorker1);
    //                deliveryWorkerCount--;
    //                break;
    //            case 2:
    //                Destroy(deliveryWorker2);
    //                deliveryWorkerCount--;
    //                break;
    //            case 3:
    //                Destroy(deliveryWorker3);
    //                deliveryWorkerCount--;
    //                break;
    //            case 4:
    //                Destroy(deliveryWorker4);
    //                deliveryWorkerCount--;
    //                break;
    //        }
    //    }
    //}

    public int getMoney()
    {
        return money;
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

    public void unPauseNextDay()
    {
        totalPackageCounter += packageCounter;
        packageCounter = 0;
        Player.camera = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (check == true)
        {
            days++;
            dayChange(days);
        }
        hireUI.SetActive(false);
        Time.timeScale = 1;
        check = true;
        managerAudio.clip = nextDay;
        managerAudio.Play();
    }

    public void unPause()
    {
        Player.camera = true;
        Cursor.visible = false;
        hireUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
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

    public int getBelow50()
    {
        return below50;
    }

    public int setBelow50(int newBelow50)
    {
        below50 = newBelow50;
        return below50;
    }

    public int getBrokenSpirit()
    {
        return brokenSpirit;
    }

    public int setBrokenSpirit(int newBrokenSpirit)
    {
        brokenSpirit = newBrokenSpirit;
        return brokenSpirit;
    }
}