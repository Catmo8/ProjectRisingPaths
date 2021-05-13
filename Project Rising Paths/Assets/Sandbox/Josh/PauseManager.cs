using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menu;
    PauseAction actions;
    public static bool paused = false;

    private void Awake()
    {
        actions = new PauseAction();
    }
    
    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        paused = true;
        AudioListener.pause = true;
        menu.SetActive(true);
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        paused = false;
        AudioListener.pause = false;
        menu.SetActive(false);
        
    }

    public void DeterminedPause()
    {
        if (paused)
            ResumeGame();
        else
            PauseGame();
    }

    private void Start()
    {
        actions.Pause.PauseGame.performed += _ => DeterminedPause();
        menu.SetActive(false);
    }

}
