using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameKeys : MonoBehaviour
{
    public Keys[] keys;
    myGM keysnow;
    private void Start()
    {
        keysnow = GetComponentInParent<myGM>();
        for (int i=0; i < keys.Length; i++)
        {
            keys[i].Kstruct = keysnow.allKeys[i];
            keys[i].gameObject.SetActive(keys[i].Kstruct.enable);
        }
    }
}
