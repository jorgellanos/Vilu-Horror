using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    // Variables
    public bool on;
    public string ev;

    // Reference
    public Hand currentHand;
    public Light lt;
    public GameObject prefabS;
    private Transform pointer;
    private GameObject eventTrigger;

    // RayCast
    public RaycastHit hit;
    public Ray landingRay;
    private GameObject eventObject;

    // Start is called before the first frame update
    void Start()
    {
        pointer = transform;
        on = true;
        currentHand = null;
    }

    // Update is called once per frame
    void Update()
    {
        Raycasting();

        if (currentHand != null)
        {
            turnOnOff();
        }

        if (on)
        {
            lt.enabled = true;
        }
        else
        {
            lt.enabled = false;
        }

        Debug.DrawRay(pointer.position, transform.forward * 20,Color.red, 0.001f);
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
        if (currentHand.isUsing)
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

    public void Raycasting()
    {
        // Ray direction
        landingRay = new Ray(pointer.position, pointer.forward);
        
        if (Physics.Raycast(landingRay, out hit, 20f))
        {
            GetEvent();
        }
        else
        {
            // NOTHING YET
        }
    }

    public void GetEvent()
    {
        if (hit.collider.gameObject.name == ev)
        {
            if (!eventObject)
            {
                eventObject = Instantiate(prefabS, hit.point, Quaternion.identity);
            }
        }
    }
}
