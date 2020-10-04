using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.EventSystems;
using System.Security.Cryptography.X509Certificates;
using System.Security;

public class UIBlock : MonoBehaviour
{
    public GameObject showpanel, showhintpanel;
    public RoomMove Rmove;
    public MoveController player;
    bool showhint, walkfromdoor;
    keysStruct ks;
    private void Start()
    {
        Rmove = GetComponentInParent<RoomMove>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && showhint)
        {
            ShowItem();
        }
        if (Input.GetKeyDown(KeyCode.S) && walkfromdoor)
        {
            player.gameObject.SetActive(false);
            Rmove.createNewRoom();
            Rmove.setDestinationPosition();
            Rmove.stop = false;
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
        Debug.LogError(ks.influenceNumber + " ----" + ks.Number);
        Rmove.updateKeysState(ks);
        showhintpanel.SetActive(true);
        showpanel.SetActive(false);
        player.block = true;
    }


    public void SwapBool(bool hintnow, keysStruct kstrukt)
    {
        showhint = hintnow;
        showhintpanel.SetActive(hintnow);
        ks = kstrukt;
    }

    public void WalkDoor(bool WalkEnable)
    {
        walkfromdoor = WalkEnable;
        Rmove = GetComponentInParent<RoomMove>();
    }

}
