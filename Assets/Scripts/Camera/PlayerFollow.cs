using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 offset;
    [SerializeField] GameObject Player;
    void Start()
    {
        Player=GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Player.transform.position + offset;
        
    }
}
