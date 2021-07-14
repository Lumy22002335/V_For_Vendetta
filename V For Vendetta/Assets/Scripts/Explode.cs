using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explode : Interactible
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private GameObject explosionScene;
    [SerializeField] private GameObject video;
    [SerializeField] private GameObject backgroundTwo;
    
    private bool startCounter;
    private float counter;

    private void Start()
    {
        startCounter = false;
        counter = 0;
    }

    private void Update()
    {
        if (startCounter)
        {
            counter += Time.deltaTime;

            if (counter >= 18f && video.activeSelf)
            {
                video.SetActive(false);
            }
            else if (counter >= 26f)
            {
                backgroundTwo.SetActive(false);
            }

            if (counter >= 31)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }

    public override void Interact()
    {
        foreach(Item item in playerInventory.PlayerItems)
        {
            if (item.Name == "Matches")
            {
                StartExplosionCutscene();
            }
        }
    }

    private void StartExplosionCutscene()
    {
        explosionScene.SetActive(true);
        startCounter = true;
    }
}
