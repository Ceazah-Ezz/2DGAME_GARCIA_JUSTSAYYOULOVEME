using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueType : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    private DialogueChoices dialogueChoices; //Reference to button manager
    public PageManager pageManager; //  Reference to the page manager
    public int nextPageIndex;


    void Start()
    {
        textComponent.text = string.Empty;

        //Find DialogueChoices script in the scene
        dialogueChoices = FindObjectOfType<DialogueChoices>();

        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        if (index >= lines.Length) //Prevents out-of-bounds error
        {
            Debug.LogError("TypeLine() tried to access an index outside the array.");
            yield break;
        }

        textComponent.text = "";

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        if (index == lines.Length - 1 && dialogueChoices != null)
        {
            dialogueChoices.ShowButtons();
        }
    }

    void NextLine()
    {
        if (index >= lines.Length - 1) 
        {
            gameObject.SetActive(false);

            if (dialogueChoices != null)
            {
                dialogueChoices.ShowButtons();
            }
            else if (pageManager != null) 
            {
                pageManager.ShowPage(nextPageIndex);
            }
            return;
        }

        index++;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }
}
