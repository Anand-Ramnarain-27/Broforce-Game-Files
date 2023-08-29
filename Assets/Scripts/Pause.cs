using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject PuaseMenu;

    private bool isPaused;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused)
                Resume();
            else
                Pauses();
        }
    }



    public void Resume()
    {
        PuaseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
      
    }

    public void Pauses()
    {
        PuaseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
      
    }
}
