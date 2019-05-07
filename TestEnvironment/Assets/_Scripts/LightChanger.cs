﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanger : MonoBehaviour
{
    public float num;
    public bool itsTime;
    
    // Update is called once per frame
    void Update()
    {
        SetBlend(num);

        if (itsTime)
        {
            cambiarSkybox();
        }
    }
    
    public void SetBlend(float num)
    {
        RenderSettings.skybox.SetFloat("_Blend", num);
    }
    
    public void cambiarSkybox()
    {
        num = num - 0.1f * Time.deltaTime;
        if (num <= 0)
        {
            itsTime = false;
        }
    }
}
