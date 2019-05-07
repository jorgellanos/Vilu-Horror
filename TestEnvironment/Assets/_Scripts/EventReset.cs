using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReset : MonoBehaviour
{
    public bool touching;

    public LightChanger lc;
    public GameObject player;

    public Vector3 posInicio;

    private Hand currentHand;

    void Start()
    {
        posInicio = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (touching)
        {
            ResetLvl();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            touching = true;
            currentHand = other.GetComponent<Hand>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            touching = false;
            currentHand = null;
        }
    }

    public void ResetLvl()
    {
        if (currentHand.pressing)
        {
            lc.num = 1;
            player.transform.position = posInicio;
        }
    }
}
