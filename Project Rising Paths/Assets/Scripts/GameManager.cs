using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    [Header("Character Loader")]
    public GameObject networkManager;
    public GameObject XRPlayer;
    public GameObject littleGuy;

    [Header("Pause Manager")]
    public GameObject xrCanvas;
    public GameObject playerCanvas;
    public InputActionReference xrMenu;

    public static bool gameWon = false;
    public bool victoryMusicPlayed = false; 

    [Header("Victory")]
    public AudioSource audioSource;
    public AudioClip audioClip;


    // Start is called before the first frame update
    void Start()
    {
        SelectMode();
        gameWon = false;
        victoryMusicPlayed = false; 
        audioSource = GetComponent<AudioSource>();
    }

    #region setup
    private void OnEnable()
    {
        if (xrMenu != null) xrMenu.action.Enable();
    }

    private void OnDisable()
    {
        if (xrMenu != null) xrMenu.action.Disable();
    }
    #endregion setup
    
    private void Update()
    {
        if(gameWon && !victoryMusicPlayed)
        {
            audioSource.loop = false;
            audioSource.Stop();
            audioSource.PlayOneShot(audioClip);
            victoryMusicPlayed = true;
        }

        if(victoryMusicPlayed && !audioSource.isPlaying)
        {
            if(ModeSelect.networkCreator || ModeSelect.networkLittleGuy)
            {
                PhotonNetwork.Disconnect();
                Cursor.lockState = CursorLockMode.None;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

        ControlMenu();
    }

    void ControlMenu()
    {
        if (ModeSelect.localPlay)
        {
            if (xrMenu.action.triggered)
            {
                if (!xrCanvas.activeInHierarchy)
                {
                    xrCanvas.SetActive(true);
                }
                else
                {
                    xrCanvas.SetActive(false);
                }
            }
            if (littleGuy.GetComponent<third_person_controller.CharacterControl>().Menu)
            {
                if (!playerCanvas.activeInHierarchy)
                {
                    playerCanvas.SetActive(true);
                }
                else
                {
                    playerCanvas.SetActive(false);
                }
            }
        }
        else if (ModeSelect.networkCreator)
        {
            if (xrMenu.action.triggered)
            {
                if (!xrCanvas.activeInHierarchy)
                {
                    xrCanvas.SetActive(true);
                }
                else
                {
                    xrCanvas.SetActive(false);
                }
            }
        }
        else if (ModeSelect.networkLittleGuy)
        {
            if (littleGuy.GetComponent<third_person_controller.CharacterControl>().Menu)
            {
                if (!playerCanvas.activeInHierarchy)
                {
                    playerCanvas.SetActive(true);
                }
                else
                {
                    playerCanvas.SetActive(false);
                }
            }
        }

    }

    void SelectMode()
    {
        if (ModeSelect.localPlay)
        {
            //networkCreator.SetActive(false);
            //networkLittleGuy.SetActive(false);
            networkManager.SetActive(false);
            XRPlayer.SetActive(true);
            littleGuy.SetActive(true);
        }
        else if (ModeSelect.networkCreator)
        {
            //networkCreator.SetActive(true);
            //networkLittleGuy.SetActive(true);
            networkManager.SetActive(true);
            XRPlayer.SetActive(true);
            littleGuy.SetActive(true);
            //XRPlayer.GetComponentInChildren<Camera>().
            XRPlayer.GetComponentInChildren<Camera>().depth = 2;
        }
        else if (ModeSelect.networkLittleGuy)
        {
            //networkCreator.SetActive(true);
            //networkLittleGuy.SetActive(true);
            networkManager.SetActive(true);
            XRPlayer.SetActive(true);
            littleGuy.SetActive(true);
            XRPlayer.GetComponentInChildren<Camera>().depth = 0;
        }
    }
}
