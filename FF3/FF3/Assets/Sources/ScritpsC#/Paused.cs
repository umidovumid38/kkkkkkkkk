using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : MonoBehaviour
{
    public GameObject PanelPaused;
    public bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused == true)
            {
            PanelPaused.SetActive(true);
                Time.timeScale = 0;
            }else
            {
                PanelPaused.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
