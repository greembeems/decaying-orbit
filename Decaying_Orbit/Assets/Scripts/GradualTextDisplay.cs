using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradualTextDisplay : MonoBehaviour
{
    [Header("Lines & On-screen Text Field")]
    [SerializeField]
    List<string> dialogueLines;

    [SerializeField]
    Text dialogueText;
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

    // Dialogue bubble components
    // Prefab
    [SerializeField]
    GameObject bubble;
    // Object's bubble
    GameObject textBubble;

    // If the text is triggered and if the player is in range
    bool textTriggered = false;

    // Location
    Vector3 location;

    private void Awake()
    {
        // Set up text bubble so it displays a consistent height from the character speaking
        textBubble = Instantiate<GameObject>(bubble);
        textBubble.transform.position = location;
        // Hide the text bubble
        textBubble.SetActive(false);
        // Grab the text component
        dialogueText = textBubble.transform.Find("Dialogue").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTimeDialogue = textSpeed;

        // Setup its position
        location = gameObject.transform.position + new Vector3(0, 5, 0);
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
            // Create timer that varies for text length
            currentTimeBubble = (currentLine.Length + 4) * textSpeed;
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
