using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencySystem : MonoBehaviour
{
    [SerializeField]
    private int startingBalance = 100;

    private static int balance;

    public static int[] coralCosts;

    public static int[] coralIncome;

    [SerializeField]
    private int[] tempCoralIncome;

    [SerializeField]
    private Text[] coralPriceText;

    private Text CurrencyDisplay;

    void Awake()
    {
        CurrencyDisplay = GameObject.Find("BalanceCounter").GetComponent<Text>();

        coralCosts = new int[coralPriceText.Length];
        for (int i = 0; i < coralPriceText.Length; i++)
            coralCosts[i] = int.Parse(coralPriceText[i].text);

        Debug.Log(tempCoralIncome);
        coralIncome = tempCoralIncome;
    }

    void Start()
    {
        SetBalance(startingBalance);
    }

    void LateUpdate()
    {
        CurrencyDisplay.text = GetBalance().ToString();
    }

    public static bool HasSufficientFunds(int coralIndex)
    {
        return GetBalance() >= coralCosts[coralIndex];
    }

    public static int GetBalance() { return balance; }
    public static void SetBalance(int b) { balance = b; PanelGreyer.PanelGrey(); }
    public static void ChangeBalance(int offset) { balance += offset; PanelGreyer.PanelGrey(); }
}
