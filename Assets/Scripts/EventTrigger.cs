using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public UIBlock panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        panel.SwapBool(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        panel.SwapBool(false);

    }
}
