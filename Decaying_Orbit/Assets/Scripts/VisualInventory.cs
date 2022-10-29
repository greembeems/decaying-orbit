using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualInventory : MonoBehaviour
{
    [SerializeField]
    Canvas inventoryCanvas;
    [SerializeField]
    Button[] inventoryItems;
    [SerializeField]
    string[] playerPockets;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject[] loreSprites;

    // Will visually display as 
    // 1    4
    // 2    5
    // 3    6

    // Start is called before the first frame update
    void Start()
    {
        inventoryCanvas.enabled = false;
        playerPockets = player.GetComponent<Pockets>().Inventory;
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            inventoryItems[i].enabled = false;
            if (playerPockets[i] != null)
            {
                inventoryItems[i].enabled = true;
            }

            loreSprites[i].SetActive(false);
        }
    }

    public void DisplayInventory()
    {
        inventoryCanvas.enabled = true;
    }

    public void DisplayItem(int index)
    {
        // Remove any active lore sprites
        for (int i = 0; i < loreSprites.Length; i++)
        {
            loreSprites[i].SetActive(false);
        }
        // Display the desired lore card
        loreSprites[index].SetActive(true);
    }
}
