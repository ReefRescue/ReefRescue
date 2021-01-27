using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public static readonly int DAY_LENGTH = 15;

    private float lastGiveTime = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (Mathf.Floor(Time.time) % DAY_LENGTH == 0 && Mathf.Floor(Time.time) != lastGiveTime)
        {
            CurrencySystem.balance += 3;
            Debug.Log("Changed");
            lastGiveTime = Mathf.Floor(Time.time);
        }

    }

    public static bool IsDay()
    {
        return Time.time % DAY_LENGTH >= DAY_LENGTH / 4f && Time.time % DAY_LENGTH < DAY_LENGTH * 3f / 4;
    }
}
