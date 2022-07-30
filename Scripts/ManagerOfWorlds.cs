using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerOfWorlds : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void World1()
    {
        SceneManager.LoadScene("World1");
        Time.timeScale = 1f;
    }
    public void World2()
    {
        SceneManager.LoadScene("World2");
        Time.timeScale = 1f;
    }
    public void World3()
    {
        SceneManager.LoadScene("World3");
        Time.timeScale = 1f;
    }
    public void World4()
    {
        SceneManager.LoadScene("World4");
        Time.timeScale = 1f;
    }
    public void World5()
    {
        SceneManager.LoadScene("World5");
        Time.timeScale = 1f;
    }
}
