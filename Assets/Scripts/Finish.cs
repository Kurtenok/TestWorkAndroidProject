using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider boxCollider;
    LevelTranstitonManager levelTranstitonManager;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        levelTranstitonManager=GameObject.Find("LevelTransitionManager").GetComponent<LevelTranstitonManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            levelTranstitonManager.LoadNextLevel();
        }
    }
}
