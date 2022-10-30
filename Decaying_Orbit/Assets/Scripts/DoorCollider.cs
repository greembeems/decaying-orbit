using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    [SerializeField]
    bool[] key;

    [SerializeField]
    Collider2D doorCollider;

    [SerializeField]
    Pockets pockets;

    // Start is called before the first frame update

    void Start()
    {
        doorCollider = gameObject.GetComponent<Collider2D>();
        doorCollider.enabled = true;
        key[0] = pockets.Keys[0];
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        doorCollider.enabled = true;
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player" && key[0])
        { 
            doorCollider.enabled = false; 
        }
    }
}
