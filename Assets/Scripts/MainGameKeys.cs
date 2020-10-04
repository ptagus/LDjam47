using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameKeys : MonoBehaviour
{
    public Keys[] keys;
    myGM keysnow;
    RoomMove rm;
    private void Start()
    {
        keysnow = GetComponentInParent<myGM>();
        rm = GetComponentInParent<RoomMove>();
        for (int i=0; i < keys.Length; i++)
        {
            Debug.LogError(keys[i].Kstruct.needTime + "now: " + rm.nowTime);
            keysnow.allKeys[i] = keys[i].Kstruct;
            Debug.LogError(keys[i].Kstruct.needTime + "now: " + rm.nowTime);
            if (keys[i].Kstruct.needTime == rm.nowTime)
            {
                keys[i].Kstruct.influenceNumber = 2;
            }
            else
            {
                keys[i].Kstruct.influenceNumber = 1;
            }
        }
    }
}
