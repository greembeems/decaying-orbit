using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pockets : MonoBehaviour
{
    [SerializeField]
    string[] inventory;

    [SerializeField]
    bool[] keys;

    [SerializeField]
    AudioClip clip;
    [SerializeField]
    float volume = 1;
    [SerializeField]
    AudioSource source;

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
        source.PlayOneShot(clip, volume);
    }

    public void AddKey(int index)
    {
        keys[index] = true;
        source.PlayOneShot(clip, volume);
    }
}
