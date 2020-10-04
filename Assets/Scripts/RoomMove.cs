using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public GameObject Rooms, prefab;
    Vector3 destinate;
    public float speed = 1.0F;
    private float startTime;
    bool stop = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)  && stop)
        {
            stop = false;
            setDestinationPosition();
        }

        if (!stop)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / 40;
            transform.position = Vector3.Lerp(Rooms.transform.position, destinate, fractionOfJourney);
            float distanse = Vector3.Distance(transform.position, destinate);
            if (distanse < 0.001f)
            {
                createNewRoom();
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
        Instantiate(prefab, newPos, Quaternion.identity, Rooms.transform);
    }

    public void deleteOldRoom()
    {
        Destroy(transform.GetChild(0).gameObject);
    }
}
