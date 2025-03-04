using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueChoices : MonoBehaviour
{
    public GameObject[] choiceButtons; //Holds the UI buttons

    void Start()
    {
        HideButtons(); //Hide buttons when the game starts
    }

    public void ShowButtons()
    {
        foreach (GameObject button in choiceButtons)
        {
            if (button != null)
            {
                button.SetActive(true);
            }
        }
    }

    public void HideButtons()
    {
        foreach (GameObject button in choiceButtons)
        {
            if (button != null)
            {
                button.SetActive(false);
            }
        }
    }
}
