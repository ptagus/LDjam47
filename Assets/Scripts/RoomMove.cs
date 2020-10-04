using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct texts
{
    public string itemName;
    public int ItemNumber;
    public string text;
    public int itemNumberiteration;
}

public class RoomMove : MonoBehaviour
{
    //public keysStruct[] allKeys;
    public int nowTime;
    public texts[] AllTexts;
    public GameObject Rooms, prefab;
    GameObject newroom;
    Vector3 destinate;
    public float speed = 1.0F;
    private float startTime;
    [HideInInspector]
    public bool stop = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / 40;
            transform.position = Vector3.Lerp(Rooms.transform.position, destinate, fractionOfJourney);
            float distanse = Vector3.Distance(transform.position, destinate);
            if (distanse < 0.001f)
            {                
                deleteOldRoom();
                Debug.Log(distanse);
                stop = true;
            }
        }
    }

    public void setDestinationPosition()
    {
        startTime = Time.time;
        destinate = Rooms.transform.position - new Vector3(40, 0, 0);
    }

    public void createNewRoom()
    {
        Vector3 newPos = prefab.transform.position + new Vector3(40, 0, 0);
        newroom =  Instantiate(prefab, newPos, Quaternion.identity, Rooms.transform);
    }

    public void deleteOldRoom()
    {
        Destroy(transform.GetChild(0).gameObject);
        newroom.GetComponent<OpenDoorAnimation>().enabled = true;
    }

    public void updateKeysState(keysStruct ks)
    {
        myGM my = GetComponent<myGM>();
        my.allKeys[ks.influenceNumber - 1].enable = true;
    }
}
