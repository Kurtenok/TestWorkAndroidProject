using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPref : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade()
    {
        int count=PlayerPrefs.GetInt("Heath");
        PlayerPrefs.SetInt("Heath", count+1);
        Debug.Log("Heath "+(count+1));
        PlayerPrefs.Save();
    }
}
