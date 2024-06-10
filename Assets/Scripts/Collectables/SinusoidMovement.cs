using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 StartPosition;
    void Start()
    {
        StartPosition= this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = StartPosition + (new Vector3(0, Mathf.Sin(Time.time),0))/4;
        transform.Rotate(0,10*Time.deltaTime,0);
    }
}
