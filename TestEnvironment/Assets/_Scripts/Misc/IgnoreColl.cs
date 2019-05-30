using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreColl : MonoBehaviour
{
    private Collider c1;

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
        foreach (Collider col in colliders)
        {
            Physics.IgnoreCollision(c1, col);
        }
    }

    public void SetArrayLength()
    {
        if (colliders.Length < numColl || colliders.Length > numColl)
        {
            colliders = new Collider[numColl];
        }
    }
    
}
