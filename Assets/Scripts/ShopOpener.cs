using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpener : MonoBehaviour {

    public GameObject Panel;

    private PauseMenuScript p;

    void Awake()
    {
        p = FindObjectOfType<PauseMenuScript>();
    }

    public void OpenPanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
}