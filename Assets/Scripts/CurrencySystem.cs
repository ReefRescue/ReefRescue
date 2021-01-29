﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencySystem : MonoBehaviour
{
    [SerializeField]
    private int startingBalance = 100;

    public static int balance;

    private Text CurrencyDisplay;

    void Awake()
    {
        CurrencyDisplay = GameObject.Find("BalanceCounter").GetComponent<Text>();
    }

    void Start()
    {
        balance = startingBalance;
    }

    void LateUpdate()
    {
        CurrencyDisplay.text = balance.ToString();
    }


}