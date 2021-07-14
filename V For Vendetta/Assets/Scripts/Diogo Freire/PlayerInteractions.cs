using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private Interactible interactible;
    private PlayerInventory playerInventory;
    private Animator animator;
    private bool triggerAvailable;

    private void Start() {
        playerInventory = GetComponent<PlayerInventory>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerAvailable && Input.GetKeyDown(KeyCode.E)) 
        {
            animator.SetTrigger("PickUp");

            if (interactible is Item) 
            {
                playerInventory.PlayerItems.Add((Item)interactible);
            }

            interactible.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactible")) 
        {
            triggerAvailable = true;
            interactible = other.gameObject.GetComponent<Interactible>();
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactible")) 
        {
            triggerAvailable = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
