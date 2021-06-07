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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.pirateVoice);

            if(!dialogueMan.dialogActive)
            {
                if(CoinCount.instance.coinsCount < 6)
                {
                    dialogueMan.dialogueLines = dialogueLines;

                } else {

                    dialogueMan.dialogueLines = specialDialogueLines;
                }

                dialogueMan.currentLine = 0;
                dialogueMan.ShowDialogue();
            }
        }
    }
}
