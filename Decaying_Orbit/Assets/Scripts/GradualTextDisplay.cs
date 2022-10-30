using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GradualTextDisplay : MonoBehaviour
{
    [Header("Lines & On-screen Text Field")]
    [SerializeField]
    List<string> dialogueLines;

    [SerializeField]
    TextMeshPro dialogueText;
    // Current displayed string
    string dialogueByLetter = "";
    // Line of dialogue
    string currentLine = "";
    // Current character displayed string is on
    int currentChar = 0;

    [Header("Dialogue Speeds")]
    [SerializeField]
    float textSpeed = 0.2f;
    // Current times of dialogue timers
    float currentTimeDialogue;
    float currentTimeBubble;

    [SerializeField]
    AudioClip clip;
    [SerializeField]
    float volume = 1;
    [SerializeField]
    AudioSource source;

    // Dialogue bubble components
    // Prefab
    [SerializeField]
    GameObject textBubble;

    // If the text is triggered and if the player is in range
    bool textTriggered = false;

    private void Awake()
    {
        // Hide the text bubble
        textBubble.SetActive(false);
        // Grab the text component
        //dialogueText = textBubble.transform.Find("Dialogue").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTimeDialogue = textSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (textTriggered)
        {
            // If it's time for another letter, call to display that
            if (currentTimeDialogue <= 0)
            {
                dialogueText.text = TextSpeed();
            }

            // If the time for the dialogue bubble has played, hide the bubble
            if (currentTimeBubble <= 0)
            {
                textTriggered = false;
                DestroyBubble();
            }

            // Reduce the time
            currentTimeDialogue = currentTimeDialogue - Time.deltaTime;
            currentTimeBubble = currentTimeBubble - Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if collider is player
        if (collision.name == "Player")
        {
            textTriggered = true;
            // Display the dailogue bubble
            DisplayBubble();
            // Choose random dialogue line
            currentLine = dialogueLines[Random.Range(0, dialogueLines.Count)];
            Debug.Log(currentLine);
            // Create timer that varies for text length
            currentTimeBubble = (currentLine.Length + 4) * textSpeed;
            source.PlayOneShot(clip, volume);
        }
    }

    /// <summary>
    /// Displays the text bubble
    /// </summary>
    void DisplayBubble()
    {
        textBubble.SetActive(true);
    }

    /// <summary>
    /// Hides the text bubble & resets the text
    /// </summary>
    void DestroyBubble()
    {
        textBubble.SetActive(false);
        dialogueByLetter = "";
        currentChar = 0;
    }

    /// <summary>
    /// Displays the text letter by letter at given speed
    /// </summary>
    /// <returns> Current letter count for the text </returns>
    string TextSpeed()
    {
        if (currentChar < currentLine.Length)
        {
            dialogueByLetter += currentLine[currentChar];
            currentChar++;
            currentTimeDialogue = textSpeed;
        }

        return dialogueByLetter;
    }
}
