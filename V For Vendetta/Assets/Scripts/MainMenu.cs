using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator fadeAnimator;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void Play()
    {
        fadeAnimator.SetTrigger("FadeIn");

        // Changes to game sceen after 0.5seconds
        Invoke("FadeToScene", 0.5f);
    }

    public void FadeToScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
