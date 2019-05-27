using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreColl : MonoBehaviour
{
    public Collider c1, c2, c3;

    public bool collided;

    // Start is called before the first frame update
    void Start()
    {
        c1 = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collided)
        {
            Ignore();
        }
    }

    public void Ignore()
    {
        Physics.IgnoreCollision(c1,c2);
        Physics.IgnoreCollision(c1, CheckC3());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == c2)
        {
            collided = true;
        }

        if (collision.collider == CheckC3())
        {
            collided = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == c2)
        {
            collided = true;
        }

        if (collision.collider == CheckC3())
        {
            collided = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider == c2)
        {
            collided = false;
        }

        if (collision.collider == CheckC3())
        {
            collided = false;
        }
    }

    public Collider CheckC3()
    {
        if (c3 != null)
        {
            return c3;
        }
        else
        {
            return c2;
        }
    }
}
