using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGreyer : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tempPanelsToHide;

    [SerializeField]
    private Sprite[] tempGreyedSprites;
    [SerializeField]
    private Sprite[] tempRegSprites;

    private static Sprite[] greyedSprites;
    private static Sprite[] regSprites;
    private static GameObject[] panelsToHide;

    void Start()
    {
        greyedSprites = tempGreyedSprites;
        panelsToHide = tempPanelsToHide;
        regSprites = tempRegSprites;
    }

    public static void PanelGrey()
    {
        for (int i = 0; i < panelsToHide.Length; i++)
        {
            GameObject o = panelsToHide[i];

            if (CurrencySystem.HasSufficientFunds(i))
            {
                o.GetComponent<Image>().sprite = regSprites[i];
                Debug.Log("Ungreying sprite " + i);
            }
            else
            {
                o.GetComponent<Image>().sprite = greyedSprites[i];
                Debug.Log("Greying sprite " + i);
            }
        }
    }
}
