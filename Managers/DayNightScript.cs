using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class DayNightScript : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay;
    public TextMeshProUGUI dayDisplay;
    public UnityEngine.Rendering.Universal.Light2D globalLight;
    public float tick;
    public float seconds;
    public int mins;
    public int hours;
    public int days = 1;
    public bool activateLights;
    public GameObject[] lights;
    public Color dayColor = new Color(1.0f, 0.87f, 0.74f); // Nuevo color para el día
    public Color nightColor = new Color(0.36f, 0.48f, 1f); // Nuevo color para la noche 
    public float transitionDuration = 1f; // Duración de la transición de colores

    void Start()
    {
        globalLight = GameObject.FindWithTag("GlobalLight").GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    void FixedUpdate()
    {
        CalcTime();
        DisplayTime();
    }

    public void CalcTime()
    {
        seconds += Time.fixedDeltaTime * tick;

        if (seconds >= 60)
        {
            seconds = 0;
            mins += 1;
        }

        if (mins >= 60)
        {
            mins = 0;
            hours += 1;
        }

        if (hours >= 24)
        {
            hours = 0;
            days += 1;
        }

        ControlLights();
    }

    public void ControlLights()
{
    if (hours >= 9 && hours < 19)
    {
        globalLight.intensity = 1f;
        globalLight.color = dayColor;
    }
    else if (hours >= 19 && hours < 21)
    {
        float t = Mathf.InverseLerp(19f, 21f, (float)hours + (float)mins / 60f);
        globalLight.intensity = Mathf.Lerp(1f, 0.2f, t);
        globalLight.color = Color.Lerp(dayColor, nightColor, t);
    }
    else if (hours >= 21 || hours < 7)
    {
        globalLight.intensity = 0.2f;
        globalLight.color = nightColor;
    }
    else if (hours >= 7 && hours < 9)
    {
        float t = Mathf.InverseLerp(7f, 9f, (float)hours + (float)mins / 60f);
        globalLight.intensity = Mathf.Lerp(0.2f, 1f, t);
        globalLight.color = Color.Lerp(nightColor, dayColor, t);
    }

    // toggle lights based on activateLights
    if (hours >= 8 && hours < 20)
    {
        if (activateLights) 
        {
            activateLights = false; 
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].SetActive(false); 
            }
        }
    }
    else
    {
        if (!activateLights) 
        {
            activateLights = true; 
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].SetActive(true); 
            }
        }
    }
}

    public void DisplayTime()
    {
        timeDisplay.text = string.Format("{0:00}:{1:00}", hours, mins);
        dayDisplay.text = "Day: " + days;
    }

}