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
        for (int i = 0; i < 4; i++)
        {
            SkyType[i].SetActive(false);
        }
        for (int i = 0; i < 2; i++)
        {
            lights[0].SetActive(false);
            lights[1].SetActive(false);
        }
        rmove = GetComponentInParent<RoomMove>();
        if (rmove.nowTime < 6)
        {
            SkyType[0].SetActive(true);
            srpic.sprite = pictures[Random.Range(1,20)];
            lights[1].SetActive(true);
        }
        if (rmove.nowTime < 12 && rmove.nowTime > 5)
        {
            SkyType[1].SetActive(true);
            srpic.sprite = pictures[Random.Range(1, 20)];
            lights[0].SetActive(true);
        }
        if (rmove.nowTime < 18 && rmove.nowTime > 11)
        {
            SkyType[2].SetActive(true);
            srpic.sprite = pictures[Random.Range(1, 20)];
            lights[0].SetActive(true);
        }
        if (rmove.nowTime < 24 && rmove.nowTime > 18)
        {
            SkyType[3].SetActive(true);
            srpic.sprite = pictures[Random.Range(1, 20)];
            lights[0].SetActive(true);
        }
        if (rmove.nowTime == 18)
        {
            SkyType[3].SetActive(true);
            srpic.sprite = pictures[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
