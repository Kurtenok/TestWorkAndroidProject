using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    HealthManager healthManager;
    // Start is called before the first frame update
    void Start()
    {
        healthManager=GameObject.Find("HealthManager").GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeleteAllProgress()
    {
        PlayerPrefs.DeleteAll();
        healthManager.Initialize();
    }
}
