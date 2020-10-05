using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    RoomMove rmove;
    public GameObject[] SkyType;
    public Sprite[] pictures;
    public SpriteRenderer srpic;
    public GameObject[] lights;
    // Start is called before the first frame update
    void Start()
    {
        rmove = GetComponentInParent<RoomMove>();
        for (int i = 0; i < 4; i++)
        {
            SkyType[i].SetActive(false);
        }
        if (rmove.nowTime < 6)
        {
            SkyType[0].SetActive(true);
            srpic.sprite = pictures[Random.Range(1,20)];
            lights[1].SetActive(true);
            return;
        }
        if (rmove.nowTime < 12 && rmove.nowTime > 5)
        {
            SkyType[1].SetActive(true);
            srpic.sprite = pictures[Random.Range(1, 20)];
            lights[0].SetActive(true);
            return;
        }
        if (rmove.nowTime < 18 && rmove.nowTime > 11)
        {
            SkyType[2].SetActive(true);
            srpic.sprite = pictures[Random.Range(1, 20)];
            lights[0].SetActive(true);
            return;
        }
        if (rmove.nowTime < 24 && rmove.nowTime > 18)
        {
            SkyType[3].SetActive(true);
            srpic.sprite = pictures[Random.Range(1, 20)];
            lights[0].SetActive(true);
            return;
        }
        if (rmove.nowTime == 18)
        {
            SkyType[3].SetActive(true);
            srpic.sprite = pictures[0]; 
            lights[0].SetActive(true);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
