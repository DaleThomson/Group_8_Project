using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{

    public TextMeshProUGUI fireAmount;
    // Start is called before the first frame update
    void Start()
    {
        fireAmount.text = "" + Manager.fireCounter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
