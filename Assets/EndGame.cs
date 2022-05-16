using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{

    public TextMeshProUGUI fireAmount, failedPackages, successfulPackages, profit, earlyCloses;
    // Start is called before the first frame update
    void Start()
    {
        fireAmount.text = "" + Manager.fireCounter;
        successfulPackages.text = "" + Manager.totalPackageCounter;
        failedPackages.text = "" + Manager.failedPackageCounter;
        profit.text = "£: " + Manager.totalProfit;
        earlyCloses.text = "" + Manager.earlyCloses;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
