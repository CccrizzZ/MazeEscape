using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonScript : MonoBehaviour
{

    // pop up model
    public GameObject CreditPanel;

    public GameObject TutorialPanel;
    public GameObject PausePanel;

    // sound effect
    public AudioSource ButtonSound;




    public void OnNewGameButtonPressed()
    {
        ButtonSound.Play();
        SceneManager.LoadScene("LoadingScene");

    }


    public void OnQuitGameButtonPressed()
    {
        ButtonSound.Play();
        Application.Quit();

    }


    public void OnCreditButtonPressed()
    {
        ButtonSound.Play();
        Instantiate(CreditPanel, transform);

    }


    public void OnCloseButtonPressed()
    {
        ButtonSound.Play();
        if (CreditPanel)
        {
            Destroy(CreditPanel);
        }
        else if(TutorialPanel)
        {
            Destroy(TutorialPanel);
        }
        else if (PausePanel)
        {
            // Destroy(PausePanel);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PauseScript>().Unpause();
        }

    }


    public void OnMainMenuButtonPressed()
    {
        ButtonSound.Play();
        SceneManager.LoadScene("MenuScene");

    }


    public void OnTutorialButtonPressed()
    {
        ButtonSound.Play();
        Instantiate(TutorialPanel, transform);

    }

    void PlayButtonSound()
    {
        ButtonSound.Play();
    }



}
