
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //  public Dialogue dialogue;

    // public GameObject dialogueBox;

    public bool isBanished = false;



    public Transform playerTransform;

    public bool isFollowing = true;

    public Vector3 offset;

    public static int followerCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"NPC triggered by: {other.gameObject.name}");

            // make friends follow the player
            playerTransform = other.transform;
            isFollowing = true;

            // space the friends
            offset = new Vector3(1.5f * (followerCount % 2 == 0 ? 1 : -1), -0.5f * followerCount, 0);
            followerCount++;

            // Optionally, disable the collider to prevent re-triggering
            GetComponent<Collider2D>().enabled = false;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
      //  dialogueBox.SetActive(false);
    }



    private void Update()
    {
        if (isFollowing && playerTransform != null)
        {
            Vector3 followPosition = playerTransform.position + offset;
            transform.position = Vector3.Lerp(transform.position, followPosition, Time.deltaTime * 5f);
        }
    }



}

