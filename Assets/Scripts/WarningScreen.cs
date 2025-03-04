using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningScreen : MonoBehaviour
{
    public GameObject Warning;

    [SerializeField] private CanvasGroup UIGroup; // Includes the UI group that the script refers to
    [SerializeField] private bool fadein = false;
    [SerializeField] private bool fadeout = false;

    private void Start()
    {
        Warning.SetActive(true);
        UIGroup.blocksRaycasts = true; // Makes Warning Screen block menu
    }

    public void HideUI()
    {
        fadeout = true;
        Warning.SetActive(false);
    }

    private void Update()
    {
        // Fade Out
        if (fadeout)
        {
            if (UIGroup.alpha >= 0)
            {
                UIGroup.alpha -= Time.deltaTime; // Ensuring it does fade in a certain amount of time
                if (UIGroup.alpha == 0)
                {
                    UIGroup.alpha = 0;
                    fadeout = false;
                    UIGroup.blocksRaycasts = false; //Makes Menu usable
                }
            }
        }
    }
}
