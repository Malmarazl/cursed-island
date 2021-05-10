using UnityEngine;

public class DialogueHolder : MonoBehaviour
{

    public string dialogue;
    private DialogueManager dialogueMan;

    public string [] dialogueLines;
    public string[] specialDialogueLines;

    void Start()
    {
        dialogueMan = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(!dialogueMan.dialogActive)
            {
                dialogueMan.dialogueLines = dialogueLines;
                dialogueMan.currentLine = 0;
                dialogueMan.ShowDialogue();
            }
        }
    }
}
