using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private PlayableDirector playableDirector;
    [SerializeField] private CinemachineConfiner2D confiner2D;
    [SerializeField] private PolygonCollider2D gardenHouseConfiner;

    private float cutsceneCounter;
    private float keyDownCounter;

    private bool skiped;

    private bool gamepause = false;

    private void Start()
    {
        cutsceneCounter = 0;
        keyDownCounter = 0;
        skiped = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        cutsceneCounter += Time.deltaTime;

        if (Input.GetKey(KeyCode.Escape) && !skiped)
        {
            keyDownCounter += Time.deltaTime;

            if (keyDownCounter > 1.5f)
            {
                if (cutsceneCounter < 125f)
                {
                    confiner2D.GetComponent<ChangeCamConfiner>().enabled = false;
                    skiped = true;
                    playableDirector.time = 125;
                    confiner2D.m_BoundingShape2D = gardenHouseConfiner;
                }
            }
        }

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (keyDownCounter < 1.5f || skiped)
            {
                if (gamepause == false)
                {
                    PauseGame();
                }
                else if (gamepause == true)
                {
                    ResumeGame();
                }

                keyDownCounter = 0;
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gamepause = true;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gamepause = false;
        pauseMenu.SetActive(false);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
