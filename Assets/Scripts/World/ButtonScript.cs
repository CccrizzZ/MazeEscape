using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonScript : MonoBehaviour
{


    public GameObject CreditPanel;


    public void OnNewGameButtonPressed()
    {
        SceneManager.LoadScene("LoadingScene");
    }


    public void OnQuitGameButtonPressed()
    {
        Application.Quit();
    }


    public void OnCreditButtonPressed()
    {
        Instantiate(CreditPanel, transform);
    }


    public void OnCloseButtonPressed()
    {
        Destroy(CreditPanel);
    }


    public void OnMainMenuButtonPressed()
    {
        SceneManager.LoadScene("MenuScene");

    }
}
