using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Security.Cryptography.X509Certificates;
using System.Security;
using UnityEngine.UI;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine.SceneManagement;

public class UIBlock : MonoBehaviour
{
    public GameObject[] alarm;
    public GameObject showpanel, showhintpanel, clockpanel, keypanel;
    public Text text;
    public Image img;
    public RoomMove Rmove;
    public AnimatePerson player;
    public Dropdown dd;
    public Dropdown[] key;
    bool showhint, walkfromdoor;
    keysStruct ks;
    bool isclock, issafe;
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
        if (Input.GetKeyDown(KeyCode.E) && walkfromdoor)
        {
            player.gameObject.SetActive(false);
            Rmove.createNewRoom();
            Rmove.setDestinationPosition();
            Rmove.stop = false;
        }
    }

    public void ShowItem()
    {
        if (issafe)
        {
            keypanel.SetActive(true);
            showhintpanel.SetActive(false);
            player.block = false;
            Time.timeScale = 0;
            return;
        }
        if (isclock)
        {
            clockpanel.SetActive(true);
            showhintpanel.SetActive(false);
            player.block = false;
            Time.timeScale = 0;
            return;
        }
        else
        {
            RightChoose();
        }
    }

    public void RightChoose()
    {
        foreach (texts t in Rmove.AllTexts)
        {
            if(t.ItemNumber == ks.Number)
            {
                if (t.itemNumberiteration == ks.influenceNumber)
                {
                    Debug.LogError(ks.influenceNumber + "num: " + ks.needTime);
                    text.text = t.text;
                    img.sprite = t.img;
                    break;
                }
            }
        }
        showpanel.SetActive(true);
        showhintpanel.SetActive(false);
        player.block = false;
        Time.timeScale = 0;
    }

    public void AcceptItem()
    {
        if (isclock)
        {
            Time.timeScale = 1;
            showhintpanel.SetActive(true);
            clockpanel.SetActive(false);
            player.block = true;
            return;
        }
        if (issafe)
        {
            Time.timeScale = 1;
            if (CheckKey())
            {
                //endgame;
                Debug.LogError("WINNNN");
                SceneManager.LoadScene(2);
                showhintpanel.SetActive(true);
                keypanel.SetActive(false);
                player.block = true;
                issafe = false;
                return;
            }
            else
            {
                issafe = false;
                Time.timeScale = 1;
                showhintpanel.SetActive(true);
                keypanel.SetActive(false);
                player.block = true;
                return;
            }
        }
        Time.timeScale = 1;
        Debug.LogError(ks.influenceNumber + " ----" + ks.Number);
        if (ks.needTime > 0)
            Rmove.updateKeysState(ks);
        showhintpanel.SetActive(true);
        showpanel.SetActive(false);
        player.block = true;
    }

    public bool CheckKey()
    {
        Debug.LogError(key[0] + "" + key[1] + ""+key[2] + "" + key[3]);
        if (key[0].value == 4 && key[1].value == 6 && key[2].value == 7 && key[3].value == 5)
        {
            return true;
        }
        return false;

    }

    public void SwapBool(bool hintnow, keysStruct kstrukt)
    {
        showhint = hintnow;
        showhintpanel.SetActive(hintnow);
        ks = kstrukt;
    }

    public void SwapBool(bool hintnow)
    {
        showhint = hintnow;
        showhintpanel.SetActive(hintnow);
    }

    public void WalkDoor(bool WalkEnable)
    {
        walkfromdoor = WalkEnable;
        Rmove = GetComponentInParent<RoomMove>();
    }

    public void ShowClock(bool clock)
    {
        showhint = clock;
        showhintpanel.SetActive(clock);
        isclock = clock;
    }

    public void Dropdown()
    {
        Debug.LogError(dd.value);
        Rmove.nowTime = dd.value;
        foreach (GameObject go in alarm)
        {
            go.SetActive(false);
        }
        alarm[dd.value].SetActive(true);
    }

    public void ShowSafe(bool safe)
    {
        showhint = safe;
        showhintpanel.SetActive(safe);
        issafe = true;
    }

}
