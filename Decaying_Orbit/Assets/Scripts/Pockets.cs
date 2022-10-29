using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pockets : MonoBehaviour
{
    [SerializeField]
    string[] inventory;

    [SerializeField]
    bool key1 = true;
    public bool Key1
    {
        get { return key1; }
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
