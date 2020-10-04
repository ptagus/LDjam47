using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.EventSystems;
using System.Security.Cryptography.X509Certificates;

public class UIBlock : MonoBehaviour
{
    public GameObject showpanel, showhintpanel;
    public MoveController player;
    bool showhint;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) &&showhint)
        {
            ShowItem();
        }
    }

    public void ShowItem()
    {
        showpanel.SetActive(true);
        showhintpanel.SetActive(false);
        player.block = false;
        Time.timeScale = 0;
    }

    public void AcceptItem()
    {
        Time.timeScale = 1;
        showhintpanel.SetActive(true);
        showpanel.SetActive(false);
        player.block = true;
    }


    public void SwapBool(bool hintnow)
    {
        showhint = hintnow;
        showhintpanel.SetActive(hintnow);
    }

}
