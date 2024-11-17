
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
  //  public Dialogue dialogue;

   // public GameObject dialogueBox;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Object entered trigger: {other.gameObject.name}");


        
        //  FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


    private void OnTriggerExit2D(Collider2D other)
    {
      //  dialogueBox.SetActive(false);
    }



}

