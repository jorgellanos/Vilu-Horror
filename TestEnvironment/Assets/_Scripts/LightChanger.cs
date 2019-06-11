using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanger : MonoBehaviour
{
    public float num, lightSTR, shadow;
    public bool itsTime;

    public Light lt;

    // Start is called before the first frame update
    void Start()
    {
        lightSTR = 1;
        shadow = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SetBlend(num);

        lt.intensity = lightSTR;
        lt.shadowStrength = shadow;

        if (itsTime)
        {
            SunDown();
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

    public void SunDown()
    {
        if (lightSTR > 0)
        {
            lightSTR = lightSTR - 0.1f * Time.deltaTime;
        }
        else if (lightSTR < 0)
        {
            lightSTR = 0;
        }

        if (shadow < 1)
        {
            shadow = shadow + 0.1f * Time.deltaTime;
        }
        else if (shadow > 1)
        {
            shadow = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Body")
        {
            itsTime = true;
        }
    }
}
