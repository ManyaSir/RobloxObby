using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Skins()
    {
        SceneManager.LoadScene(2);
    }

    public void Game()
    {
        SceneManager.LoadScene(3);
    }

}