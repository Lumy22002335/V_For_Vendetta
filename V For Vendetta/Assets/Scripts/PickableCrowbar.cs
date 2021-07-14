using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableCrowbar : Interactible, Item
{
    [SerializeField] private string itemName;
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject vText;
    [SerializeField] private BoxCollider2D exit;

    private Chat chat;

    public string Name { get => itemName; }

    private void Start()
    {
        chat = textBox.GetComponent<Chat>();
    }

    public override void Interact()
    {
        textBox.SetActive(true);
        vText.SetActive(true);
        chat.enabled = true;

        exit.enabled = true;

        Destroy(this.gameObject);
    }
}
