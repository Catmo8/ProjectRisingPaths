using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void SetLocalPlay()
    {
        ModeSelect.localPlay = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SetNetworkCreator()
    {
        ModeSelect.networkCreator = true;
    }

    public void SetNetworkLittleGuy()
    {
        ModeSelect.networkLittleGuy = true;
    }

    public void ResetModeSelect()
    {
        ModeSelect.localPlay = false;
        ModeSelect.networkCreator = false;
        ModeSelect.networkLittleGuy = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
