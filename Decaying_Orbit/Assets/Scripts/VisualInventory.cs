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
    // 1    2
    // 3    4
    // 5    6

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
        }
    }

    public void DisplayInventory()
    {
        inventoryCanvas.enabled = true;
    }

    public void DisplayItem(int index)
    {
        loreSprites[index].SetActive(true);
    }
}
