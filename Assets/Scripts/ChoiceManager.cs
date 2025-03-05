using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueChoices : MonoBehaviour
{
    public GameObject[] choiceButtons; //Holds the UI buttons
    [SerializeField] 
    private PageManager pageManager; // PageManager script reference

    void Start()
    {
        ShowButtons(); //If the page has buttons, it shows them immediately
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

    public void ChoiceMaking(int pageIndex) // This selects which page will be shown dependng on the button
    {
        if (pageManager != null)
        {
            pageManager.ShowPage(pageIndex); // Use the correct PageManager function
        }
        else
        {
            Debug.LogError("PageManager is not assigned in DialogueChoices!");
        }
    }
}
