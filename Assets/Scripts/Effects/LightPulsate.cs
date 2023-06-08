using UnityEngine;

public class LightPulsate : MonoBehaviour {
    public float minIntensity = 0.5f; // Minimum intensity value
    public float maxIntensity = 1.5f; // Maximum intensity value
    public float pulsateSpeed = 1f; // Speed of the pulsating effect

    private Light pointLight;
    private float baseIntensity;

    private void Start() {
        pointLight = GetComponent<Light>();
        baseIntensity = pointLight.intensity;
    }

    private void Update() {
        float intensity = baseIntensity + Mathf.PingPong(Time.time * pulsateSpeed, maxIntensity - minIntensity);
        pointLight.intensity = intensity;
    }
}


// using UnityEngine;
//
// public class LightPulsate : MonoBehaviour
// {
//     public float minIntensity = 0.5f; // Minimum intensity value
//     public float maxIntensity = 1.5f; // Maximum intensity value
//     public float pulseOnTimeShort = 0.5f; // Duration of short pulse on time
//     public float pulseOffTime = 1f; // Duration of pulse off time
//     public float pulseOnTimeLong = 1.5f; // Duration of long pulse on time
//
//     private Light pointLight;
//     private float baseIntensity;
//     private float pulseTimer;
//     private bool isPulsating = false;
//
//     private void Start()
//     {
//         pointLight = GetComponent<Light>();
//         baseIntensity = pointLight.intensity;
//         StartPulsation();
//     }
//
//     private void Update()
//     {
//         if (isPulsating)
//         {
//             pulseTimer += Time.deltaTime;
//
//             // Short pulse on time
//             if (pulseTimer <= pulseOnTimeShort)
//             {
//                 float t = pulseTimer / pulseOnTimeShort;
//                 pointLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
//             }
//             // Pulse off time
//             else if (pulseTimer <= pulseOnTimeShort + pulseOffTime)
//             {
//                 pointLight.intensity = minIntensity;
//             }
//             // Long pulse on time
//             else if (pulseTimer <= pulseOnTimeShort + pulseOffTime + pulseOnTimeLong)
//             {
//                 float t = (pulseTimer - pulseOnTimeShort - pulseOffTime) / pulseOnTimeLong;
//                 pointLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
//             }
//             // Restart pulsation
//             else
//             {
//                 StartPulsation();
//             }
//         }
//     }
//
//     private void StartPulsation()
//     {
//         pulseTimer = 0f;
//         isPulsating = true;
//     }
// }