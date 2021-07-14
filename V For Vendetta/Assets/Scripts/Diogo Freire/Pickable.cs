using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactible, Item
{
    [SerializeField] private string itemName;
    public string Name { get => itemName; }

    public override void Interact()
    {
        Destroy(this.gameObject);
    }
}
