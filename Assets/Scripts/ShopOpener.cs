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

    private void Start()
    {
        Panel.SetActive(false);
    }

    public void OpenPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(!Panel.activeSelf);
        }
    }
    }


    