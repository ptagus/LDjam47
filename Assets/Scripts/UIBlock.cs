using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.EventSystems;
using System.Security.Cryptography.X509Certificates;

public class UIBlock : MonoBehaviour, IPointerDownHandler
{
    
public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("work");
    }
}
