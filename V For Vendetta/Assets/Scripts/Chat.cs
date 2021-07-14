using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    [SerializeField] private AiMove guard;
    [SerializeField] private GameObject[] vTexts;
    [SerializeField] private GameObject guardText;
    [SerializeField] private Sprite guardTextBox;
    [SerializeField] private Movement playerMovement;

    private Image spriteRenderer;

    private int currentVText = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<Image>();
        playerMovement.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.enabled = false;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (spriteRenderer.sprite == guardTextBox)
            {
                playerMovement.enabled = true;
                gameObject.SetActive(false);
            }

            if (currentVText == 2)
            {
                vTexts[currentVText].SetActive(false);
                guardText.SetActive(true);
                spriteRenderer.sprite = guardTextBox;
            }
            else
            {
                if (currentVText != 1 || guard.AtPosition)
                {
                    vTexts[currentVText].SetActive(false);
                    currentVText++;
                    vTexts[currentVText].SetActive(true);
                }
            }

            if (currentVText == 1)
            {
                guard.MoveToPosition();
            }
        }
    }
}
