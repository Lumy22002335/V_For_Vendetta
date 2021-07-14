using UnityEngine;

public class ReadMessage : Interactible
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject message;

    private bool reading;

    private void Update()
    {
        if (reading && Input.GetKeyDown(KeyCode.E))
        {
            message.SetActive(false);
            player.GetComponent<Movement>().enabled = true;
            reading = false;
            gameObject.SetActive(false);
        }
    }

    public override void Interact()
    {
        message.SetActive(true);
        player.GetComponent<Movement>().enabled = false;
        reading = true;
    }
}
