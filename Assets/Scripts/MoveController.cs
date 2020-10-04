using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.AI;



public class MoveController : MonoBehaviour
{
    public NavMeshAgent nma;
    public bool block = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && block)
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.collider.tag != "Finish")
                {
                    nma.destination = hit.point;
                    Debug.Log(hit.collider.name);
                }
            }
        }
    }

    public void blockactive()
    {

    }
}
