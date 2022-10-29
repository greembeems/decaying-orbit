using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Player scripts
    [SerializeField]
    GameObject player;
    Pockets playerPocket;

    // Item information
    [SerializeField]
    string itemName = "ITEM";
    [SerializeField]
    int itemIndex = 0;

    private void Awake()
    {
        playerPocket = player.GetComponent<Pockets>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            // Add item to the pocket of the player & disable the item in the scene
            playerPocket.AddItem(itemIndex, itemName);
            gameObject.SetActive(false);
        }
    }
}
