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
    [SerializeField]
    int index;

    // Start is called before the first frame update

    void Start()
    {
        doorCollider = gameObject.GetComponent<Collider2D>();
        doorCollider.enabled = true;
        //key[index] = pockets.Keys[index];
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        doorCollider.enabled = true;
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player" && key[index])
        { 
            doorCollider.enabled = false; 
        }
    }
}
