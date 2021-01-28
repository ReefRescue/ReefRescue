using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Seconds for a full day, including night time
    public static readonly int DAY_LENGTH = 15;

    [SerializeField]
    private GameObject background;
    private SpriteRenderer brenderer;

    [SerializeField]
    public Sprite dayBackground;

    [SerializeField]
    public Sprite nightBackground;

    private float lastGiveTime = 0;

    void Start()
    {
        brenderer = background.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Mathf.Floor(Time.time) % DAY_LENGTH == 0 && Mathf.Floor(Time.time) != lastGiveTime)
        {
            CurrencySystem.balance += 3;
            Debug.Log("Changed");
            lastGiveTime = Mathf.Floor(Time.time);
        }

        if (IsDay()) brenderer.sprite = dayBackground;
        else brenderer.sprite = nightBackground;
    }

    public static bool IsDay()
    {
        return Time.time % DAY_LENGTH >= DAY_LENGTH / 8f && Time.time % DAY_LENGTH < DAY_LENGTH * 7f / 8;
    }
}
