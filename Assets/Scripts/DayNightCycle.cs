using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Seconds for a full day, including night time
    public const int DAY_LENGTH = 15;

    [SerializeField]
    private GameObject background;
    private SpriteRenderer brenderer;

    [SerializeField]
    public Sprite[] backgroundsInOrder;

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

        brenderer.sprite = backgroundsInOrder[(int) (GetLocalTime() / (DAY_LENGTH / (float) backgroundsInOrder.Length))];
    }

    public static bool IsDay()
    {
        return GetLocalTime() >= DAY_LENGTH / 6f && GetLocalTime() < DAY_LENGTH * 5f / 6;
    }

    public static float GetLocalTime()
    {
        return Time.time % DAY_LENGTH;
    }
}
