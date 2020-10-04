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
        if (other.gameObject.tag == "Door")
        {
            panel.WalkDoor(true);
        }
        if (other.gameObject.tag == "Object")
        {
            panel.SwapBool(true, other.GetComponent<Keys>().Kstruct);
        }
        if (other.gameObject.tag == "Clock")
        {
            panel.ShowClock(true);
        }
        if (other.gameObject.tag == "Safe")
        {
            panel.ShowSafe(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        if (other.gameObject.tag == "Door")
        {
            panel.WalkDoor(false);
        }
        if (other.gameObject.tag == "Object")
        {
            panel.SwapBool(false, other.GetComponent<Keys>().Kstruct);
        }
        if (other.gameObject.tag == "Clock")
        {
            panel.ShowClock(false);
        }
        if (other.gameObject.tag == "Safe")
        {
            panel.ShowSafe(false);
        }
    }
}
