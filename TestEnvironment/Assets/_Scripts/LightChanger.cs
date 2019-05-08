using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanger : MonoBehaviour
{
    public float num;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetBlend(num);
    }
    
    public void SetBlend(float num)
    {
        RenderSettings.skybox.SetFloat("_Blend", num);
    }


}
