using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayTheGame(){
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitTheGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
