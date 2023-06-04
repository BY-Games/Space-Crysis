using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulsate : MonoBehaviour
{
    public float minIntensity = 0.5f; // Minimum intensity value
    public float maxIntensity = 1.5f; // Maximum intensity value
    public float pulsateSpeed = 1f; // Speed of the pulsating effect

    private Light pointLight;
    private float baseIntensity;

    private void Start()
    {
        pointLight = GetComponent<Light>();
        baseIntensity = pointLight.intensity;
    }

    private void Update()
    {
        float intensity = baseIntensity + Mathf.PingPong(Time.time * pulsateSpeed, maxIntensity - minIntensity);
        pointLight.intensity = intensity;
    }
}

