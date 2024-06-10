using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas canvas;
    void Start()
    {
        TryGetComponent<Canvas>(out canvas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseThisCanvas()
    {
        canvas.gameObject.SetActive(false);
    }
}
