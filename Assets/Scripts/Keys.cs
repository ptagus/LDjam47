using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public struct keysStruct
{
    public int Number;
    public bool InHands;
    public bool enable;
    public bool alreadyuse;
    public int influenceNumber;
}

public class Keys : MonoBehaviour
{
    public keysStruct Kstruct;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
