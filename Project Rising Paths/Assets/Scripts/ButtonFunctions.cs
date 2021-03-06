using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SetNetworkLittleGuy()
    {
        ModeSelect.networkLittleGuy = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResetModeSelect()
    {
        ModeSelect.localPlay = false;
        ModeSelect.networkCreator = false;
        ModeSelect.networkLittleGuy = false;
    }

    public void MainMenu()
    {
        if (ModeSelect.networkCreator || ModeSelect.networkLittleGuy)
        {
            PhotonNetwork.Disconnect();
            Debug.Log("Disconnecting From Server...");
        }
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
