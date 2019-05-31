using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreColl : MonoBehaviour
{
    public Collider c1,c3;

    public int numColl;
    public Collider[] colliders;

    public bool collided;
    

    // Start is called before the first frame update
    void Start()
    {
        c1 = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        SetArrayLength();
        Ignore();
    }

    public void Ignore()
    {
        Physics.IgnoreCollision(c1, c3);
        Physics.IgnoreCollision(c1, colliders[2]);
        Physics.IgnoreCollision(c1, colliders[1]);
        Physics.IgnoreCollision(c1, colliders[0]);
    }

    public void SetArrayLength()
    {
        if (colliders.Length < numColl || colliders.Length > numColl)
        {
            colliders = new Collider[numColl];
        }
    }
    
}
