using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Transform sun;
    public Light sunLight;
    public int dayLength;
    public float rotationSunSpeed;
    static public float actualTime;
    void Start()
    {
        dayLength = 60;
        rotationSunSpeed = 360 / dayLength;
    }


    void Update()
    {
        actualTime += Time.deltaTime;
        sun.Rotate(5 * Time.deltaTime, 0, 0);
        if (actualTime > 0 && actualTime < 7.5f)
        {
            sunLight.intensity += 1 * Time.deltaTime / 7.5f;
            RenderSettings.ambientIntensity += 0.45f * Time.deltaTime / 7.5f;
        }

        if(actualTime >= 7.5f && actualTime < 8)
        {
            sunLight.intensity = 1;
            RenderSettings.ambientIntensity = 0.45f;
        }

        if (actualTime > 30 && actualTime < 37.5f)
        {
            sunLight.intensity -= 1 * Time.deltaTime / 7.5f;
            RenderSettings.ambientIntensity -= 0.45f * Time.deltaTime / 7.5f;
        }
        if (actualTime >= 37.5f && actualTime < 38)
        {
            sunLight.intensity = 0;
            RenderSettings.ambientIntensity = 0;
        }
        if(actualTime >= 60)
        {
            actualTime = 0;
        }
    }
}
