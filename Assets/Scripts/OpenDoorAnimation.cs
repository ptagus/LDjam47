using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpenDoorAnimation : MonoBehaviour
{
    public GameObject Player, startpos;
    float distanse =1;
    bool move;
    public float speed = 1.0F;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        Player.SetActive(true);
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!move)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / 40;
            Player.transform.position = Vector3.Lerp(Player.transform.position, startpos.transform.position, fractionOfJourney);
            distanse = startpos.transform.position.x - Player.transform.position.x;

            if (distanse < 0.01f)
            {
                move = true;
                this.GetComponent<OpenDoorAnimation>().enabled = false;
                Debug.LogError("move");
            }
        }
    }
}
