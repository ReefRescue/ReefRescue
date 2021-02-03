using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    // Seconds for a full day, including night time
    public const int DAY_LENGTH = 15;

    [SerializeField]
    private GameObject background;
    private SpriteRenderer brenderer;

    [SerializeField]
    private PauseMenuScript p;

    [SerializeField]
    private GameObject dayEndScreen;

    [SerializeField]
    private Text earnings;

    [SerializeField]
    public Sprite[] backgroundsInOrder;

    private float lastGiveTime = 0;

    public static int deltaCurrency = 0;

    public static bool onDayEndScreen = false;

    [SerializeField]
    private float waitFramesBeforeAllowingClick = 100;
    private float lastTimeSinceDisplay = 0;

    void Start()
    {
        brenderer = background.GetComponent<SpriteRenderer>();
        onDayEndScreen = false;
        dayEndScreen.SetActive(false);
    }

    void Update()
    {
        if (Mathf.Floor(Time.time) % DAY_LENGTH == 0 && Mathf.Floor(Time.time) != lastGiveTime)
        {
            if (!onDayEndScreen) {
                p.Pause(false);
                onDayEndScreen = true;
                dayEndScreen.SetActive(true);
                earnings.text = deltaCurrency.ToString();
                lastTimeSinceDisplay = 0;
            } else
            {
                lastTimeSinceDisplay++;
            }

            if (Input.GetMouseButton(0) && lastTimeSinceDisplay > waitFramesBeforeAllowingClick)
            {
                p.Resume();
                onDayEndScreen = false;
                dayEndScreen.SetActive(false);
                CurrencySystem.ChangeBalance(deltaCurrency);
                Debug.Log("Changed");
                lastGiveTime = Mathf.Floor(Time.time);
            }
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
