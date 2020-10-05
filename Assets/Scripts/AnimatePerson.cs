using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class AnimatePerson : MonoBehaviour
{
    Animator animotor;
    bool anitstop = false;
    public UnityEngine.AI.NavMeshAgent nma;
    public bool block = true;
    RaycastHit hit;
    Vector3 destin;
    // Start is called before the first frame update
    void Start()
    {
        animotor = GetComponent<Animator>();
        nma.speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && block)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.collider.tag != "Finish")
                {
                    anitstop = true;
                    nma.destination = hit.point;
                    animotor.SetFloat("InputMagnitude", 0.45f);
                    Debug.Log(hit.collider.name);
                }
            }
        }
        if (Mathf.Abs(Vector3.Distance(transform.position,nma.destination)) < 0.1f && anitstop)
        {
            anitstop = false;
            animotor.SetFloat("InputMagnitude", 0f);
        }
    }

    public void blockactive()
    {

    }
}
