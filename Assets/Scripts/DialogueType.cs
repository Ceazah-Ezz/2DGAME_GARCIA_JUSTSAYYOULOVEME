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
    private Coroutine typingCoroutine;
    private DialogueChoices dialogueChoices; // Reference to button manager
    public PageManager pageManager; // Reference to the page manager
    public int nextPageIndex;

    void Start()
    {
        if (dialogueChoices == null)
        {
            dialogueChoices = FindObjectOfType<DialogueChoices>();

            if (dialogueChoices == null)
            {
                Debug.LogWarning("DialogueChoices is missing. Assign it in the Inspector.");
            }
        }

        if (pageManager == null)
        {
            pageManager = FindObjectOfType<PageManager>();

            if (pageManager == null)
            {
                Debug.LogError("PageManager is missing from the scene. Assign it in the Inspector.");
                return;
            }
        }

        if (textComponent == null)
        {
            Debug.LogError("Text Component is missing. Assign it in the Inspector.");
            return;
        }

        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
                typingCoroutine = null;
                textComponent.text = lines[index];
            }
            else
            {
                NextLine();
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        typingCoroutine = StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        if (index >= lines.Length)
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

        typingCoroutine = null;

        if (index == lines.Length - 1 && dialogueChoices != null)
        {
            dialogueChoices.ShowButtons();
        }
    }

    void NextLine()
    {
        if (index >= lines.Length - 1)
        {
            StartCoroutine(CloseDialogue());
            return;
        }

        index++;
        if (index < lines.Length)
        {
            textComponent.text = string.Empty;
            typingCoroutine = StartCoroutine(TypeLine());
        }
    }

    IEnumerator CloseDialogue()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);

        if (dialogueChoices != null)
        {
            dialogueChoices.ShowButtons();
        }

        if (pageManager != null)
        {
            pageManager.ShowPage(nextPageIndex);
        }
    }
}
