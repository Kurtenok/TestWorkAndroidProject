using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferToCanvas : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject CanvasFromTransf;
    [SerializeField] GameObject CanvasToTransf;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Transfer()
    {
        CanvasToTransf.SetActive(true);
        CanvasFromTransf.SetActive(false);
    }
}
