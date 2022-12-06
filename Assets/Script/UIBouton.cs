using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIBouton : MonoBehaviour
{
    public PlayerMovement _PlayerMovement;

    public void Menu()
    {
        if (_PlayerMovement.isPause == true)
        {
            Time.timeScale = 1;
            _PlayerMovement.isPause = false;
        }

        SceneManager.LoadScene(0);
    }

    public void LeftGame()
    {
        Application.Quit();
    }
}
