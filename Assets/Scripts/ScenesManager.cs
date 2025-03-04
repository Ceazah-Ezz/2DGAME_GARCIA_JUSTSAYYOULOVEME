using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void GoToAct1()
    { // Goes to the Act1 Scene in unity
        SceneManager.LoadScene("Act1");
    }

    public void GoToAct2()
    { // Goes to the Act2 Scene in unity
        SceneManager.LoadScene("Act2");
    }

    public void GoToMenu()
    { // Goes to the Menu Scene in unity
        SceneManager.LoadScene("Menu");
    }
} //This is to manage big scenes, some parts of the game are divided into scenes in order for better ultilzation and organization