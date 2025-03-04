using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    public GameObject[] pages; 
    public int currentPage = 0;

    void Start()
    {
        ShowPage(0);
    }

    public void ShowPage(int pageIndex)
    {
        if (pageIndex < 0 || pageIndex >= pages.Length) 
        {
            Debug.LogError("Invalid page index: " + pageIndex);
            return;
        }

        // Hide all pages first
        foreach (GameObject page in pages)
        {
            page.SetActive(false);
        }

        // Show only the selected page
        pages[pageIndex].SetActive(true); // Use "pa
        currentPage = pageIndex;
    }

    public void NextPage()
    {
        if (currentPage < pages.Length - 1) 
        {
            ShowPage(currentPage + 1);
        }
    }
}
