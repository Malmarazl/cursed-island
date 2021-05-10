using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public GameObject dialogueBox;
    public GameObject blockButtons;
    public Text dialogueText;

    public bool dialogActive;
    bool continueText;

    public string[] dialogueLines;
    public int currentLine = 0;

    void Update()
    {
        if(dialogActive && continueText)
        {
            currentLine++;
            continueText = false;
        }

        if(currentLine >= dialogueLines.Length)
        {
            dialogueBox.SetActive(false);
            dialogActive = false;
            currentLine = 0;
            blockButtons.SetActive(false);
        }

        dialogueText.text = dialogueLines[currentLine];
    }

    public void ShowDialogue()
    {
        blockButtons.SetActive(true);
        dialogActive = true;
        dialogueBox.SetActive(true);
    }

    public void TapToContinue()
    {
        continueText = true;
    }
}
