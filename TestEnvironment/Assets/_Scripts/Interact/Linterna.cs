using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    public bool on;

    public Hand currentHand;

    // Start is called before the first frame update
    void Start()
    {
        on = true;
        currentHand = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHand != null)
        {
            turnOnOff();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            currentHand = other.GetComponent<Hand>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            currentHand = null;
        }
    }

    public void turnOnOff()
    {
        if (currentHand.usingItem)
        {
            if (on)
            {
                on = false;
            }
            else
            {
                on = true;
            }
        }
    }
}
