using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pockets : MonoBehaviour
{
    [SerializeField]
    string[] inventory;

    [SerializeField]
    bool[] keys;
    public bool[] Keys
    {
        get { return keys; }
    }

    public string[] Inventory
    {
        get { return inventory; }
    }

    public void AddItem(int index, string name)
    {
        inventory[index] = name;
    }
}
