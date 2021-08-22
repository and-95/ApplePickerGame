using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Scene0");
    }

    public void HardLevel()
    {
        SceneManager.LoadScene("Scene1");
    }

    
}
