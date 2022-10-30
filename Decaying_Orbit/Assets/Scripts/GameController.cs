using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Time before game just ends
    [SerializeField]
    float gameTime = 600;

    // Requirements for the game to end otherwise
    [SerializeField]
    string[] totalItems;
    string[] playerInventory; // Asign each item a specific slot, just makes this process quicker
    [SerializeField]
    GameObject player;


    private void Awake()
    {
        playerInventory = player.GetComponent<Pockets>().Inventory;
    }

    // Update is called once per frame
    void Update()
    {
        // If game is out of time or the inventory is complete
        if (gameTime <= 0 || CheckInventory())
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    /// <summary>
    /// Checks all items in the inventory to see if the player has everything - will require all items to be in the exact same positions
    /// </summary>
    /// <returns></returns>
    bool CheckInventory()
    {
        for (int i = 0; i < playerInventory.Length; i++)
        {
            // If one item is not equal, return false and quit checking
            if (playerInventory[i] != totalItems[i])
            {
                return false;
            }
        }

        // If all items are equal
        return true;
    }
}
