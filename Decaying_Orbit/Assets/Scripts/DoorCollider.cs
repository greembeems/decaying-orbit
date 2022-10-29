using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    /*[SerializeField]
    Collider2D doorColliderTrigger;*/
    bool key;

    [SerializeField]
    Collider2D doorCollider;

    [SerializeField]
    Pockets pockets;

    // Start is called before the first frame update

    void Start()
    {
        doorCollider = gameObject.GetComponent<Collider2D>();
        key = pockets.Key1;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player" && key)
        { doorCollider.enabled = false; }

    }

}
