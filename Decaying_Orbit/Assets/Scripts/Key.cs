using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Player scripts
    [SerializeField]
    GameObject player;
    Pockets playerPocket;

    // Item information
    [SerializeField]
    int keyIndex = 0;

    [SerializeField]
    BoxCollider2D trigger;

    private void Awake()
    {
        playerPocket = player.GetComponent<Pockets>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            // Add item to the pocket of the player & disable the item in the scene
            playerPocket.AddKey(keyIndex);
            gameObject.SetActive(false);
        }
    }
}
