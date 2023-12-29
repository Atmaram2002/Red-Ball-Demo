using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    //replay level
    public void ReplayLevel()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Quit the Game
    public void QuitGame()
    {
        Application.Quit ();
    } 
}
