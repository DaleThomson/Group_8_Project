using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageSpawner : MonoBehaviour
{
    public GameObject package;
    public Transform spawnLocation;
    public int packageCount;
    public float packageTimer;
    public float packageSpawner;
    // Start is called before the first frame update
    void Start()
    {
        packageCount = 1;
        packageSpawner = 15f;
        packageTimer = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        packageSpawner -= Time.deltaTime;
        if (packageSpawner <= 0 && packageCount <= 4)
        {
            GameObject clone = (GameObject)Instantiate(package, spawnLocation.position, Quaternion.identity);
            packageCount++;
            packageSpawner = packageTimer;
        }
    }
}
